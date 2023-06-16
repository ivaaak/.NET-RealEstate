namespace ExternalAPIsMicroservice.Services.Interfaces
{
    public interface IZillowSimilarListingsService
    {
        Task<string> GetSimilarProperties(string zpid);

        Task<string> GetSimilarSales(string zpid);

        Task<string> GetSimilarForRent(string zpid);
    }
}
