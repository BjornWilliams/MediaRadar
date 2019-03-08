using Business.Contracts.Services;
using Data.Contracts;
using Data.Transfer.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    /// <summary>
    /// Provides a set of methods for accessing the publication details. 
    /// </summary>
    public class PublicationAdActivityService : IPublicationAdActivityService
    {
        #region Fields
        private readonly IPublicationAdActivityRepository repository;
        #endregion

        #region Constructors
        public PublicationAdActivityService(IPublicationAdActivityRepository repository)
        {
            this.repository = repository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets a Boolean indicating if the table is populated with data.
        /// </summary>
        /// <returns>True if it contains, Otherwise False.</returns>
        public bool ContainsData() => repository.ContainsData();

        /// <summary>
        /// Gets a list of brands that have at least 2 ad pages, and are considered part of the “Toiletries & Cosmetics > Hair Care” product category.
        /// </summary>
        /// <returns>A collection of <seealso cref="BrandDto"/> objects.</returns>
        public IEnumerable<BrandDto> GetBrands() => repository.GetBrandsWith(2, "Toiletries & Cosmetics > Hair Care");

        /// <summary>
        /// Gets all the publication data downloaded.
        /// </summary>
        /// <returns>A collection of <seealso cref="PublicationAdActivityDto"/> objects.</returns>
        public IEnumerable<PublicationAdActivityDto> GetPublicationAdActivities() => repository.GetAllPublicationAdActivities();

        /// <summary>
        /// Gets top five Parent Companies by number of pages, then estimated spend during a single month.
        /// </summary>
        /// <returns>A collection of <seealso cref="ParentCompanyDto"/> objects.</returns>
        public IEnumerable<ParentCompanyDto> GetTopParentCompaines() => repository.GetTopParentCompaines(5);

        /// <summary>
        /// Gets the top five Product Categories by estimated spend.
        /// </summary>
        /// <returns>A collection of <seealso cref="ProductCategoryDto"/> objects.</returns>
        public IEnumerable<ProductCategoryDto> GetTopProductCategories() => repository.GetTopProductCategories(5);
        #endregion
    }
}
