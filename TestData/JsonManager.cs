using PetStore6.Models;

namespace PetStore6.TestData
{
    public class JsonManager
    {
        public static TestDetails GetTestData()
        {
            var data = DataSerializer.JsonDeserialize(typeof(TestDetails), Globals.DataPath) as TestDetails;

            return data;
        }

        public static Pet GetPetFromJson()
        {
            Pet pet = DataSerializer.JsonDeserialize(typeof(Pet), Globals.PetPath) as Pet;

            return pet;
        }
    }
}
