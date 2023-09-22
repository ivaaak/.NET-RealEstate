using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.Entities.Misc;

namespace UtilitiesMicroservice.Services.FileUpload
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IRepository repo;

        public FileUploadService(IRepository _repo)
        {
            repo = _repo;
        }

        // UPLOAD
        public async Task<bool> UploadFile(IFormFile file, string fileType)
        {
            bool result = false;

            if (file == null || file.Length == 0)
            {
                return result;
            }

            // Validate file type
            if (fileType != "image" && fileType != "video")
            {
                return result;
            }

            // Read file into a byte array
            byte[] fileData;
            using (var stream = file.OpenReadStream())
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    fileData = memoryStream.ToArray();
                }
            }

            // Create a new File entity and save to the database
            var fileEntity = new FileEntity
            {
                FileName = file.FileName,
                FileType = fileType,
                Data = fileData
            };
            await repo.AddAsync(fileEntity);
            await repo.SaveChangesAsync();

            result = true;
            return result;
        }

        // HARD DELETE
        public async Task<bool> DeleteFile(int id)
        {
            bool result = false;
            var file = await repo.GetByIdAsync<FileEntity>(id);

            if (file != null)
            {
                repo.Delete(file);
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // SOFT DELETE
        public async Task<bool> SoftDeleteFile(int id)
        {
            bool result = false;
            var file = await repo.GetByIdAsync<FileEntity>(id);

            if (file != null)
            {
                file.IsDeleted = true;
                file.DeletedOn = DateTime.UtcNow;
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // UPDATE FILE
        public async Task<bool> UpdateFile(int id, IFormFile file, string fileType)
        {
            bool result = false;
            var existingFile = await repo.GetByIdAsync<FileEntity>(id);

            if (existingFile != null)
            {
                // Validate file type
                if (fileType != "image" && fileType != "video")
                {
                    return result;
                }

                // Read file into a byte array
                byte[] fileData;
                using (var stream = file.OpenReadStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        fileData = memoryStream.ToArray();
                    }
                }

                // Update the file's metadata and data
                existingFile.FileName = file.FileName;
                existingFile.FileType = fileType;
                existingFile.Data = fileData;
                await repo.SaveChangesAsync();

                result = true;
            }

            return result;
        }
    }
}
 