using NUnit.Framework;
using OpenQA.Selenium;
using PetStore6.Driver;
using PetStore6.PageObjects;
using PetStore6.TestData;


namespace PetStore6.Tests
{
    public class BaseTest
    {
        protected TestDetails Data = JsonManager.GetTestData();
        internal HomePage homePage = new HomePage();
        public IWebDriver WebDriver => DriverFactory.Driver;

        [OneTimeSetUp]
        public void Open()
        {
            DriverFactory.InitalizerDriver();
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl(Data.HomePageUrl);
        }

        [OneTimeTearDown]
        public void Close()
        {
            WebDriver.Quit();
        }
    }
}
