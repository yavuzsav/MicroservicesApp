using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace AspnetRunBasics.ApiCollection.Infrastructure
{
    public class BaseHttpClientWithFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseHttpClientWithFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Uri BaseAddress { get; set; }
        public string BasePath { get; set; }

        private HttpClient GetHttpClient()
        {
            return _httpClientFactory.CreateClient();
        }

        public virtual async Task<T> SendRequest<T>(HttpRequestMessage httpRequestMessage) where T : class
        {
            var client = GetHttpClient();

            var response = await client.SendAsync(httpRequestMessage);

            T result = null;

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<T>(GetFormatters());

            return result;
        }

        protected virtual IEnumerable<MediaTypeFormatter> GetFormatters()
        {
            // Make default the JSON
            return new List<MediaTypeFormatter> {new JsonMediaTypeFormatter()};
        }
    }
}
