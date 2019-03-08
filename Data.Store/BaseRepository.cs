using Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Store
{
    /// <summary>
    /// Provides base implementation of the <seealso cref="IRepository{TEntity}"/> interface. 
    /// </summary>
    /// <typeparam name="TEntity">The type of model handled by repository.</typeparam>
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields
        protected readonly DbContext Context;
        #endregion

        #region MyRegion
        public BaseRepository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add the given entity to the database.
        /// </summary>
        /// <param name="entity">The new entity to save.</param>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Add the given entities to the database.
        /// </summary>
        /// <param name="entities">The list of entities to save.</param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        /// Performs a lookup using the given <seealso cref="Expression"/>
        /// </summary>
        /// <param name="predicate">The filter expression to be used during search.</param>
        /// <returns>A collection of the specified entities.</returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// Get the entity associated with the given primary key.
        /// </summary>
        /// <param name="id">The primary key of the entity to get.</param>
        /// <returns>he entity associated to the given key.</returns>
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Gets all entities in the database.
        /// </summary>
        /// <returns>A collection of the specified entities.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Gets all entities in the database Asynchronously.
        /// </summary>
        /// <returns>A Task containing a collection of the specified entities.</returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Get the entity associated with the given primary key Asynchronously.
        /// </summary>
        /// <param name="id">The primary key of the entity to get.</param>
        /// <returns>A Task containing entity associated to the given key.</returns>
        public async Task<TEntity> GetAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Deletes the given entity from the database.
        /// </summary>
        /// <param name="entity">The existing entity to delete.</param>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Deletes all the given entities from the database.
        /// </summary>
        /// <param name="entities">The existing entities to delete.</param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
        #endregion
    }
}
