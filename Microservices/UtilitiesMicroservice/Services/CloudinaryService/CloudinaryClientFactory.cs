using CloudinaryDotNet;

namespace UtilitiesMicroservice.Services.CloudinaryService
{
    public static class CloudinaryClientFactory
    {
        public static Cloudinary GetInstance(IConfiguration configuration)
        {
            var cloud = configuration["cloudinary-cloud"];

            var apiKey = configuration["cloudinary-apiKey"];

            var apiSecret = configuration["cloudinary-apiSecret"];

            Account account = new Account(cloud, apiKey, apiSecret);

            Cloudinary clientInstance = new Cloudinary(account);

            return clientInstance;
        }
    }
}
