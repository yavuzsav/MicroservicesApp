using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunBasics.Models;

namespace AspnetRunBasics.ApiCollection.Interfaces
{
    public interface IOrderApi
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
