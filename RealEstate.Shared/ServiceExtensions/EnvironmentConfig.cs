# nullable disable
using System.Reflection;
using System.Text.Json;

namespace RealEstate.Shared.ServiceExtensions
{
    public class EnvironmentConfig
    {
        public const string ENVIRONMENT_VARIABLE_NAME = "Development";

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
        public static EnvironmentConfig Current { get; set; }

        public static void LoadFromEnvironmentVariable()
        {
            var environment = System.Environment.GetEnvironmentVariable(ENVIRONMENT_VARIABLE_NAME);
            Enum.TryParse(typeof(MyEnvironment), environment, true, out var env);
            if (string.IsNullOrEmpty(environment) || env == null)
            {
                //throw new Exception($"Hey, you need to set the App Environment Variable!");
            }

            Load((MyEnvironment)env);
        }

        public static void Load(object env)
        {
            var path = Assembly.GetExecutingAssembly().Location;
            var dir = Path.GetDirectoryName(path);
            var json = File.ReadAllText(Path.Combine(dir, "connectionStrings.json"));
            var config = JsonSerializer.Deserialize<Dictionary<string, EnvironmentConfig>>(json);
            Current = config[env.ToString()];
        }

        public static void LoadFromDifferentAssembly(MyEnvironment env, string assemblyFilePath)
        {
            var assembly = Assembly.Load(assemblyFilePath);
            var resourceName = "MyAssemblyName.connectionStrings.json";
            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new FileNotFoundException($"Resource '{resourceName}' not found in assembly '{assembly.FullName}'.");
            }
            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            var config = JsonSerializer.Deserialize<Dictionary<string, EnvironmentConfig>>(json);
            Current = config[env.ToString()];
        }
        // usage:
        //var assemblyFilePath = @"C:\Path\To\MyAssembly.dll";
        //EnvironmentConfig.Load(MyEnvironment.Dev, assemblyFilePath);
    }


    public enum MyEnvironment
    {
        Unknown,
        Local,
        Dev,
        Prod
    }
}
