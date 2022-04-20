using OpenQA.Selenium;
using PetStore6.TestData;
using PetStore6.UITests.UITestData.WebDriver;

namespace PetStore6.UITests.PageObjects
{
    public class BasePage 
    {
        protected IWebDriver driver;
        internal TestDetails Data = JsonManager.GetTestData();

        public BasePage()
        {
            DriverFactory.InitalizerDriver();
            driver = DriverFactory.Driver;
        }
    }
}
