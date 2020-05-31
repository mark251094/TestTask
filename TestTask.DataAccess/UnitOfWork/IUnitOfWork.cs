using System;

namespace TestTask.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        UserRepository Users { get; }
        LogRepository Logs { get; }

        bool Save();
    }
}
