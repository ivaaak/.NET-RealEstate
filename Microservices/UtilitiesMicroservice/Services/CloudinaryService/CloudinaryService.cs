using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace UtilitiesMicroservice.Services.CloudinaryService
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinaryClient;

        public CloudinaryService(Cloudinary cloudinaryClient)
        {
            this._cloudinaryClient = cloudinaryClient ?? throw new ArgumentNullException(nameof(cloudinaryClient));
        }

        public async Task<string> UploadImage(
            IFormFile fileForm,
            string name,
            Transformation? transformation = null)
        {
            fileForm = fileForm ?? throw new ArgumentNullException(nameof(fileForm));

            byte[] imageFile;

            using (var memoryStream = new MemoryStream())
            {
                await fileForm.CopyToAsync(memoryStream);
                imageFile = memoryStream.ToArray();
            }

            var imageStream = new MemoryStream(imageFile);

            var uploadParameters = new ImageUploadParams()
            {
                File = new FileDescription(name, imageStream),
                Transformation = transformation
            };

            var uploadResult = _cloudinaryClient.Upload(uploadParameters);

            imageStream.Dispose();

            return uploadResult.SecureUrl.AbsoluteUri;
        }
    }
}
