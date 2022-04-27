using NUnit.Framework;
using PetStore6.Constants.Enums;
using System.Net;

namespace PetStore6.Tests.UiTests
{
    [TestFixture]
    internal class GetPetByStatusUITest : BaseTest
    {
        [SetUp]
        public void Open()
        {
            WebDriver.Navigate().GoToUrl(Data.HomePageUrl);
        }

        [Test]
        public void GetPetsByStatus()
        {
            homePage.PressFindByStatus();
            homePage.ChooseStatus(Pet.Status);
            Assert.AreEqual((int)HttpStatusCode.OK, homePage.GetStatusResponseCode());
        }

        [Test]
        public void GetPetByStatus()
        {
            homePage.PressFindByStatus();
            homePage.ChooseStatus(Pet.Status);
            Assert.True(homePage.IsPetExistsWithThisStatus(Pet.Id, Pet.Name));
        }

        [Test]
        public void ChangeStatusAndCheckForExistence()
        {
            Pet.Status = Statues.GetDescription(Statues.Status.Sold);
            petService.PutPet(Pet);
            homePage.PressFindByStatus();
            homePage.ChooseStatus(Pet.Status);
            Assert.True(homePage.IsPetExistsWithThisStatus(Pet.Id, Pet.Name));
        }

        [Test]
        public void ChangeStatusAndCheckForExistenceWithOldStatus()
        {
            var oldStatus = Pet.Status;
            Pet.Status = Statues.GetDescription(Statues.Status.Pending);
            petService.PutPet(Pet);
            homePage.PressFindByStatus();
            homePage.ChooseStatus(oldStatus);
            Assert.False(homePage.IsPetExistsWithThisStatus(Pet.Id, Pet.Name));
        }
    }
}
