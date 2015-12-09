using System;
using System.Collections;
using System.Collections.Generic;
using Raunstrup.Data.MsSql.Mappers;

namespace Raunstrup.Data.MsSql.Proxies
{
    abstract class ListProxy<T> : IList<T>
    {
        private readonly Lazy<IList<T>> _real;

        protected ListProxy(Func<IList<T>> creator)
        {
            _real = new Lazy<IList<T>>(creator);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _real.Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _real.Value.Add(item);
        }

        public void Clear()
        {
            _real.Value.Clear();
        }

        public bool Contains(T item)
        {
            return _real.Value.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _real.Value.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _real.Value.Remove(item);
        }

        public int Count
        {
            get { return _real.Value.Count; }
        }

        public bool IsReadOnly
        {
            get { return _real.Value.IsReadOnly; }
        }

        public int IndexOf(T item)
        {
            return _real.Value.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _real.Value.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _real.Value.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return _real.Value[index]; }
            set { _real.Value[index] = value; }
        }
    }
}
