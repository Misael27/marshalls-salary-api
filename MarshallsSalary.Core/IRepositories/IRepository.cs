using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MarshallsSalary.Core.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(string id);
        TEntity Get(Guid? id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        int Count();
        void Set(TEntity identity);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
