using RealEstate.Core.ViewModels.Clients;
using RealEstate.Infrastructure.Data.Identity;

namespace RealEstate.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<ClientViewModel>> GetUsers();

        Task<ClientEditViewModel> GetUserForEdit(string id);

        Task<bool> UpdateUser(ClientEditViewModel model);

        Task<ApplicationUser> GetUserById(string id);
    }
}
