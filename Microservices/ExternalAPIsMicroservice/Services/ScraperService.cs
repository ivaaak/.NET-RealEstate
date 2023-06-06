#nullable disable
using ExternalAPIsMicroservice.Services.Interfaces;
using HtmlAgilityPack;
using Npgsql;
using System.Net;

namespace ExternalAPIsMicroservice.Services
{
    public class ScraperService : IScraperService
    {
        private string html;

        public void RunScraper()
        {
            DownloadWebsiteString();
            ExtractWebsiteData();
        }


        public void DownloadWebsiteString()
        {
            using (var client = new WebClient())
            {
                html = client.DownloadString("https://www.imot.bg/pcgi/imot.cgi?act=3&slink=8qwd4b&f1=1");
            }
        }


        public object ExtractWebsiteData()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var propertyNameNode = htmlDoc.DocumentNode.SelectSingleNode("//h1[@class='headerClass']");
            var propertyName = propertyNameNode.InnerText.Trim();

            var priceNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='priceClass']");
            var price = priceNode.InnerText.Trim();

            var descriptionNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='descriptionClass']");
            var description = descriptionNode.InnerText.Trim();

            var obj = new
            {
                PropertyName = propertyName,
                Price = price,
                Description = description
            };

            return obj;
        }

        public void Do()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var listings = htmlDoc.DocumentNode.SelectNodes("//div[@class='offer-item']"); //fix?

            foreach (var listing in listings)
            {
                // Extract data from each listing
                var propertyNameNode = listing.SelectSingleNode(".//h3[@class='title']");
                var propertyName = propertyNameNode.InnerText.Trim();

                var priceNode = listing.SelectSingleNode(".//p[@class='price']");
                var price = priceNode.InnerText.Trim();

                var descriptionNode = listing.SelectSingleNode(".//p[@class='description']");
                var description = descriptionNode.InnerText.Trim();
            }
        }

        public void SaveDataToDatabase()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='offer-item']");

            using (var writer = new StreamWriter("data.csv"))
            {
                // Write the column headers
                writer.WriteLine("Property Name,Price,Description");

                // Iterate through the nodes and extract the data
                foreach (var node in nodes)
                {
                    var propertyName = node.SelectSingleNode(".//h3[@class='title']").InnerText.Trim();
                    var price = node.SelectSingleNode(".//p[@class='price']").InnerText.Trim();
                    var description = node.SelectSingleNode(".//p[@class='description']").InnerText.Trim();

                    // Write the data to the CSV file
                    writer.WriteLine($"{propertyName},{price},{description}");
                }
            }

            using (var conn = new NpgsqlConnection("Host=localhost;Username=user;Password=password;Database=database"))
            //TODO FIX CONNECTION STRING
            {
                conn.Open();

                foreach (var node in nodes)
                {
                    var propertyName = node.SelectSingleNode(".//h3[@class='title']").InnerText.Trim();
                    var price = node.SelectSingleNode(".//p[@class='price']").InnerText.Trim();
                    var description = node.SelectSingleNode(".//p[@class='description']").InnerText.Trim();

                    var command = new NpgsqlCommand("INSERT INTO properties (name, price, description) VALUES (@name, @price, @description)", conn);
                    command.Parameters.AddWithValue("@name", propertyName);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@description", description);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}