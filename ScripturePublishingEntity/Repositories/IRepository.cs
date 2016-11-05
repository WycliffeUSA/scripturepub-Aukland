using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ScripturePublishingEntity.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Generic Get method to retrieve entiteis.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,
                IOrderedQueryable<T>> orderBy = null,
            int? skip = null,
            int? take = null
            );

        int Count(Expression<Func<T, bool>> filter);

        T GetById(object id);

        void Add(T entity);

        void Delete(T entityToDelete);

        void Update(T entityToUpdate);

    }
}
