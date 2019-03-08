using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class PublicationAdActivity
    {
        #region Properties
        /// <summary>
        /// Gets or Sets the unique key value for the record.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the number of pages purchased by the advertiser.
        /// </summary>
        public decimal AdPages { get; set; }

        /// <summary>
        /// Gets or Sets a unique key for the advertised brand.
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Gets or Sets the name of the advertised brand.
        /// </summary>
        [MaxLength(500)]
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or Sets the dollar amount spent by the advertiser to purchase the number of pages.
        /// </summary>
        public decimal EstPrintSpend { get; set; }

        /// <summary>
        /// Gets or Sets a unique key for the company that owns the advertised brand.
        /// </summary>
        public int ParentCompanyId { get; set; }

        /// <summary>
        /// Gets or Sets the name of the company that owns the advertised brand.
        /// </summary>
        [MaxLength(500)]
        public string ParentCompany { get; set; }

        /// <summary>
        /// Gets or Sets the category describing the type of advertised brand.
        /// </summary>
        public string ProductCategory { get; set; }

        /// <summary>
        /// Gets or Sets a unique key for the magazine or newspaper.
        /// </summary>
        public int PublicationId { get; set; }

        /// <summary>
        /// Gets or Sets the name of the magazine or newspaper.
        /// </summary>
        [MaxLength(500)]
        public string PublicationName { get; set; }

        /// <summary>
        /// Gets or Sets date of the record.
        /// </summary>
        public DateTime Month { get; set; }
        #endregion
    }
}
