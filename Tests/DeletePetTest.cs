using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetStore6.Tests
{
    [TestFixture]
    internal class DeletePetTest : BaseTest
    {
        [Test]
        public void DeleteAndGetPetUI()
        {
            homePage.PressDeleteByIdButton();
            homePage.EnterIdForDelete(Convert.ToString(Pet.Id));
            homePage.EnterApi_key(Data.Api_key);
            homePage.ExecuteDelete();
            Assert.AreEqual(homePage.GetDeleteResponseCode(), (int)HttpStatusCode.OK);
        }
    }
}
