namespace Skyline.DataMiner.CICD.Models.Protocol.Models.Read.Linking
{
    using System;
    using System.Collections.Generic;

    public class ManyToManyMapping<Ta, Tb>
    {
        #region Private Fields

        private readonly Dictionary<Ta, IList<Tb>> _forwardMapping = new Dictionary<Ta, IList<Tb>>();
        private readonly Dictionary<Tb, IList<Ta>> _reverseMapping = new Dictionary<Tb, IList<Ta>>();

        #endregion

        #region Public Properties

        public IDictionary<Ta, IList<Tb>> Forward
        {
            get { return _forwardMapping; }
        }
        public IDictionary<Tb, IList<Ta>> Reverse
        {
            get { return _reverseMapping; }
        }
        public int Count
        {
            get { return _forwardMapping.Count; }
        }

        #endregion

        #region Public Methods

        public void Add(Ta a, Tb b)
        {
            if (a == null)
                throw new ArgumentNullException("a", "Key cannot be null");

            if (b == null)
                throw new ArgumentNullException("b", "Key cannot be null");

            if (!_forwardMapping.TryGetValue(a, out var listA))
            {
                listA = new List<Tb>() { b };
                _forwardMapping.Add(a, listA);
            }
            else
            {
                if (listA.Contains(b))
                    throw new ArgumentException("Item already exists", "b");
                listA.Add(b);
            }

            if (!_reverseMapping.TryGetValue(b, out var listB))
            {
                listB = new List<Ta>() { a };
                _reverseMapping.Add(b, listB);
            }
            else
            {
                if (listB.Contains(a))
                    throw new ArgumentException("Item already exists", "a");
                listB.Add(a);
            }

        }

        public void Remove(Ta a, Tb b)
        {
            if (a == null)
                throw new ArgumentNullException("a", "Key cannot be null");

            if (b == null)
                throw new ArgumentNullException("b", "Key cannot be null");

            if (!_forwardMapping.TryGetValue(a, out var listA))
                throw new ArgumentException("Key does not exist", "a");

            if (!_reverseMapping.TryGetValue(b, out var listB))
                throw new ArgumentException("Key does not exist", "b");

            listA.Remove(b);
            if (listA.Count == 0) _forwardMapping.Remove(a);

            listB.Remove(a);
            if (listB.Count == 0) _reverseMapping.Remove(b);
        }

        public void RemoveForward(Ta a)
        {
            if (a == null)
                throw new ArgumentNullException("a", "Key cannot be null");

            if (!_forwardMapping.TryGetValue(a, out var b))
                throw new ArgumentException("Key does not exist", "a");

            _forwardMapping.Remove(a);

            foreach (var x in b)
            {
                var list = _reverseMapping[x];
                list.Remove(a);
                if (list.Count == 0) _reverseMapping.Remove(x);
            }
        }

        public void RemoveReverse(Tb b)
        {
            if (b == null)
                throw new ArgumentNullException("b", "Key cannot be null");

            if (!_reverseMapping.TryGetValue(b, out var a))
                throw new ArgumentException("Key does not exist", "b");

            foreach (var x in a)
            {
                var list = _forwardMapping[x];
                list.Remove(b);
                if (list.Count == 0) _forwardMapping.Remove(x);
            }

            _reverseMapping.Remove(b);
        }

        public void Clear()
        {
            _forwardMapping.Clear();
            _reverseMapping.Clear();
        }

        public bool Contains(Ta a, Tb b)
        {
            if (a == null)
                throw new ArgumentNullException("a", "Key cannot be null");

            if (b == null)
                throw new ArgumentNullException("b", "Key cannot be null");

            if (!_forwardMapping.TryGetValue(a, out var list))
                return false;

            return list.Contains(b);
        }

        #endregion
    }
}
