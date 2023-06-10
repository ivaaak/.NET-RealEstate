using RealEstate.Shared.Models.Entities.Contracts;

namespace ContractsMicroservice.Services.Interfaces
{
    /// <summary>
    /// Represents a service for managing documents.
    /// </summary>
    public interface IOfferService
    {
        /// <summary>
        /// Uploads a document.
        /// </summary>
        /// <param name="userId">The ID of the user who owns the document.</param>
        /// <param name="model">The document to upload.</param>
        void UploadOffer(int userId, Offer model);

        /// <summary>
        /// Gets a list of documents for a user.
        /// </summary>
        /// <param name="userId">The ID of the user whose documents to retrieve.</param>
        /// <returns>A list of <see cref="OfferModel"/> objects representing the documents for the user.</returns>
        IEnumerable<Offer> GetOffersList(int userId);

        /// <summary>
        /// Downloads a document.
        /// </summary>
        /// <param name="response">The HTTP response object.</param>
        /// <param name="userId">The ID of the user who owns the document.</param>
        /// <param name="documentId">The ID of the document to download.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DownloadOffer(HttpResponse response, int userId, int documentId);

        /// <summary>
        /// Deletes a document.
        /// </summary>
        /// <param name="userId">The ID of the user who owns the document.</param>
        /// <param name="documentId">The ID of the document to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteOffer(int userId, int documentId);

        /// <summary>
        /// Checks if a user has a specific document.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="documentId">The ID of the document.</param>
        /// <returns>A task representing the asynchronous operation, with a result indicating whether the user has the document.</returns>
        Task<bool> CheckIfUserHasOffer(int userId, int documentId);

        /// <summary>
        /// Validates a document model.
        /// </summary>
        /// <param name="model">The document model to validate.</param>
        void ValidateModel(Offer model);

        /// <summary>
        /// Gets the content type for a file based on its name.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The content type for the file.</return

        string GetContentType(string fileName);
    }
}
