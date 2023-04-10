using CloudinaryDotNet;

namespace UtilitiesMicroservice.Services.CloudinaryService
{
    public interface ICloudinaryService
    {
        Task<string> UploadImage(
            IFormFile fileForm,
            string name,
            Transformation? transformation = null);
    }
}
