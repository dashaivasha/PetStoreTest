using System;
using PetStore6.Api.Client;
using System.Net.Http;
using PetStore6.TestData;

namespace PetStore6.Api.Services
{
    public class PetStoreService 
    {
        protected HttpClient _httpClient;
        protected TestDetails Data = JsonManager.GetTestData();

        public PetStoreService()
        {
            HttpClientFactory.InitalizerClient();
            _httpClient = HttpClientFactory.HttpClient;

            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(Data.Url);
            }

            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
    }
}
