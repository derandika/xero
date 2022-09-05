using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Xero.Repository.Interface
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);

        

    }
}
