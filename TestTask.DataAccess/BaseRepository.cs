using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TestTask.DataAccess
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly TestTaskDbContext _dbContext;

        protected DbSet<T> DbSet;

        public BaseRepository(TestTaskDbContext context)
        {
            _dbContext = context;
            DbSet = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public T Get(Expression<Func<T, bool>> whereCondition)
        {
            return DbSet.Where(whereCondition).FirstOrDefault();
        }

        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = DbSet.Find(id);

            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }

        public bool Any(Expression<Func<T, bool>> whereCondition)
        {
            return DbSet.Any(whereCondition);
        }
    }
}
