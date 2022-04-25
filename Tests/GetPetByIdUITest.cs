using NUnit.Framework;

namespace PetStore6.Tests
{
    [TestFixture]
    public class GetPetByIdUITest : BaseTest
    {
        [SetUp]
        public void PostPet()
        {
            homePage.PostPet();
        }

        [Test]
        public void GetPetById()
        {
            homePage.PressGetByIdButton();
            homePage.EnterId("22");
            homePage.Execute();
            Assert.AreEqual(homePage.GetResponseCode(), 200);
        }      
    }
}
