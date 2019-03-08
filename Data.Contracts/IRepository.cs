using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Contracts
{
    /// <summary>
    /// Represents a collection of functionality that can be performed on the data store for the given Entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of model handled by repository.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add the given entity to the database.
        /// </summary>
        /// <param name="entity">The new entity to save.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Add the given entities to the database.
        /// </summary>
        /// <param name="entities">The list of entities to save.</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Gets all entities in the database.
        /// </summary>
        /// <returns>A collection of the specified entities.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets all entities in the database Asynchronously.
        /// </summary>
        /// <returns>A Task containing a collection of the specified entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Get the entity associated with the given primary key.
        /// </summary>
        /// <param name="id">The primary key of the entity to get.</param>
        /// <returns>he entity associated to the given key.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Get the entity associated with the given primary key Asynchronously.
        /// </summary>
        /// <param name="id">The primary key of the entity to get.</param>
        /// <returns>A Task containing entity associated to the given key.</returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Performs a lookup using the given <seealso cref="Expression"/>
        /// </summary>
        /// <param name="predicate">The filter expression to be used during search.</param>
        /// <returns>A collection of the specified entities.</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Deletes the given entity from the database.
        /// </summary>
        /// <param name="entity">The existing entity to delete.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Deletes all the given entities from the database.
        /// </summary>
        /// <param name="entities">The existing entities to delete.</param>
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
