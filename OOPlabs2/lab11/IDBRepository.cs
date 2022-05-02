using System;

namespace lab11
{
    public interface IDBRepository<T>
    {
        void Add(T item);
        void Update(Func<T, bool> func, Func<int, T> item);
        bool Remove(Func<T, bool> func);
    }
}
