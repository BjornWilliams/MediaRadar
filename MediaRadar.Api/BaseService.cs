using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MediaRadar.Api
{
    /// <summary>
    ///  Represents a collection of generic logic that can be used by derived service classes.
    /// </summary>
    public abstract class BaseService
    {
        #region Fields
        private readonly string headerKey;
        private readonly string headerValue;
        private readonly string host;
        #endregion

        #region Constructors
        public BaseService()
        {
            //Hard-coded here for convenience could later be re-factored and be passed in.
            headerKey = "Ocp-Apim-Subscription-Key";
            headerValue = "293d6276c7f44b9bbae21d85794656b5";
            host = "https://api-c.mediaradar.com/";
        }
        #endregion

        #region Methods
        /// <summary>
        /// Using the given Url path perform a "Get" request and serialize the Json reponse into the given type of {T}.
        /// </summary>
        /// <typeparam name="T">The type to which the response will be serialized to.</typeparam>
        /// <param name="relativePath">The url path to append to the domain.</param>
        /// <returns>The serialized Json to the type of {T}</returns>
        protected async Task<T> GetDataAsync<T>(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) { throw new ArgumentNullException(nameof(relativePath)); }

            var request = new HttpRequestMessage(HttpMethod.Get, new Uri($"{host}{relativePath}"));

            request.Headers.Add(headerKey, headerValue);

            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);

                response.EnsureSuccessStatusCode();

                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var reader = new JsonTextReader(new StreamReader(stream));

                    var serializer = new JsonSerializer();

                    return serializer.Deserialize<T>(reader);
                }
            }
        }
        #endregion
    }
}
