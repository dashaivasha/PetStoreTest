using NUnit.Framework;
using System.Net;

namespace PetStore6.Tests.ApiTests
{
    [TestFixture]
    internal class DeleteAndGetDeletedPetTest: BaseTest
    {
        [Test]
        public void DeleteAndGetPet()
        {
            petService.DeletePet(Pet.Id);
            Assert.AreEqual(HttpStatusCode.NotFound, petService.GetPetResponseCode(Pet.Id).StatusCode);
        }

        [Test]
        public void DeleteANonexistentPet()
        {
            petService.DeletePet(Pet.Id);
            Assert.AreEqual(HttpStatusCode.NotFound, petService.DeletePet(Pet.Id).StatusCode);
        }
    }
}
