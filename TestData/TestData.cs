namespace PetStore6.TestData
{
    public class TestDetails
    {
        public string HomePageUrl;
        public int WaitTime;
        public string Browser;

        public TestDetails(string homePageUrl, int waitTime, string browser)
        {
            HomePageUrl = homePageUrl;
            WaitTime = waitTime;
            Browser = browser;
        }
    }
}
