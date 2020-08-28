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
    public class BasketApi : BaseHttpClientWithFactory, IBasketApi
    {
        private readonly IApiSettings _apiSettings;
        public BasketApi(IHttpClientFactory httpClientFactory, IApiSettings apiSettings) : base(httpClientFactory)
        {
            _apiSettings = apiSettings;
        }

        public async Task CheckoutBasket(BasketCheckoutModel basketCheckoutModel)
        {
            var httpRequestMessage = new HttpRequestBuilder(_apiSettings.BaseAddress)
            .SetPath(_apiSettings.BasketPath)
            .AddToPath("Checkout")
            .HttpMethod(HttpMethod.Post)
            .GetHttpMessage();

            var json = JsonConvert.SerializeObject(basketCheckoutModel);
            httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");

            await SendRequest<BasketCheckoutModel>(httpRequestMessage);
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var httpRequestMessage = new HttpRequestBuilder(_apiSettings.BaseAddress)
            .SetPath(_apiSettings.BasketPath)
            .AddToPath(userName)
            .HttpMethod(HttpMethod.Get)
            .GetHttpMessage();

            return await SendRequest<BasketModel>(httpRequestMessage);
        }

        public async Task<BasketModel> UpdateBasket(BasketModel basketModel)
        {
            var httpRequestMessage = new HttpRequestBuilder(_apiSettings.BaseAddress)
            .SetPath(_apiSettings.BasketPath)
            .HttpMethod(HttpMethod.Post)
            .GetHttpMessage();

            var json = JsonConvert.SerializeObject(basketModel);
            httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<BasketModel>(httpRequestMessage);
        }
    }
}