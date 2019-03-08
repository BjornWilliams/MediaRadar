using Data.Models;
using Data.Transfer.Objects;
using System.Collections.Generic;

namespace Data.Contracts
{
    /// <summary>
    /// Repository contact for the Publication Ad Activity repository.
    /// </summary>
    public interface IPublicationAdActivityRepository : IRepository<PublicationAdActivity>
    {
        /// <summary>
        /// Gets a Boolean indicating if the table is populated with data.
        /// </summary>
        /// <returns>True if it contains, Otherwise False.</returns>
        bool ContainsData();

        /// <summary>
        /// Gets all the publication data downloaded.
        /// </summary>
        /// <returns>A collection of <seealso cref="PublicationAdActivityDto"/> objects.</returns>
        IEnumerable<PublicationAdActivityDto> GetAllPublicationAdActivities();

        /// <summary>
        /// Gets a list of brands that match the given number of AdPages and contains the given category. 
        /// </summary>
        /// <param name="numberOfPages">The minimum number of adPages.</param>
        /// <param name="category">The name of the category</param>
        /// <returns>A collection of <seealso cref="BrandDto"/> objects.</returns>
        IEnumerable<BrandDto> GetBrandsWith(decimal numberOfPages, string category);

        /// <summary>
        /// Gets the top N Product Categories by estimated spend.
        /// </summary>
        /// <param name="count">The maximum number of product categories to get.</param>
        /// <returns>A collection of <seealso cref="ProductCategoryDto"/> objects.</returns>
        IEnumerable<ProductCategoryDto> GetTopProductCategories(int count);

        /// <summary>
        /// Gets top N Parent Companies by number of pages, then estimated spend during a single month.
        /// </summary>
        /// <param name="count">The maximum number of Companies to get.</param>
        /// <returns>A collection of <seealso cref="ParentCompanyDto"/> objects.</returns>
        IEnumerable<ParentCompanyDto> GetTopParentCompaines(int count);       
    }
}
