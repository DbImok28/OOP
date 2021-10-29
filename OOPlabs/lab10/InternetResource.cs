using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class InternetResource<T> : IList<T>
    {
        public InternetResource()
        {
        }
        public InternetResource(params T[] pages)
        {
            Pages.AddRange(pages);
        }
        public List<T> Pages = new List<T>();
        public T this[int index] { get => Pages[index]; set => Pages[index] = value; }

        public int Count => Pages.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            Pages.Add(item);
        }

        public void Clear()
        {
            Pages.Clear();
        }

        public bool Contains(T item)
        {
            return Pages.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Pages.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Pages.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return Pages.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            Pages.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return Pages.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Pages.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Pages.GetEnumerator();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this)
            {
                sb.Append(item.ToString());
                sb.Append(' ');
            }
            return sb.ToString();
        }
    }
}
