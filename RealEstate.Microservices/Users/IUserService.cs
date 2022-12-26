using RealEstate.Data.Identity;
using RealEstate.Models.ViewModels.Clients;

namespace RealEstate.Microservices.Users
{
    public interface IUserService
    {
        // GET BY ID
        Task<ApplicationUser> GetUserById(string id);

        // GET ALL
        Task<IEnumerable<ClientViewModel>> GetUsers();

        // GET FOR EDIT
        Task<ClientEditViewModel> GetUserForEdit(string id);

        // UPDATE
        Task<bool> UpdateUser(ClientEditViewModel model);

        // HARD DELETE
        Task<bool> HardDeleteUser(string id);

        // SOFT DELETE
        Task<bool> SoftDeleteUser(string id);

        // CHANGE PASSWORD
        Task<bool> ChangePassword(string id, string newPassword);

        // SEARCH USERS
        Task<IEnumerable<ClientViewModel>> SearchUsers(string searchTerm);

        // GET USER ROLES
        Task<string> GetUserRole(string id);

        // USER HAS ROLE
        Task<bool> UserHasRole(string id, string role);
    }
}
