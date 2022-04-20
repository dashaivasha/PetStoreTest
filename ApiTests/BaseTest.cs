using PetStore6.TestData;
using PetStore6.Services;
using NUnit.Framework;
using PetStore6.Client;
using System.Net.Http;
using PetStore6.Models;

namespace PetStore6.ApiTests
{
    public class BaseTest
    {
        public Pet Pet = JsonManager.GetPetFromJson();
        public HttpClient httpClient => HttpClientFactory.HttpClient;
        internal PetService petService = new PetService();

        [OneTimeSetUp]
        public void Open()
        {
            petService.PostPet(Pet);
        }
    }
}
