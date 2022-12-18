namespace RealEstate.Microservices.Contracts
{
    public interface IJsonSerializer
    {
        // SERIALIZE
        string Serialize(object obj);

        // DESERIALIZE GENERIC
        T Deserialize<T>(string json);
    }
}
