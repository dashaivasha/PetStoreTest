using NUnit.Framework;
using OpenQA.Selenium;
using PetStore6.TestData;
using PetStore6.UITests.PageObjects;
using PetStore6.UITests.UITestData.WebDriver;

namespace PetStore6.UITests
{
    public class BaseTest
    {
        public TestDetails Data = JsonManager.GetTestData();
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
