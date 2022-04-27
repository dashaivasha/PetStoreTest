using NUnit.Framework;
using OpenQA.Selenium;
using PetStore6.Api.Client;
using PetStore6.Api.Models;
using PetStore6.Api.Services;
using PetStore6.Driver;
using PetStore6.PageObjects;
using PetStore6.TestData;
using System.Net.Http;

namespace PetStore6.Tests.UiTests
{
    public class BaseTest
    {
        public Pet Pet = JsonManager.GetPetFromJson();
        public Order Order = JsonManager.GetOrderFromJson();
        protected TestDetails Data = JsonManager.GetTestData();
        internal HomePage homePage = new HomePage();
        internal PetService petService = new PetService();
        internal OrderService orderService = new OrderService();
        public IWebDriver WebDriver => DriverFactory.Driver;
        public HttpClient httpClient => HttpClientFactory.HttpClient;

        [OneTimeSetUp]
        public void Start()
        {
            orderService.PostOrder(Order);
            petService.PostPet(Pet);
            DriverFactory.InitalizerDriver(); ;
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl(Data.HomePageUrl);
        }

        [OneTimeTearDown]
        public void Close()
        {
            DriverFactory.QuitDriver();
        }
    }
}
