using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AspnetRunBasics.ApiCollection.Infrastructure;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using AspnetRunBasics.Settings;
using Newtonsoft.Json;

namespace AspnetRunBasics.ApiCollection
{
    public class CatalogApi : BaseHttpClientWithFactory, ICatalogApi
    {
        private readonly IApiSettings _apiSettings;
        public CatalogApi(IHttpClientFactory httpClientFactory, IApiSettings apiSettings) : base(httpClientFactory)
        {
            _apiSettings = apiSettings;
        }

        public async Task<CatalogModel> CreateCatalog(CatalogModel catalogModel)
        {
            var httpRequestMessage = new HttpRequestBuilder(_apiSettings.BaseAddress)
            .SetPath(_apiSettings.CatalogPath)
            .HttpMethod(HttpMethod.Post)
            .GetHttpMessage();

            var json = JsonConvert.SerializeObject(catalogModel);
            httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<CatalogModel>(httpRequestMessage);
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var httpRequestMessage = new HttpRequestBuilder(_apiSettings.BaseAddress)
            .SetPath(_apiSettings.CatalogPath)
            .HttpMethod(HttpMethod.Get)
            .GetHttpMessage();

            return await SendRequest<IEnumerable<CatalogModel>>(httpRequestMessage);
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            var httpRequestMessage = new HttpRequestBuilder(_apiSettings.BaseAddress)
            .SetPath(_apiSettings.CatalogPath)
            .AddToPath(id)
            .HttpMethod(HttpMethod.Get)
            .GetHttpMessage();

            return await SendRequest<CatalogModel>(httpRequestMessage);
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            var httpRequestMessage = new HttpRequestBuilder(_apiSettings.BaseAddress)
            .SetPath(_apiSettings.CatalogPath)
            .AddToPath("GetProductsByCategoryName")
            .AddToPath(category)
            .HttpMethod(HttpMethod.Get)
            .GetHttpMessage();

            return await SendRequest<IEnumerable<CatalogModel>>(httpRequestMessage);
        }
    }
}