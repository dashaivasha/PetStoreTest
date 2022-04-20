using System;
using System.Net.Http;

namespace PetStore6.Client
{
    public class HttpClientFactory
    {
        private static HttpClient _httpClient;

        public static HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null)
                    throw new NullReferenceException("The HttpClient instance was not initialize. You should call the metod InitilizerHttpClient()");
                return _httpClient;
            }
            set
            {
                _httpClient = value;
            }
        }

        public static void InitalizerClient()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
            }
        }
    }
}
