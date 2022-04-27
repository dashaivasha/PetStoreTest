using PetStore6.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PetStore6.Constants.Enums;

namespace PetStore6.Api.Services
{
    public class PetService : PetStoreService
    {
        public PetService()
        {
        }

        public async Task<Pet?> GetPet(long id) =>
        await _httpClient.GetFromJsonAsync<Pet>(
        $"pet/{id}");

        public bool GetPet(long id, Pet pet)
        {    
            return pet == GetPet(id).Result; ;
        }

        public HttpResponseMessage GetPetResponseCode(long id)
        {
            var response = _httpClient.GetAsync($"pet/{id}").Result;
            return response;
        }
        public HttpResponseMessage PostPet(Pet pet)
        {
            var response = _httpClient.PostAsJsonAsync($"pet/", pet).Result;
            return response;
        }

        public HttpResponseMessage PutPet(Pet pet)
        {
            var response = _httpClient.PutAsJsonAsync($"pet/", pet).Result;
            return response;
        }

        public HttpResponseMessage DeletePet(long id)
        {
            var response = _httpClient.DeleteAsync($"pet/{id}").Result;
            return response;
        }

        public async  Task<IEnumerable<Pet>?> GetPetsByStatus(string status) =>
        await _httpClient.GetFromJsonAsync<IEnumerable<Pet>>(
        $"pet/findByStatus?status={status}");

        public HttpResponseMessage GetPetByStatusResponseCode(string status)
        {
            var response = _httpClient.GetAsync($"pet/findByStatus?status={status}").Result;
            return response;
        }

        public Pet FindTestById(IEnumerable<Pet>? pets, long Id)
        {
            var currentPet = pets.FirstOrDefault(pet => pet.Id == Id);

            return currentPet;
        }
    }
}
