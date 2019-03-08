namespace Hosting.WebApp.Models
{
    public class ProductCategoryModel
    {
        /// <summary>
        /// Gets or Sets the number of pages purchased by the advertiser.
        /// </summary>
        public decimal AdPages { get; set; }

        /// <summary>
        /// Gets or Sets the dollar amount spent by the advertiser to purchase the number of pages.
        /// </summary>
        public string EstPrintSpend { get; set; }

        /// <summary>
        /// Gets or Sets the category describing the type of advertised brand.
        /// </summary>
        public string ProductCategory { get; set; }
    }
}