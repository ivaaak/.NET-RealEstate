namespace ExternalAPIsMicroservice.Services
{
    public interface IScraperService
    {
        void RunScraper();

        void DownloadWebsiteString();

        void ExtractWebsiteData();

        void Do();

        void SaveDataToDatabase();
    }
}