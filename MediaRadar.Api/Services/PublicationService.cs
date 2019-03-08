using MediaRadar.Api.Contracts;
using MediaRadar.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaRadar.Api.Services
{
    /// <summary>
    /// Represents a service to access publication details.
    /// </summary>
    public class PublicationService : BaseService, IPublicationService
    {
        #region Methods
        /// <summary>
        /// Retrieves all available Print advertising.
        /// </summary>
        /// <param name="startDate">The starting date of request (format: yyyy-mm-dd)</param>
        /// <param name="endDate">The ending date of the request (format: yyyy-mm-dd)</param>
        /// <returns>A collection of <seealso cref="PublicationAdActivity"/></returns>
        public async Task<IEnumerable<PublicationAdActivity>> GetPublicationAdActivitiesAsync(DateRange dateRange)
        {
            if (dateRange == null) { throw new ArgumentNullException(nameof(dateRange)); }

            return await GetDataAsync<IEnumerable<PublicationAdActivity>>($"HiringAssessment/PublicationAdActivity?startDate={dateRange.FormattedStartDate}&endDate={dateRange.FormattedEndDate}");
        }
        #endregion
    }
}
