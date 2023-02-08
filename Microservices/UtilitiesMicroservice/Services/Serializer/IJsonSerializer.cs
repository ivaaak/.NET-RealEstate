<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/Serializer/IJsonSerializer.cs
﻿namespace RealEstate.Microservices.Serializer
=======
﻿namespace UtilitiesMicroservice.Services.Serializer
>>>>>>> Stashed changes:Microservices/UtilitiesMicroservice/Services/Serializer/IJsonSerializer.cs
{
    public interface IJsonSerializer
    {
        // SERIALIZE
        string Serialize(object obj);

        // DESERIALIZE GENERIC
        T Deserialize<T>(string json);
    }
}
