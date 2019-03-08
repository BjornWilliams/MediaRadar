using MediaRadar.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaRadar.Api.Contracts
{
    public interface IPublicationService
    {
        /// <summary>
        /// Retrieves all available Print advertising.
        /// </summary>
        /// <param name="startDate">The starting date of request (format: yyyy-mm-dd)</param>
        /// <param name="endDate">The ending date of the request (format: yyyy-mm-dd)</param>
        /// <returns>A collection of <seealso cref="PublicationAdActivity"/></returns>
        Task<IEnumerable<PublicationAdActivity>> GetPublicationAdActivitiesAsync(DateRange dateRange);
    }
}
