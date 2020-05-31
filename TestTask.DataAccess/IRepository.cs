using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestTask.DataAccess
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> whereCondition);
        void Create(T item);
        void Update(T item);
        bool Any(Expression<Func<T, bool>> whereCondition);
    }
}
