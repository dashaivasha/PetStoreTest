using NUnit.Framework;
using System.Net;

namespace PetStore6.Tests.UiTests
{
    [TestFixture]
    internal class CreateOrderUITests : BaseTest
    {
        [SetUp]
        public void Open()
        {
            WebDriver.Navigate().GoToUrl(Data.HomePageUrl);
        }

        [Test]
        public void CreateOrder()
        {
            homePage.PostOrder();
            Assert.AreEqual((int)HttpStatusCode.OK, homePage.GetPostOrderResponseCode());
        }

        [Test]
        public void CreatetOrderWithNonexistentPet()
        {
            petService.DeletePet(Pet.Id);
            homePage.PostOrder();
            Assert.AreEqual((int)HttpStatusCode.BadRequest, homePage.GetPostOrderResponseCode());
        }
    }
}
