using Data.Contracts;
using Data.Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Store
{
    /// <summary>
    /// Implements the <seealso cref="IUnitOfWork"/> interface.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly MediaContext mediaContext;
        #endregion

        #region Constructors
        public UnitOfWork(MediaContext mediaContext, IPublicationAdActivityRepository publications)
        {
            this.mediaContext = mediaContext;
            Publications = publications;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the <seealso cref="IPublicationAdActivityRepository"/> repository.
        /// </summary>
        public IPublicationAdActivityRepository Publications { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Calls the protected Dispose method.
        /// </summary>
        public void Dispose()
        {
            mediaContext.Dispose();
        }

        /// <summary>
        /// Persist all changes from dbContext to the database.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        public int SaveChanges() => mediaContext.SaveChanges();

        /// <summary>
        /// Persist all changes from dbContext to the database Asynchronously.
        /// </summary>
        /// <returns>A task with the number of rows affected.</returns>
        public async Task<int> SaveChangesAsync() => await mediaContext.SaveChangesAsync();
        #endregion
    }
}
