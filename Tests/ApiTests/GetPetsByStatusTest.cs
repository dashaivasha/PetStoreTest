using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using PetStore6.Constants.Enums;
using System.Text;
using System.Threading.Tasks;

namespace PetStore6.Tests.ApiTests
{
    [TestFixture]
    internal class GetPetsByStatusTest : BaseTest
    {
        [Test]
        public void FindPetsByStatus()
        {
            var foundPet = petService.FindTestById(petService.GetPetsByStatus(Pet.Status).Result, Pet.Id);
            Assert.IsTrue(foundPet == Pet);
        }

        [Test]
        public void FindPetsByStatusWithTheWrongStatus()
        {
            var pets = petService.GetPetsByStatus(Statues.GetDescription(Statues.Status.Pending)).Result;
            var foundPet = petService.FindTestById(pets, Pet.Id);
            Assert.IsNull(foundPet);
        }

        [Test]
        public void ChangeStatusAndCheckForExistence()
        {
            var foundPet = petService.FindTestById(petService.GetPetsByStatus(Pet.Status).Result, Pet.Id);
            foundPet.Status = Statues.GetDescription(Statues.Status.Sold);
            petService.PutPet(foundPet);
            Assert.IsTrue(petService.GetPet(Pet.Id).Result == Pet);
        }
    }
}
