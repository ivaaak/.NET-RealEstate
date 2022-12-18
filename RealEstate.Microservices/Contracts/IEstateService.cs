using RealEstate.Models.Entities.Estates;
using RealEstate.Models.ViewModels.Estates;

namespace RealEstate.Microservices.Contracts
{
    public interface IEstateService
    {

        // CREATE
        void Create(Estate model);

        // GET BY ID
        Task<Estate> GetEstateById(int id);

        // GET FOR EDIT
        Task<EstateViewModel> GetEstateForEdit(int id);

        // GET ALL
        Task<IEnumerable<EstateViewModel>> GetEstates();

        // UPDATE
        Task<bool> UpdateEstate(int id, EstateViewModel model);

        // HARD DELETE
        Task<bool> HardDeleteEstate(int id);

        // SOFT DELETE
        Task<bool> SoftDeleteEstate(int id);

        // SEARCH
        Task<IEnumerable<EstateViewModel>> SearchEstates(string searchTerm);
    }
}
