using System.Reflection;
using System.Text.Json;

namespace RealEstate.Data.Extensions
{
    public class EnvironmentConfigInData
    {
        public const string ENVIRONMENT_VARIABLE_NAME = "Local"; // Change this

        // Values defined in the json file for each environment
        public MyEnvironment Environment { get; set; }
        public string RedisConnectionString { get; set; }

        // PostgreSQL
        public string PostgreSQLMainConnection { get; set; }

        public string PostgreEstatesConnection { get; set; }
        public string PostgreIdentityConnection { get; set; }
        public string PostgreListingsConnection { get; set; }
        public string PostgreClientsConnection { get; set; }
        public string PostgreContractsConnection { get; set; }

        //MySQL
        public string MySQLMainConnection { get; set; }


        // The app configuration for the current environment
        public static EnvironmentConfigInData Current { get; set; }

        public static void LoadFromEnvironmentVariable()
        {
            var environment = System.Environment.GetEnvironmentVariable(ENVIRONMENT_VARIABLE_NAME);
            Enum.TryParse(typeof(MyEnvironment), environment, out var env);
            if (string.IsNullOrEmpty(environment) || env == null)
            {
                throw new Exception($"Hey, you need to set the App Environment Variable!");
            }

            Load((MyEnvironment)env);
        }

        public static void Load(MyEnvironment env)
        {
            var path = Assembly.GetExecutingAssembly().Location;

            var dir = AppDomain.CurrentDomain.BaseDirectory;

            var json = File.ReadAllText(Path.Combine(dir, "connectionStrings.json"));

            var config = JsonSerializer.Deserialize<Dictionary<string, EnvironmentConfigInData>>(json);
            Current = config[env.ToString()];
        }
    }


    public enum MyEnvironment
    {
        Unknown,
        Local,
        Dev,
        Prod
    }
}
