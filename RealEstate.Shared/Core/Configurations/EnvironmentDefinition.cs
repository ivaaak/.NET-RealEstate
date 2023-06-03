#nullable disable
namespace RealEstate.Shared.Core.Configurations
{
    public abstract class EnvironmentDefinition
    {
        /// <summary>
        /// KeyVault Configuration
        /// </summary>
        public abstract ClientConfiguration KeyVaultConfiguration { get; }


        public static string GetEnvironment()
        {
            string environment = Environment.GetEnvironmentVariable(nameof(Environment));

            if (string.IsNullOrEmpty(environment))
            {
                return EnvironmentConstants.Production;
            }

            return environment.ToLowerInvariant();
        }

        public static EnvironmentDefinition GetEnvironmentDefinition()
        {
            string environment = GetEnvironment();

            if (string.IsNullOrEmpty(environment))
            {
                throw new ArgumentNullException(nameof(environment), "Current environment is not defined in config settings");
            }

            switch (environment)
            {
                //case EnvironmentConstants.Local:
                //    return new LocalEnvironmentDefinition();

                case EnvironmentConstants.Production:
                    return new ProductionEnvironmentDefinition();
            }

            throw new InvalidOperationException("Invalid environment");
        }
    }
}
