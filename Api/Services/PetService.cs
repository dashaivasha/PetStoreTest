using PetStore6.Api.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PetStore6.Api.Services
{
    public class PetService : PetStoreService
    {
        public PetService()
        {
        }

        public async Task<Pet?> GetPet(string id) =>
        await _httpClient.GetFromJsonAsync<Pet>(
        $"pet/{id}");

        public HttpResponseMessage PostPet(Pet pet)
        {
            var response = _httpClient.PostAsJsonAsync($"pet/", pet).Result;
            return response;
        }
    }
}
