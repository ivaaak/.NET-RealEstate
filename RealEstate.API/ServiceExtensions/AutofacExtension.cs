using Autofac;
using RealEstate.Core.Configurations;

namespace RealEstate.API.ServiceExtensions
{
    public class AutofacExtension
    {
        public void ConfigureContainer(ContainerBuilder builder)
        {
            EnvironmentDefinition environment = EnvironmentDefinition.GetEnvironmentDefinition();

            // initializes classes that provides static interfaces
            //KeyVaultClient.Init(environment.KeyVaultConfiguration);

            // start async registrations
            Task configureTasks = ConfigureContainerAsync(environment);

            // Type Registrations
            builder.RegisterType<DependencyFactory>()
                .As<IDependencyFactory>()
                .SingleInstance();

            // Module registrations
            //builder.RegisterModule(new CloudQueueClientModule());


            // wait for async registrations to complete
            configureTasks.Wait();
        }

        private async Task ConfigureContainerAsync(EnvironmentDefinition environment)
        {
            // start tasks
            // Task<string> getJwtSecretsTask = KeyVaultClient.GetSecretAsync(SecretNames.JwtSecrets);

            // wait for completion
            // string jwtSecretsString = await getJwtSecretsTask;
            // var jwtSecrets = jwtSecretsString.Deserialize<JwtSecrets>();

            // configure
            // JwtToken.SetJwtSecrets(jwtSecrets);
        }
    }
}
