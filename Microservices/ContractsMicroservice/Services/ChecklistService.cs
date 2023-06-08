using ContractsMicroservice.Services.Interfaces;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.Entities.Contracts;

namespace ContractsMicroservice.Services
{
    public class ChecklistService : IChecklistService
    {
        private readonly IRepository repo;

        public ChecklistService(IRepository _repo)
        {
            repo = _repo;
        }


        public IEnumerable<Checklist> GetChecklistsList(int userId)
        {
            // Validate the userId
            if (userId <= 0)
            {
                throw new ArgumentException("The userId must be a positive integer.");
            }

            // Retrieve the list of documents for the specified user
            var documents = repo.All<Checklist>().Where(d => d.Client_Id == userId.ToString()).ToList();

            return documents;
        }


        public async Task DeleteChecklist(int userId, int documentId)
        {
            // retrieve the document
            var document = await repo.GetByIdAsync<Checklist>(documentId);

            // check that the document belongs to the specified user
            if (document.Client_Id != userId.ToString())
            {
                throw new ArgumentException("Invalid userId");
            }

            // delete the document
            await repo.DeleteAsync<Checklist>(document);
        }


        public async Task<bool> CheckIfUserHasChecklist(int userId, int documentId)
        {
            // retrieve the document
            var document = await repo.GetByIdAsync<Checklist>(documentId);

            // check if the document belongs to the specified user
            return document.Client_Id == userId.ToString();
        }


        public void ValidateModel(Checklist model)
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
    }
}
