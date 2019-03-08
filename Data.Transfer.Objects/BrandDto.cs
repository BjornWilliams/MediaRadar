namespace Data.Transfer.Objects
{
    public class BrandDto
    {
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
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or Sets the category describing the type of advertised brand.
        /// </summary>
        public string ProductCategory { get; set; }
    }
}
