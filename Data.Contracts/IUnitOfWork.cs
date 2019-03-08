using System;
using System.Threading.Tasks;

namespace Data.Contracts
{
    /// <summary>
    /// Represents a collection of repository that can be part of a unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the <seealso cref="IPublicationAdActivityRepository"/> repository.
        /// </summary>
        IPublicationAdActivityRepository Publications { get; }

        /// <summary>
        /// Persist all changes from dbContext to the database.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        int SaveChanges();

        /// <summary>
        /// Persist all changes from dbContext to the database Asynchronously.
        /// </summary>
        /// <returns>A task with the number of rows affected.</returns>
        Task<int> SaveChangesAsync();
    }
}
