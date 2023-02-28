namespace ListingsMicroservice.Services.Serializer
{
    public interface IJsonSerializer
    {
        // SERIALIZE
        string Serialize(object obj);

        // DESERIALIZE GENERIC
        T Deserialize<T>(string json);
    }
}
