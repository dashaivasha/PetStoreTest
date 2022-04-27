using NUnit.Framework;
using System.Net;

namespace PetStore6.Tests.ApiTests
{
    [TestFixture]
    internal class CreateOrderTest : BaseTest
    {
        [Test]
        public void CreateOrder()
        {
            var foundOrder = orderService.GetOrder(Order.Id).Result;
            Assert.IsTrue(Order == foundOrder);
        }

        [Test]
        public void CreatetOrderWithNonexistentPet()
        {
            petService.DeletePet(Pet.Id);
            Assert.AreEqual(HttpStatusCode.BadRequest, orderService.PostOrder(Order).StatusCode);
        }
    }
}
