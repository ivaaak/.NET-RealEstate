using RealEstate.Data.Identity;
using RealEstate.Models.ViewModels.Clients;

namespace RealEstate.Microservices.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<ClientViewModel>> GetUsers();

        Task<ClientEditViewModel> GetUserForEdit(string id);

        Task<bool> UpdateUser(ClientEditViewModel model);

        Task<ApplicationUser> GetUserById(string id);
    }
}
