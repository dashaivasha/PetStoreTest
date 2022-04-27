using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PetStore6.Api.Models;

namespace PetStore6.Api.Services
{
    internal class OrderService : PetStoreService
    {
        public OrderService()
        {
        }

        public async Task<Order?> GetOrder(long id) =>
        await _httpClient.GetFromJsonAsync<Order>(
        $"store/order/{id}");

        public HttpResponseMessage PostOrder(Order order)
        {
             var response = _httpClient.PostAsJsonAsync($"store/order", order).Result;
            return response;
        }
    }
}
