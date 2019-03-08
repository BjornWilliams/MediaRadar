using Data.Contracts;
using Data.Models;
using Data.Transfer.Objects;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Store.Repositories
{
    /// <summary>
    /// Represents the implementation of the <seealso cref="IPublicationAdActivityRepository"/> contract.
    /// </summary>
    public class PublicationAdActivityRepository : BaseRepository<PublicationAdActivity>, IPublicationAdActivityRepository
    {
        #region Constructors
        public PublicationAdActivityRepository(DbContext context) : base(context) { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the <seealso cref="MediaContext"/> converted from the generic DbContext.
        /// </summary>
        public MediaContext MediaContext => Context as MediaContext;
        #endregion

        #region Methods
        /// <summary>
        /// Gets a Boolean indicating if the table is populated with data.
        /// </summary>
        /// <returns>True if it contains, Otherwise False.</returns>
        public bool ContainsData()
        {
            var result = MediaContext.Publications.Count();

            return result > 0;
        }

        /// <summary>
        /// Gets all the publication data downloaded.
        /// </summary>
        /// <returns>A collection of <seealso cref="PublicationAdActivityDto"/> objects.</returns>
        public IEnumerable<PublicationAdActivityDto> GetAllPublicationAdActivities()
        {
            return GetAll()
                    .OrderBy(model => model.BrandName)
                    .Select(model => new PublicationAdActivityDto
                    {
                        AdPages = model.AdPages,
                        BrandId = model.BrandId,
                        BrandName = model.BrandName,
                        EstPrintSpend = model.EstPrintSpend,
                        Month = model.Month,
                        ParentCompany = model.ParentCompany,
                        ParentCompanyId = model.ParentCompanyId,
                        ProductCategory = model.ProductCategory,
                        PublicationId = model.PublicationId,
                        PublicationName = model.PublicationName
                    })
                    .ToList();
        }

        /// <summary>
        /// Gets a list of brands that match the given number of AdPages and contains the given category. 
        /// </summary>
        /// <param name="numberOfPages">The minimum number of adPages.</param>
        /// <param name="category">The name of the category</param>
        /// <returns>A collection of <seealso cref="BrandDto"/> objects.</returns>
        public IEnumerable<BrandDto> GetBrandsWith(decimal numberOfPages, string category)
        {
            return MediaContext.Publications
                            .GroupBy(model => new { model.BrandId, model.BrandName, model.ProductCategory }, (r, g) => new { r.BrandId, r.BrandName, r.ProductCategory, AdPages = g.Sum(model => model.AdPages) })
                            .Where(model => model.AdPages >= numberOfPages && model.ProductCategory.Contains(category))
                            .OrderBy(model => model.BrandName)
                            .ToList()
                            .Select(model => new BrandDto
                            {
                                AdPages = model.AdPages,
                                BrandId = model.BrandId,
                                BrandName = model.BrandName,
                                ProductCategory = model.ProductCategory
                            });
        }

        /// <summary>
        /// Gets top N Parent Companies by number of pages, then estimated spend during a single month.
        /// </summary>
        /// <param name="count">The maximum number of Companies to get.</param>
        /// <returns>A collection of <seealso cref="ParentCompanyDto"/> objects.</returns>
        public IEnumerable<ParentCompanyDto> GetTopParentCompaines(int count)
        {
            return MediaContext.Publications
                .GroupBy(model => new { model.ParentCompanyId, model.ParentCompany, model.PublicationId, model.PublicationName, model.Month }, (row, group) => new { row.Month, row.ParentCompany, row.ParentCompanyId, row.PublicationId, row.PublicationName, AdPages = group.Sum(model => model.AdPages), EstPrintSpend = group.Sum(model => model.EstPrintSpend) })
                .OrderByDescending(model => model.AdPages)
                .ThenByDescending(model => model.EstPrintSpend)
                .ThenBy(model => model.ParentCompany)
                .Take(count)
                .ToList()
                .Select(model => new ParentCompanyDto
                {
                    AdPages = model.AdPages,
                    EstPrintSpend = model.EstPrintSpend,
                    Month = model.Month,
                    ParentCompany = model.ParentCompany,
                    ParentCompanyId = model.ParentCompanyId,
                    PublicationId = model.PublicationId,
                    PublicationName = model.PublicationName
                });
        }

        /// <summary>
        /// Gets the top N Product Categories by estimated spend.
        /// </summary>
        /// <param name="count">The maximum number of product categories to get.</param>
        /// <returns>A collection of <seealso cref="ProductCategoryDto"/> objects.</returns>
        public IEnumerable<ProductCategoryDto> GetTopProductCategories(int count)
        {
            return MediaContext.Publications
                     .GroupBy(model => new { model.ProductCategory, model.AdPages }, (row, group) => new { row.AdPages, row.ProductCategory, EstPrintSpend = group.Sum(model => model.EstPrintSpend) })
                     .OrderByDescending(model => model.EstPrintSpend)
                     .ThenByDescending(model => model.AdPages)
                     .ThenBy(model => model.ProductCategory)
                     .Take(count)
                     .ToList()
                     .Select(model => new ProductCategoryDto
                     {
                         ProductCategory = model.ProductCategory,
                         EstPrintSpend = model.EstPrintSpend,
                         AdPages = model.AdPages
                     });
        }
        #endregion
    }
}
