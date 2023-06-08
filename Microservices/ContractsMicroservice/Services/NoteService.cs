using ContractsMicroservice.Services.Interfaces;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.Entities.Contracts;

namespace ContractsMicroservice.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository repo;

        public NoteService(IRepository _repo)
        {
            repo = _repo;
        }


        public IEnumerable<Note> GetNotesList(int userId)
        {
            // Validate the userId
            if (userId <= 0)
            {
                throw new ArgumentException("The userId must be a positive integer.");
            }

            // Retrieve the list of documents for the specified user
            var documents = repo.All<Note>().Where(d => d.Client_Id == userId.ToString()).ToList();

            return documents;
        }


        public async Task DeleteNote(int userId, int documentId)
        {
            // retrieve the document
            var document = await repo.GetByIdAsync<Note>(documentId);

            // check that the document belongs to the specified user
            if (document.Client_Id != userId.ToString())
            {
                throw new ArgumentException("Invalid userId");
            }

            // delete the document
            await repo.DeleteAsync<Note>(document);
        }


        public async Task<bool> CheckIfUserHasNote(int userId, int documentId)
        {
            // retrieve the document
            var document = await repo.GetByIdAsync<Note>(documentId);

            // check if the document belongs to the specified user
            return document.Client_Id == userId.ToString();
        }


        public void ValidateModel(Note model)
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
