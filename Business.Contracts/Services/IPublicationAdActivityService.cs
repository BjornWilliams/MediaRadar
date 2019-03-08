using Data.Transfer.Objects;
using System.Collections.Generic;

namespace Business.Contracts.Services
{
    /// <summary>
    /// Service contract for the Publication Ad Activity Service.
    /// </summary>
    public interface IPublicationAdActivityService
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
        IEnumerable<PublicationAdActivityDto> GetPublicationAdActivities();

        /// <summary>
        /// Gets a list of brands that have at least 2 ad pages, and are considered part of the “Toiletries & Cosmetics > Hair Care” product category.
        /// </summary>
        /// <returns>A collection of <seealso cref="BrandDto"/> objects.</returns>
        IEnumerable<BrandDto> GetBrands();

        /// <summary>
        /// Gets the top five Product Categories by estimated spend.
        /// </summary>
        /// <returns>A collection of <seealso cref="ProductCategoryDto"/> objects.</returns>
        IEnumerable<ProductCategoryDto> GetTopProductCategories();

        /// <summary>
        /// Gets top five Parent Companies by number of pages, then estimated spend during a single month.
        /// </summary>
        /// <returns>A collection of <seealso cref="ParentCompanyDto"/> objects.</returns>
        IEnumerable<ParentCompanyDto> GetTopParentCompaines();
    }
}
