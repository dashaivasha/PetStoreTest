using PetStore6.Api.Client;
using System;
using System.Net.Http;

namespace PetStore6.Api.Services
{
    public class PetStoreService 
    {
        protected HttpClient _httpClient;

        public PetStoreService()
        {
            HttpClientFactory.InitalizerClient();
            _httpClient = HttpClientFactory.HttpClient;
            _httpClient.BaseAddress = new Uri("https://petstore.swagger.io/v2/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
    }
}
