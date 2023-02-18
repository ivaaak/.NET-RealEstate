using Microsoft.AspNetCore.Http;

namespace UtilitiesMicroservice.Services.FileUpload
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
