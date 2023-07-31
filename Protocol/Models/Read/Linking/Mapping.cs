namespace Skyline.DataMiner.CICD.Models.Protocol.Read.Linking
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Skyline.DataMiner.CICD.Common.Events;
    using MappingEntry = System.Collections.Generic.KeyValuePair<string, IReadable>;
    using Skyline.DataMiner.CICD.Models.Protocol.Models.Read.Linking;

    public class Mapping :
        IList<MappingEntry>,
        IDictionary<string, IReadable>,
        IList,
        IDeferEvents
    {
        #region Constructors

        private Mapping(Mappings key, Type type, Func<IReadable, IEnumerable<string>> extractIDs)
        {
            Key = key;
            Type = type ?? throw new ArgumentNullException(nameof(type));
            ExtractIDs = extractIDs ?? throw new ArgumentNullException(nameof(extractIDs));
        }

        public static Mapping Create<T>(Mappings key, Func<T, string> extractID)
            where T : IReadable
        {
            Type type = typeof(T);
            IEnumerable<string> extractIDs(IReadable x) => new[] { extractID((T)x) };

            return new Mapping(key, type, extractIDs);
        }

        public static Mapping Create<T>(Mappings key, Func<T, IEnumerable<string>> extactIDs)
            where T : IReadable
        {
            Type type = typeof(T);
            IEnumerable<string> extractIDs2(IReadable x) => extactIDs((T)x);

            return new Mapping(key, type, extractIDs2);
        }

        #endregion

        #region Private Fields

        private readonly ManyToManyMapping<string, IReadable> _map = new ManyToManyMapping<string, IReadable>();
        private readonly List<MappingEntry> _list = new List<MappingEntry>();

        #endregion

        #region Public Properties

        /// <summary>
        /// The key for this mapping
        /// </summary>
        public Mappings Key { get; private set; }

        /// <summary>
        /// Contains the <see cref="Type"/> for items in this mapping.
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Contains the method to extract the unique ID of a IReadable (e.g. return the value of the "id" attribute).
        /// </summary>
        public Func<IReadable, IEnumerable<string>> ExtractIDs { get; private set; }
        
        #endregion

        #region Private Methods

        private void Internal_TryUpdate(IReadable value, IEnumerable<string> newkeys)
        {
            if (value == null)
                return;

            var newKeysList = newkeys.ToList();

            if (_map.Reverse.TryGetValue(value, out var keys))
            {
                Internal_TryRemoveReverse(value, keys.Except(newKeysList).ToList());
                Internal_TryAddForward(value, newkeys);
            }
        }

        private bool Internal_TryAddForward(IReadable value, IEnumerable<string> keys)
        {
            bool result = false;

            foreach (var key in keys)
            {
                if (key != null && !_map.Contains(key, value))
                {
                    var newEntry = new MappingEntry(key, value);

                    _map.Add(key, value);
                    _list.Add(newEntry);

                    if (!_deferChangedEvents)
                    {
                        RaiseEvent(ObjectAdded, new ObjectAddedEventArgs(key, value));
                    }

                    result = true;
                }
            }

            return result;
        }

        private bool Internal_TryRemoveReverse(IReadable value)
        {
            if (value != null && _map.Reverse.TryGetValue(value, out var keys))
            {
                _map.RemoveReverse(value);

                foreach (var key in keys)
                {
                    var oldEntry = new MappingEntry(key, value);
                    _list.Remove(oldEntry);

                    if (!_deferChangedEvents)
                    {
                        RaiseEvent(ObjectRemoved, new ObjectRemovedEventArgs(key, value));
                    }
                }

                return true;
            }
            return false;
        }

        private bool Internal_TryRemoveReverse(IReadable value, IEnumerable<string> keys)
        {
            bool result = false;

            if (value != null)
            {
                foreach (var key in keys)
                {
                    if (key != null && _map.Contains(key, value))
                    {
                        _map.Remove(key, value);

                        var oldEntry = new MappingEntry(key, value);
                        _list.Remove(oldEntry);

                        if (!_deferChangedEvents)
                        {
                            RaiseEvent(ObjectRemoved, new ObjectRemovedEventArgs(key, value));
                        }

                        result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Raises an event derived from the basic EventHandler.
        /// </summary>
        private void RaiseEvent<T>(EventHandler<T> handler, T args) where T : EventArgs
        {
            if (handler != null)
                handler(this, args);
        }

        #endregion

        #region Public Methods

        public void TryAddObject(IReadable obj)
        {
            var keys = ExtractIDs(obj);
            Internal_TryAddForward(obj, keys);
        }
        public void TryRemoveObject(IReadable obj)
        {
            Internal_TryRemoveReverse(obj);
        }
        public void TryUpdateObject(IReadable obj)
        {
            var keys = ExtractIDs(obj);
            Internal_TryUpdate(obj, keys);
        }

        /// <summary>
        /// Returns all objects with the given key, even duplicates.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<IReadable> GetAllObjectsWithKey(string key)
        {
            if (_map.Forward.TryGetValue(key, out var list))
            {
                foreach (var x in list)
                    yield return x;
            }
        }

        #endregion

        #region Events

        public event EventHandler<ObjectAddedEventArgs> ObjectAdded;
        public event EventHandler<ObjectRemovedEventArgs> ObjectRemoved;

        #endregion


        #region Shared Interface Members

        public bool IsReadOnly
        {
            get { return true; }
        }
        public int Count
        {
            get { return _list.Count; }
        }

        public int Add(object value)
        {
            throw new AccessViolationException("Read-Only");
        }
        public void Add(MappingEntry item)
        {
            throw new AccessViolationException("Read-Only");
        }
        public void Add(string key, IReadable value)
        {
            throw new AccessViolationException("Read-Only");
        }
        public void Insert(int index, object value)
        {
            throw new AccessViolationException("Read-Only");
        }
        public void Insert(int index, MappingEntry item)
        {
            throw new AccessViolationException("Read-Only");
        }
        public void Remove(object value)
        {
            throw new AccessViolationException("Read-Only");
        }
        public bool Remove(MappingEntry item)
        {
            throw new AccessViolationException("Read-Only");
        }
        public bool Remove(string key)
        {
            throw new AccessViolationException("Read-Only");
        }
        public void RemoveAt(int index)
        {
            throw new AccessViolationException("Read-Only");
        }
        public void Clear()
        {
            throw new AccessViolationException("Read-Only");
        }

        public bool Contains(object value)
        {
            return Contains((MappingEntry)value);
        }
        public bool Contains(MappingEntry item)
        {
            if (item.Key == null)
                return false;

            IReadable value = null;
            if (TryGetValue(item.Key, out value))
                return value == item.Value;

            return false;
        }
        public int IndexOf(object value)
        {
            return _list.IndexOf((MappingEntry)value);
        }
        public int IndexOf(MappingEntry item)
        {
            return _list.IndexOf(item);
        }
        public void CopyTo(Array array, int index)
        {
            (_list as IList).CopyTo(array, index);
        }
        public void CopyTo(MappingEntry[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
        public IEnumerator<MappingEntry> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        //public IEnumerator GetEnumerator()
        //{
        //    return _list.GetEnumerator();
        //}
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        object IList.this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                throw new AccessViolationException("Read-Only");
            }
        }

        MappingEntry IList<MappingEntry>.this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                throw new AccessViolationException("Read-Only");
            }
        }

        #endregion

        #region IDictionary

        public ICollection<string> Keys
        {
            get { return _map.Forward.Keys; }
        }
        public ICollection<IReadable> Values
        {
            get { return _map.Forward.Values.SelectMany(x => x).ToList(); }
        }

        public bool ContainsKey(string key)
        {
            return _map.Forward.ContainsKey(key);
        }

        public bool TryGetValue(string key, out IReadable value)
        {
            if (_map.Forward.TryGetValue(key, out var list))
            {
                if (list.Count > 0)
                {
                    value = list[0];
                    return true;
                }
            }

            value = null;
            return false;
        }

        public IReadable this[string key]
        {
            get
            {
                TryGetValue(key, out var v);
                return v;
            }
            set
            {
                throw new AccessViolationException("Read-Only");
            }
        }

        #endregion

        #region IList

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsSynchronized
        {
            get { return (_list as IList).IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return (_list as IList).SyncRoot; }
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
                _deferChangedEvents = false;
        }
        private class DeferEventsObject : IDisposable
        {
            private readonly Mapping _owner;

            public DeferEventsObject(Mapping owner)
            {
                _owner = owner;
            }

            public void Dispose()
            {
                _owner.EndDeferEvents();
            }
        }

        #endregion
    }

    public class ObjectAddedEventArgs : EventArgs
    {
        public ObjectAddedEventArgs(string key, IReadable obj)
        {
            Key = key;
            Object = obj;
        }

        public string Key { get; private set; }
        public IReadable Object { get; private set; }
    }

    public class ObjectRemovedEventArgs : EventArgs
    {
        public ObjectRemovedEventArgs(string key, IReadable obj)
        {
            Key = key;
            Object = obj;
        }

        public string Key { get; private set; }
        public IReadable Object { get; private set; }
    }
}
