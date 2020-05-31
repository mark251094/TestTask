using System;

namespace TestTask.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestTaskDbContext _dbContext;
        private UserRepository _userRepository;
        private LogRepository _logRepository;

        public UnitOfWork(TestTaskDbContext db)
        {
            _dbContext = db;
        }

        public UserRepository Users
        {
            get
            {
                return _userRepository ??= new UserRepository(_dbContext);
            }
        }

        public LogRepository Logs
        {
            get
            {
                return _logRepository ??= new LogRepository(_dbContext);
            }
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
