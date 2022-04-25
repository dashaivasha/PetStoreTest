using PetStore6.TestData;

using NUnit.Framework;

using System.Net.Http;
using PetStore6.Api.Models;
using PetStore6.Api.Services;
using PetStore6.Api.Client;

namespace PetStore6.Tests.ApiTests
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
