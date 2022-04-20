using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PetStore6.TestData
{
    public class DataSerializer
    {
        public static object JsonDeserialize(Type dataType, string filePath)
        {
            try
            {
                JObject obj = null;
                var jsonSerializer = new JsonSerializer();

                if (File.Exists(filePath))
                {
                    var sr = new StreamReader(filePath);
                    var jsonReader = new JsonTextReader(sr);
                    obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                    jsonReader.Close();
                    sr.Close();
                }

                return obj.ToObject(dataType);
            }
            catch 
            {
                throw;
            }
        }
    }
}
