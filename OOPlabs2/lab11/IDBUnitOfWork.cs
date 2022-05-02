using System;

namespace lab11
{
    public interface IDBUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
