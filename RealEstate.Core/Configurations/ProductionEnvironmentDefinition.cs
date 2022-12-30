namespace RealEstate.Core.Configurations
{
    public class ProductionEnvironmentDefinition : EnvironmentDefinition
    {
        /// <summary>
        /// KeyVault Configuration
        /// </summary>
        public override ClientConfiguration KeyVaultConfiguration =>
            new ClientConfiguration
            {
                BaseAddress = "https://username.vault.azure.net",
            };
    }
}
