using NUnit.Framework;
using System.Net;

namespace PetStore6.Tests.UiTests
{
    [TestFixture]
    public class GetPetByIdUITest : BaseTest
    {
        [Test]
        public void GetPetById()
        {
            homePage.PressGetByIdButton();
            homePage.EnterId(Pet.Id);
            homePage.Execute();
            Assert.AreEqual(homePage.GetResponseCode(), (int)HttpStatusCode.OK);
        }
    }
}
