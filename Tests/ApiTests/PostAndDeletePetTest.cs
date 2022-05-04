
using NUnit.Framework;
using System.Net;

namespace PetStore6.Tests.ApiTests
{
    [TestFixture]
    public class PostAndDeletePetTest : BaseTest
    {
        [Test]
        public void PostAndDelete()
        {
            AssertAccumulator.Accumulate(() => Assert.That(petService.GetPet(Pet.Id, Pet)));
            Assert.AreEqual(HttpStatusCode.OK, petService.DeletePet(Pet.Id).StatusCode);
        }
    }
}
