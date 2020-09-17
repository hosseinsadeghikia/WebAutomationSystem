using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebAutomationSystem.Infrastructure.DbContexts;

namespace WebAutomationSystem.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        protected GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual T Add(T entity)
        {
            return _context
                .Add(entity)
                .Entity;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                .AsQueryable()
                .Where(predicate).ToList();
        }

        public virtual T Remove(object id)
        {
            var entity = _context.Find<T>(id);
            if (entity == null)
            {
                return null;
            }
            _context.Set<T>().Remove(entity);
            return entity;
        }

        public virtual T Get(object id)
        {
            return _context.Find<T>(id);
        }

        public virtual IEnumerable<T> All()
        {
            return _context.Set<T>()
                .AsQueryable()
                .ToList();
        }

        public virtual T Update(T entity)
        {
            return _context.Update(entity)
                .Entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
