using ContractsMicroservice.Services.Interfaces;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.Entities.Misc;

namespace ContractsMicroservice.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepository repo;

        public DocumentService(IRepository _repo)
        {
            repo = _repo;
        }


        public void UploadDocument(int userId, DocumentModel model)
        {
            ValidateModel(model);

            if (userId != model.UserId)
            {
                throw new ArgumentException("Invalid userId");
            }

            // Save the file to a secure location
            repo.AddAsync(model);
            repo.SaveChanges();
        }


        public IEnumerable<DocumentModel> GetDocumentsList(int userId)
        {
            // Validate the userId
            if (userId <= 0)
            {
                throw new ArgumentException("The userId must be a positive integer.");
            }

            // Retrieve the list of documents for the specified user
            var documents = repo.All<DocumentModel>().Where(d => d.UserId == userId).ToList();

            return documents;
        }


        public async Task DownloadDocument(HttpResponse response, int userId, int documentId)
        {
            // Retrieve the specified document
            var document = repo.GetByIdAsync<DocumentModel>(documentId).Result;

            if (document == null)
            {
                throw new ArgumentException("Invalid documentId");
            }

            if (userId != document.UserId)
            {
                throw new ArgumentException("Invalid userId");
            }

            // Send the document to the client as a download
            var memory = new MemoryStream();
            await memory.WriteAsync(document.FileContent, 0, document.FileContent.Length);
            memory.Position = 0;
            response.ContentType = GetContentType(document.FileName);
            response.Headers.Add("Content-Disposition", "attachment; filename=" + document.FileName);

            await response.Body.WriteAsync(document.FileContent, 0, document.FileContent.Length);
        }


        public async Task DeleteDocument(int userId, int documentId)
        {
            // retrieve the document
            var document = await repo.GetByIdAsync<DocumentModel>(documentId);

            // check that the document belongs to the specified user
            if (document.UserId != userId)
            {
                throw new ArgumentException("Invalid userId");
            }

            // delete the document
            await repo.DeleteAsync<DocumentModel>(document);
        }


        public async Task<bool> CheckIfUserHasDocument(int userId, int documentId)
        {
            // retrieve the document
            var document = await repo.GetByIdAsync<DocumentModel>(documentId);

            // check if the document belongs to the specified user
            return document.UserId == userId;
        }


        public void ValidateModel(DocumentModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.FileName))
            {
                throw new ArgumentException("FileName cannot be null or empty", nameof(model));
            }

            if (string.IsNullOrEmpty(model.ContentType))
            {
                throw new ArgumentException("ContentType cannot be null or empty", nameof(model));
            }
        }


        public string GetContentType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            var contentType = "application/octet-stream";

            if (extension == ".pdf")
            {
                contentType = "application/pdf";
            }
            else if (extension == ".docx")
            {
                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            }
            else if (extension == ".xlsx")
            {
                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }

            return contentType;
        }
    }
}
