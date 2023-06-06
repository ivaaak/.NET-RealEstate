namespace ExternalAPIsMicroservice.Services.Interfaces
{
    public interface IScraperService
    {
        void RunScraper();

        void DownloadWebsiteString();

        object ExtractWebsiteData();

        void Do();

        void SaveDataToDatabase();
    }
}