using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AspnetRunBasics.ApiCollection.Infrastructure;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using AspnetRunBasics.Settings;

namespace AspnetRunBasics
{
    public class OrderApi : BaseHttpClientWithFactory, IOrderApi
    {
        private readonly IApiSettings _apiSettings;
        public OrderApi(IHttpClientFactory httpClientFactory, IApiSettings apiSettings) : base(httpClientFactory)
        {
            _apiSettings = apiSettings;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var httpRequestMessage = new HttpRequestBuilder(_apiSettings.BaseAddress)
            .SetPath(_apiSettings.OrderPath)
            .AddQueryString("userName", userName)
            .HttpMethod(HttpMethod.Get)
            .GetHttpMessage();

            return await SendRequest<IEnumerable<OrderResponseModel>>(httpRequestMessage);
        }
    }
}