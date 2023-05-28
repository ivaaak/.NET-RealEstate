namespace RealEstate.Shared
{
    public static class GlobalConnectionStrings
    {
        // Databases
        public const string RealEstate_DB_Connection = "Server=localhost;Port=5000;Database=RealEstate;User Id=admin;Password=admin;";
        //Host=127.0.0.1;Database=RealEstate;Username=postgres;Password=admin
        // Keycloak
        public const string Keycloak_DB_Connection = "Server=postgres;Port=5432;Database=keycloak;User Id=keycloak;Password=password;Integrated Security=true;Pooling=true";
        public const string Keycloak_Auth_Server = "http://localhost:8080/";
        public const string Keycloak_Secret = "Tgx4lvbyhho7oNFmiIupDRVA8ioQY7PW";

        // Micro Databases
        public const string Clients_MicroDB_Connection = "Server=localhost;Port=5001;Database=Clients;User Id=clients;Password=clients;";
        public const string Contracts_MicroDB_Connection = "Server=localhost;Port=5002;Database=Contracts;User Id=contracts;Password=contracts;";
        public const string Estates_MicroDB_Connection = "Server=localhost;Port=5003;Database=Estates;User Id=estates;Password=estates;";
        public const string Listings_MicroDB_Connection = "Server=localhost;Port=5005;Database=Listings;User Id=listings;Password=listings;";

        // NoSQL Databases
        public const string Redis_Connection = "localhost:6379";
        public const string Mongo_Connection = "";

        // Event Bus
        public const string RabbitMQ_Connection = "amqp://guest:guest@host.docker.internal:5672/"; //"amqp://guest:guest@localhost:5672/

        public const string GRPC_Connection = "http://localhost:5003";

        // Logginng
        public const string Elasticsearch_Connection = "http://localhost:9200";
    }
}
