namespace ExternalAPIsMicroservice.Services.Interfaces
{
    public interface IZillowApiService
    {
        Task<string> GetProperty(string zpid);

        Task<string> GetPropertyImages(string zpid);

        Task<string> GetExtendedSearch(string searchParams);

        Task<string> GetPriceAndTaxHistory(string zpid);

        Task<string> SearchByUrl(string url);

        Task<string> GetPropertyComps(string zpid);

        Task<string> GetPropertyByCoordinates(string lat, string lon);

        Task<string> GetPropertyByMls(string mlsNumber);

        Task<string> GetLocationSuggestions(string query);

        Task<string> GetRentEstimate(string zpid);

        Task<string> GetWalkAndTransitScore(string lat, string lon);

        Task<string> GetBuilding(string buildingId);

        Task<string> GetZestimateHistory(string zpid);

        Task<string> Ping();

        Task<string> BuildWebUrl(string zpid);
    }
}
