using System;

namespace MediaRadar.Api
{
    /// <summary>
    /// Represents a requested date range.
    /// </summary>
    public class DateRange
    {
        #region Fields
        private readonly DateTime startDate;
        private readonly DateTime endDate;
        #endregion

        #region Constructors
        public DateRange(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the start date in format: yyyy-mm-dd
        /// </summary>
        public string FormattedStartDate => startDate.ToString("yyyy-MM-dd");

        /// <summary>
        /// Gets the end date in format: yyyy-mm-dd
        /// </summary>
        public string FormattedEndDate => endDate.ToString("yyyy-MM-dd");
        #endregion
    }
}
