namespace ExternalAPIsMicroservice.Services.Interfaces
{
    public interface IZillowAgentService
    {
        Task<string> FindAgent(string searchParams);

        Task<string> GetAgentDetails(string username);

        Task<string> GetAgentReviews(string username);

        Task<string> GetAgentActiveListings(string username);

        Task<string> GetAgentSoldListings(string username);

        Task<string> GetAgentRentalListings(string username);
    }
}
