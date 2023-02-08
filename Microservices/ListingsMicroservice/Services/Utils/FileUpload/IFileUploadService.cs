using Microsoft.AspNetCore.Http;

<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/Utils/FileUpload/IFileUploadService.cs
namespace RealEstate.Microservices.Utils.FileUpload
=======
<<<<<<< Updated upstream:Microservices/ListingsMicroservice/Services/FileUpload/IFileUploadService.cs
namespace RealEstate.Microservices.FileUpload
=======
namespace UtilitiesMicroservice.Services.FileUpload
>>>>>>> Stashed changes:Microservices/UtilitiesMicroservice/Services/FileUpload/IFileUploadService.cs
>>>>>>> Stashed changes:Microservices/ListingsMicroservice/Services/FileUpload/IFileUploadService.cs
{
    public interface IFileUploadService
    {
        // UPLOAD
        Task<bool> UploadFile(IFormFile file, string fileType);

        // HARD DELETE
        Task<bool> DeleteFile(int id);

        // SOFT DELETE
        Task<bool> SoftDeleteFile(int id);

        // UPDATE FILE
        Task<bool> UpdateFile(int id, IFormFile file, string fileType);
    }
}
