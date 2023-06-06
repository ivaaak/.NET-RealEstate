using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.Entities.Estates;

namespace EstatesMicroservice.Services.Interfaces
{
    public interface IEstateService
    {

        // CREATE
        Task Create(Estate model);

        // GET BY ID
        Task<Estate> GetEstateById(int id);

        // GET FOR EDIT
        Task<EstateDTO> GetEstateForEdit(int id);

        // GET ALL
        Task<IEnumerable<EstateDTO>> GetEstates();

        // UPDATE
        Task<bool> UpdateEstate(int id, EstateDTO model);

        // HARD DELETE
        Task<bool> HardDeleteEstate(int id);

        // SOFT DELETE
        Task<bool> SoftDeleteEstate(int id);

        // SEARCH
        Task<IEnumerable<EstateDTO>> SearchEstates(string searchTerm);
    }
}
