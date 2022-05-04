using NUnit.Framework;
using PetStore6.Api.Client;
using PetStore6.Api.Models;
using PetStore6.Api.Services;
using PetStore6.Constants;
using PetStore6.TestData;
using System.Net.Http;

namespace PetStore6.Tests.ApiTests
{
    public class BaseTest
    {
        public Pet Pet = JsonManager.GetPetFromJson();
        public Order Order = JsonManager.GetOrderFromJson();
        public HttpClient HttpClient => HttpClientFactory.HttpClient;
        internal PetService petService = new PetService();
        internal OrderService orderService = new OrderService();
        internal AssertsAccumulator AssertAccumulator = new AssertsAccumulator();

        [OneTimeSetUp]
        public void Open()
        {
            orderService.PostOrder(Order);
            petService.PostPet(Pet);
        }
    }
}
