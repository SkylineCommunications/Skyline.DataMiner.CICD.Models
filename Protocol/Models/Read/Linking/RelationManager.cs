namespace Skyline.DataMiner.CICD.Models.Protocol.Read.Linking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Skyline.DataMiner.CICD.Common.Events;

    public class RelationManager : IDeferEvents, IDisposable
    {
        private readonly IDictionary<Mappings, Mapping> _mappings;

        private readonly Dictionary<IReadable, List<Reference>> _forwardReferences = new Dictionary<IReadable, List<Reference>>();
        private readonly Dictionary<Mappings, Dictionary<string, List<Reference>>> _reverseReferences = new Dictionary<Mappings, Dictionary<string, List<Reference>>>();

        private readonly Dictionary<IReadable, List<Link>> _forwardLinks = new Dictionary<IReadable, List<Link>>();
        private readonly Dictionary<IReadable, List<Link>> _reverseLinks = new Dictionary<IReadable, List<Link>>();

        public RelationManager(IDictionary<Mappings, Mapping> mappings)
        {
            _mappings = mappings ?? throw new ArgumentNullException(nameof(mappings));

            foreach (var mappingKey in mappings.Keys)
            {
                _reverseReferences.Add(mappingKey, new Dictionary<string, List<Reference>>());
            }
        }

        #region Events

        public event EventHandler<ReferenceAddedEventArgs> ReferenceAdded;
        public event EventHandler<ReferenceRemovedEventArgs> ReferenceRemoved;

        public event EventHandler<LinkAddedEventArgs> LinkAdded;
        public event EventHandler<LinkRemovedEventArgs> LinkRemoved;

        #endregion

        #region Private Methods

        private void AddReference(Reference r)
        {
            if (r == null)
            {
                throw new ArgumentNullException(nameof(r));
            }

            // forward
            List<Reference> forward;
            if (!_forwardReferences.TryGetValue(r.Source, out forward))
            {
                forward = new List<Reference>();
                _forwardReferences.Add(r.Source, forward);
            }
            forward.Add(r);

            // reverse
            if (_reverseReferences.TryGetValue(r.TargetMapping, out var mappingReverse))
            {
                List<Reference> reverse;
                if (!mappingReverse.TryGetValue(r.TargetId, out reverse))
                {
                    reverse = new List<Reference>();
                    mappingReverse.Add(r.TargetId, reverse);
                }
                reverse.Add(r);
            }

            if (!_deferChangedEvents)
            {
                ReferenceAdded?.Invoke(this, new ReferenceAddedEventArgs(r));
            }
        }

        private void RemoveReference(Reference r)
        {
            if (r == null)
            {
                throw new ArgumentNullException(nameof(r));
            }

            bool isRemoved = false;

            // forward
            List<Reference> forward;
            if (_forwardReferences.TryGetValue(r.Source, out forward))
            {
                isRemoved = forward.Remove(r);
                if (forward.Count == 0)
                {
                    _forwardReferences.Remove(r.Source);
                }
            }

            // reverse
            var mappingReverse = _reverseReferences[r.TargetMapping];

            List<Reference> reverse;
            if (mappingReverse.TryGetValue(r.TargetId, out reverse))
            {
                reverse.Remove(r);
                if (reverse.Count == 0)
                {
                    mappingReverse.Remove(r.TargetId);
                }
            }

            if (!_deferChangedEvents && isRemoved)
            {
                ReferenceRemoved?.Invoke(this, new ReferenceRemovedEventArgs(r));
            }
        }

        private void ClearTwoWayLinks(IReadable obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            foreach (var l in GetLinks(obj).ToList())
            {
                RemoveTwoWayLink(l);
            }
        }

        private void RemoveTwoWayLink(Link l)
        {
            if (l == null)
            {
                throw new ArgumentNullException(nameof(l));
            }

            bool isRemoved = false;

            // forward
            if (_forwardLinks.TryGetValue(l.Source, out var forward))
            {
                isRemoved = forward.Remove(l);
                if (forward.Count == 0)
                {
                    _forwardLinks.Remove(l.Source);
                }
            }

            // reverse
            if (_reverseLinks.TryGetValue(l.Target, out var reverse))
            {
                reverse.Remove(l);
                if (reverse.Count == 0)
                {
                    _reverseLinks.Remove(l.Target);
                }
            }

            if (!_deferChangedEvents && isRemoved)
            {
                LinkRemoved?.Invoke(this, new LinkRemovedEventArgs(l));
            }
        }

        private void TryAddLinkTwoWay(Reference r)
        {
            if (r == null)
            {
                throw new ArgumentNullException(nameof(r));
            }

            IReadable source = r.Source;

            if (_mappings.TryGetValue(r.TargetMapping, out var targetMapping))
            {
                foreach (IReadable target in targetMapping.GetAllObjectsWithKey(r.TargetId))
                {
                    if (target == null)
                    {
                        continue;
                    }

                    if (!r.AllowLinkToSelf && source == target)
                    {
                        continue;
                    }

                    if (GetForwardLinks(source).Any(l => l.Target == target && l.Reference == r))
                    {
                        continue;
                    }

                    Link link;
                    if (!r.IsReverse)
                    {
                        link = new Link(source, target, r);
                    }
                    else
                    {
                        link = new Link(target, source, r);
                    }

                    // add forward
                    List<Link> forward;
                    if (!_forwardLinks.TryGetValue(link.Source, out forward))
                    {
                        forward = new List<Link>();
                        _forwardLinks.Add(link.Source, forward);
                    }
                    forward.Add(link);

                    // add reverse
                    List<Link> reverse;
                    if (!_reverseLinks.TryGetValue(link.Target, out reverse))
                    {
                        reverse = new List<Link>();
                        _reverseLinks.Add(link.Target, reverse);
                    }
                    reverse.Add(link);

                    if (!_deferChangedEvents)
                    {
                        LinkAdded?.Invoke(this, new LinkAddedEventArgs(link));
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns all references from the given node
        /// </summary>
        public IEnumerable<Reference> GetForwardReferences(IReadable obj)
        {
            if (_forwardReferences.TryGetValue(obj, out var forward))
            {
                return forward;
            }

            return Enumerable.Empty<Reference>();
        }

        /// <summary>
        /// Returns all references towards the given node
        /// </summary>
        public IEnumerable<Reference> GetReverseReferences(IReadable obj)
        {
            var type = obj.GetType();

            foreach (var m in _mappings.Values)
            {
                if (m.Type.IsAssignableFrom(type))
                {
                    foreach (string id in m.ExtractIDs(obj))
                    {
                        string targetId = id?.Trim() ?? "";
                        if (targetId == "")
                        {
                            continue;
                        }

                        foreach (var r in GetReverseReferences(m.Key, targetId))
                        {
                            yield return r;
                        }
                    }
                }
            }
        }

        /// <summary> 
        /// Returns all references towards the given mapping and id 
        /// </summary> 
        public IEnumerable<Reference> GetReverseReferences(Mappings mapping, string targetId)
        {
            List<Reference> reverseReferences;
            if (_reverseReferences[mapping].TryGetValue(targetId, out reverseReferences))
            {
                foreach (var r in reverseReferences)
                {
                    yield return r;
                }
            }
        }

        public IEnumerable<Reference> GetReferences(IReadable obj)
        {
            return GetForwardReferences(obj).Concat(GetReverseReferences(obj)).Distinct();
        }

        public IEnumerable<Reference> GetAllReferences()
        {
            return _forwardReferences.Values.SelectMany(x => x);
        }

        public IEnumerable<Link> GetForwardLinks(IReadable obj)
        {
            if (_forwardLinks.TryGetValue(obj, out var forward))
            {
                return forward;
            }

            return Enumerable.Empty<Link>();
        }

        public IEnumerable<Link> GetReverseLinks(IReadable obj)
        {
            if (_reverseLinks.TryGetValue(obj, out var reverse))
            {
                return reverse;
            }

            return Enumerable.Empty<Link>();
        }

        public IEnumerable<Link> GetLinks(IReadable obj)
        {
            return GetForwardLinks(obj).Concat(GetReverseLinks(obj)).Distinct();
        }

        public IEnumerable<Link> GetAllLinks()
        {
            return _forwardLinks.Values.SelectMany(x => x);
        }

        #endregion

        #region Internal Methods

        internal void NotifyAdded(IReadable obj)
        {
            if (obj is IRelationEvaluator dr)
            {
                var references = dr.GetRelations().Where(r => !String.IsNullOrWhiteSpace(r.TargetId));
                foreach (var r in references)
                {
                    AddReference(r);
                    TryAddLinkTwoWay(r);
                }

                foreach (var r in GetReverseReferences(obj))
                {
                    TryAddLinkTwoWay(r);
                }
            }
        }

        internal void NotifyUpdated(IReadable obj)
        {
            if (obj is IRelationEvaluator dr)
            {
                List<Reference> forwardReferences = dr.GetRelations().Where(r => !String.IsNullOrWhiteSpace(r.TargetId)).ToList();

                // forward
                List<Reference> currentReferences = GetForwardReferences(obj).ToList();

                var removed = currentReferences.Except(forwardReferences).ToList();
                var added = forwardReferences.Except(currentReferences).ToList();

                foreach (Reference r in removed)
                {
                    foreach (var l in GetForwardLinks(obj).Where(l => l.Reference == r).ToList())
                    {
                        RemoveTwoWayLink(l);
                    }

                    RemoveReference(r);
                }

                foreach (Reference r in added)
                {
                    AddReference(r);
                    TryAddLinkTwoWay(r);
                }

                // reverse
                var reverseReferences = GetReverseReferences(obj).ToList();

                foreach (Link l in GetReverseLinks(obj)
                    .Where(l => !reverseReferences.Contains(l.Reference))
                    .ToList())
                {
                    RemoveTwoWayLink(l);
                }

                foreach (Reference r in reverseReferences)
                {
                    TryAddLinkTwoWay(r);
                }
            }
        }

        internal void NotifyRemoved(IReadable obj)
        {
            ClearTwoWayLinks(obj);

            foreach (var r in GetForwardReferences(obj).ToList())
            {
                RemoveReference(r);
            }
        }

        #endregion


        #region IDeferEvents Members

        public IDisposable DeferEvents()
        {
            _deferLevel++;
            _deferChangedEvents = true;
            return new DeferEventsObject(this);
        }

        private bool _deferChangedEvents = false;
        private int _deferLevel = 0;
        private void EndDeferEvents()
        {
            _deferLevel--;
            if (_deferLevel == 0)
            {
                _deferChangedEvents = false;
            }
        }
        private class DeferEventsObject : IDisposable
        {
            private readonly RelationManager _owner;

            public DeferEventsObject(RelationManager owner)
            {
                _owner = owner;
            }

            public void Dispose()
            {
                _owner.EndDeferEvents();
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _mappings.Clear();

            _forwardReferences.Clear();
            _reverseReferences.Clear();

            _forwardLinks.Clear();
            _reverseLinks.Clear();
        }

        #endregion
    }

    public class ReferenceAddedEventArgs : EventArgs
    {
        public ReferenceAddedEventArgs(Reference reference)
        {
            Reference = reference;
        }

        public Reference Reference { get; private set; }
    }

    public class ReferenceRemovedEventArgs : EventArgs
    {
        public ReferenceRemovedEventArgs(Reference reference)
        {
            Reference = reference;
        }

        public Reference Reference { get; private set; }
    }

    public class LinkAddedEventArgs : EventArgs
    {
        public LinkAddedEventArgs(Link link)
        {
            Link = link;
        }

        public Link Link { get; private set; }
    }

    public class LinkRemovedEventArgs : EventArgs
    {
        public LinkRemovedEventArgs(Link link)
        {
            Link = link;
        }

        public Link Link { get; private set; }
    }
}
