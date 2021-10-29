using System;
using System.Collections;
using System.Collections.Generic;

namespace lab10
{
    public class ObservableDictionary<T, TKey, TValue> : IDictionary<TKey,TValue>
        where T : IDictionary<TKey, TValue>
    {
        public ObservableDictionary(T dictionary)
        {
            Dictionary = dictionary;
        }

        public delegate void ChangeHandler();
        public event ChangeHandler OnChange;
        private T Dictionary;

        public ICollection<TKey> Keys => Dictionary.Keys;

        public ICollection<TValue> Values => Dictionary.Values;

        public int Count => Dictionary.Count;

        public bool IsReadOnly => Dictionary.IsReadOnly;

        public TValue this[TKey key] { get => Dictionary[key]; set => Dictionary[key] = value; }

        public bool ContainsKey(TKey key)
        {
            return Dictionary.ContainsKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            OnChange.Invoke();
            Dictionary.Add(key, value);
        }

        public bool Remove(TKey key)
        {
            OnChange.Invoke();
            return Dictionary.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return Dictionary.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            OnChange.Invoke();
            Dictionary.Add(item);
        }

        public void Clear()
        {
            Dictionary.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Dictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Dictionary.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            OnChange.Invoke();
            return Dictionary.Remove(item);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }
    }
}
