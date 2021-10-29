using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class ObservableCollection<T,U> : ICollection<U> 
        where T : ICollection<U>
    {
        public ObservableCollection(T collection)
        {
            Collection = collection;
        }
        public delegate void ChangeHandler();
        public event ChangeHandler OnChange;

        private T Collection;
        public int Count => Collection.Count;

        public bool IsReadOnly => Collection.IsReadOnly;

        public void Add(U item)
        {
            Collection.Add(item);
            OnChange.Invoke();
        }

        public void Clear()
        {
            Collection.Clear();
            OnChange.Invoke();
        }

        public bool Contains(U item)
        {
            return Collection.Contains(item);
        }

        public void CopyTo(U[] array, int arrayIndex)
        {
            Collection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<U> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        public bool Remove(U item)
        {
            OnChange.Invoke();
            return Collection.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
    }
}
