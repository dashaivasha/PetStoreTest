using OpenQA.Selenium;
using PetStore6.Constants;
using PetStore6.Driver;
using PetStore6.TestData;

namespace PetStore6.PageObjects
{
    public class BasePage 
    {
        protected IWebDriver Driver;
        internal TestDetails Data = JsonManager.GetTestData();

        public BasePage()
        {
            DriverFactory.InitalizerDriver();
            Driver = DriverFactory.Driver;
        }
    }
}
