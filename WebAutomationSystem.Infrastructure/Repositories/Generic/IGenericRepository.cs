using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebAutomationSystem.Infrastructure.Repositories.Generic
{
    public interface IGenericRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Remove(object id);
        T Get(object id);
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
