namespace PetStore6.TestData
{
    public class TestDetails
    {
        public string Url;
        public string HomePageUrl;
        public int WaitTime;
        public string Browser;
        public string Api_key;
        public TestDetails(string url, string homePageUrl, int waitTime, string browser, string api_key)
        {
            Url = url;
            HomePageUrl = homePageUrl;
            WaitTime = waitTime;
            Browser = browser;
            Api_key = api_key;
        }
    }
}
