namespace RealEstate.Infrastructure.Interfaces
{
    public abstract class IDatabaseSeeder
    {
        public partial Task SeedAsync(IApplicationDbContext databaseContext, IServiceProvider serviceProvider);
    }
}
