using System;
namespace Data.Transfer.Objects
{
    public class ParentCompanyDto
    {
        /// <summary>
        /// Gets or Sets the number of pages purchased by the advertiser.
        /// </summary>
        public decimal AdPages { get; set; }

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
        public string ParentCompany { get; set; }

        /// <summary>
        /// Gets or Sets a unique key for the magazine or newspaper.
        /// </summary>
        public int PublicationId { get; set; }

        /// <summary>
        /// Gets or Sets the name of the magazine or newspaper.
        /// </summary>
        public string PublicationName { get; set; }

        /// <summary>
        /// Gets or Sets date of the record.
        /// </summary>
        public DateTime Month { get; set; }
    }
}
