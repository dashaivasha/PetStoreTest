using NUnit.Framework;

namespace PetStore6.ApiTests
{
    [TestFixture]
    public class GetPetByIdTest : BaseTest
    {
        [Test]
        public void GetPetById()
        {
            Pet.Equals(petService.GetPet("22").Result);
        }
    }
}
