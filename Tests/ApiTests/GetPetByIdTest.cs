using NUnit.Framework;

namespace PetStore6.Tests.ApiTests
{
    [TestFixture]
    public class GetPetByIdTest : BaseTest
    {
        [Test]
        public void GetPetById()
        {
          Assert.IsTrue(Pet == petService.GetPet(Pet.Id).Result);
        }
    }
}
