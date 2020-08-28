using System.Threading.Tasks;
using AspnetRunBasics.Models;

namespace AspnetRunBasics.ApiCollection.Interfaces
{
    public interface IBasketApi
    {
        Task<BasketModel> GetBasket(string userName);
        Task<BasketModel> UpdateBasket(BasketModel basketModel);
        Task CheckoutBasket(BasketCheckoutModel basketCheckoutModel);
    }
}
