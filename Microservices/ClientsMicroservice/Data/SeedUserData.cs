using ClientsMicroservice.Data.Repository;
using MediatR;

namespace ClientsMicroservice.Data
{
    public static class SeedUserData
    {
        public static async Task EnsureSeedData(IServiceCollection services)
        {
            await using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetService<IMediator>();

                    var userManager = scope.ServiceProvider.GetRequiredService<IUserRepository>();

                    //if (await userManager.FindByUsernameAsync("Test") == null)
                    //{
                    //    var user = new CreateUserDto()
                    //    {
                    //        Username = "Test",
                    //        Password = "Pass",
                    //        Firstname = "Name",
                    //        Lastname = "Lastname",
                    //        Email = "Test@email.com",
                    //        EmailConfirmed = true
                    //    };

                    //    var response = await mediator
                    //        .CreateRequestClient<CreateUserCommand>()
                    //        .GetResponse<ValidationExceptionMessage, UserResponse>(
                    //            message: new() { User = user });
                    //}
                }
            }
        }
    }
}
