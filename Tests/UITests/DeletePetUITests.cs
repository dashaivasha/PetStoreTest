using System;
using NUnit.Framework;
using System.Net;

namespace PetStore6.Tests.UiTests
{
    [TestFixture]
    internal class DeletePetUITests : BaseTest
    {
        [SetUp]
        public void Open()
        {
            WebDriver.Navigate().GoToUrl(Data.HomePageUrl);
        }

        [Test]
        public void DeleteAndGetPetUI()
        {
            petService.PostPet(Pet);
            homePage.PressDeleteByIdButton();
            homePage.EnterIdForDelete(Convert.ToString(Pet.Id));
            homePage.EnterApi_key(Data.Api_key);
            homePage.ExecuteDelete();
            Assert.AreEqual((int)HttpStatusCode.OK, homePage.GetDeleteResponseCode());
        }

        [Test]
        public void DeleteAndGetANonexistentPet()
        {
            homePage.PressDeleteByIdButton();
            homePage.EnterIdForDelete(Convert.ToString(Pet.Id));
            homePage.EnterApi_key(Data.Api_key);
            homePage.ExecuteDelete();
            homePage.PressGetByIdButton();
            homePage.EnterId(Pet.Id);
            homePage.Execute();
            Assert.AreEqual((int)HttpStatusCode.NotFound, homePage.GetResponseCode());
        }

        [Test]
        public void DeleteANonexistentPet()
        {
            petService.DeletePet(Pet.Id);
            homePage.PressDeleteByIdButton();
            homePage.EnterIdForDelete(Convert.ToString(Pet.Id));
            homePage.EnterApi_key(Data.Api_key);
            homePage.ExecuteDelete();
            Assert.AreEqual((int)HttpStatusCode.NotFound, homePage.GetDeleteResponseCode());
        }
    }
}
