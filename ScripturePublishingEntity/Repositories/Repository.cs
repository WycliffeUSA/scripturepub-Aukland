using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ScripturePublishingEntity.Repositories
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        protected TContext Context { get; private set; }
        private readonly DbSet<TEntity> _dbSet;

        protected Repository(TContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Sets the includes.  Available for subclasses of this repository to override.
        /// By default, does not apply any Includes.
        /// </summary>
        /// <param name="queryable">The queryable.</param>
        /// <returns></returns>
        protected virtual IQueryable<TEntity> GetIncludes(IQueryable<TEntity> queryable)
        {
            return queryable;
        }

        /// <summary>
        /// Generic Get method to retrieve entities.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="skip">Bypass the provided number of elements in the query result, and return the remaining.</param>
        /// <param name="take">Return this number of contiguous elements from the query result.</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null
            )
        {

            var query = GetQueryable(filter);


            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Generic Get method to retrieve entities with an additional include for (virtual) properties.
        /// </summary>
        /// <param name="filter">The filter to be used during the query for results.</param>
        /// <param name="orderBy">The predicate determining what order the results should be presented in.</param>
        /// <param name="include">The predicate determining which additional properties should be included during the query.</param>
        /// <param name="skip">The number of results to skip from the original result set.</param>
        /// <param name="take">The number of results to take from the original result set.</param>
        /// <returns></returns>
        protected virtual IEnumerable<TEntity> GetWithInclude(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null
            )
        {
            var query = GetQueryable(filter);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter)
        {
            return GetQueryable(filter).Count();
        }

        protected virtual IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = GetIncludes(query);

            return query;
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}