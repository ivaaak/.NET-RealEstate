using Newtonsoft.Json;

<<<<<<< Updated upstream
<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/Serializer/JsonSerializer.cs
namespace RealEstate.Microservices.Serializer
=======
<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/Utils/Serializer/JsonSerializer.cs
namespace RealEstate.Microservices.Utils.Serializer
>>>>>>> Stashed changes
=======
<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/Serializer/JsonSerializer.cs
namespace RealEstate.Microservices.Serializer
=======
namespace UtilitiesMicroservice.Services.Serializer
>>>>>>> Stashed changes:Microservices/UtilitiesMicroservice/Services/Serializer/JsonSerializer.cs
<<<<<<< Updated upstream
>>>>>>> Stashed changes:Microservices/UtilitiesMicroservice/Services/Serializer/JsonSerializer.cs
=======
>>>>>>> Stashed changes:Microservices/ListingsMicroservice/Services/Serializer/JsonSerializer.cs
>>>>>>> Stashed changes
{
    public class JsonSerializer : IJsonSerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer serializer;

        public JsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            this.serializer = serializer;
        }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonWriter = new JsonTextWriter(stringWriter))
                {
                    serializer.Serialize(jsonWriter, obj);
                    return stringWriter.ToString();
                }
            }
        }

        public T Deserialize<T>(string json)
        {
            using (var stringReader = new StringReader(json))
            {
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }
    }

}
