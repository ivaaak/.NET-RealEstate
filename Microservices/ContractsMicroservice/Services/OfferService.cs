using ContractsMicroservice.Services.Interfaces;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.Entities.Contracts;

namespace ContractsMicroservice.Services
{
    public class OfferService : IOfferService
    {
        private readonly IRepository repo;

        public OfferService(IRepository _repo)
        {
            repo = _repo;
        }


        public void UploadOffer(int userId, Offer model)
        {
            ValidateModel(model);

            if (userId.ToString() != model.Client_Id)
            {
                throw new ArgumentException("Invalid userId");
            }

            // Save the file to a secure location
            repo.AddAsync(model);
            repo.SaveChanges();
        }


        public IEnumerable<Offer> GetOffersList(int userId)
        {
            // Validate the userId
            if (userId <= 0)
            {
                throw new ArgumentException("The userId must be a positive integer.");
            }

            // Retrieve the list of documents for the specified user
            var documents = repo.All<Offer>().Where(d => d.Client_Id == userId.ToString()).ToList();

            return documents;
        }


        public async Task DownloadOffer(HttpResponse response, int userId, int documentId)
        {
            // Retrieve the specified document
            var document = repo.GetByIdAsync<Offer>(documentId).Result;

            if (document == null)
            {
                throw new ArgumentException("Invalid documentId");
            }

            if (userId.ToString() != document.Client_Id)
            {
                throw new ArgumentException("Invalid userId");
            }

            // Send the document to the client as a download
            var memory = new MemoryStream();
            //await memory.WriteAsync(document.Text_Content, 0, document.Text_Content.Length);
            memory.Position = 0;
            response.ContentType = GetContentType(document.Title);
            response.Headers.Add("Content-Disposition", "attachment; filename=" + document.Title);

            //await response.Body.WriteAsync(document.Text_Content, 0, document.Text_Content.Length);
        }


        public async Task DeleteOffer(int userId, int documentId)
        {
            // retrieve the document
            var document = await repo.GetByIdAsync<Offer>(documentId);

            // check that the document belongs to the specified user
            if (document.Client_Id != userId.ToString())
            {
                throw new ArgumentException("Invalid userId");
            }

            // delete the document
            await repo.DeleteAsync<Offer>(document);
        }


        public async Task<bool> CheckIfUserHasOffer(int userId, int documentId)
        {
            // retrieve the document
            var document = await repo.GetByIdAsync<Offer>(documentId);

            // check if the document belongs to the specified user
            return document.Client_Id == userId.ToString();
        }


        public void ValidateModel(Offer model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.Title))
            {
                throw new ArgumentException("Title cannot be null or empty", nameof(model));
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
