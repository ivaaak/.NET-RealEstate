using RealEstate.Shared.Models.DTOs.Clients;
using RealEstate.Shared.Models.Entities.Identity;

namespace RealEstate.API.Authentication.Contracts
{
    public interface IUserService
    {
        // GET BY ID
        Task<ApplicationUser> GetUserById(string id);

        // GET BY NAME AND PASSWORD
        Task<ApplicationUser> GetUserByUsernameAndPassword(string username, string password);

        // GET ALL
        Task<IEnumerable<ClientDTO>> GetUsers();

        // GET FOR EDIT
        Task<ClientEditDTO> GetUserForEdit(string id);

        // UPDATE
        Task<bool> UpdateUser(ClientEditDTO model);

        // HARD DELETE
        Task<bool> HardDeleteUser(string id);

        // SOFT DELETE
        Task<bool> SoftDeleteUser(string id);

        // CHANGE PASSWORD
        Task<bool> ChangePassword(string id, string newPassword);

        // SEARCH USERS
        Task<IEnumerable<ClientDTO>> SearchUsers(string searchTerm);

        // GET USER ROLES
        Task<string> GetUserRole(string id);

        // USER HAS ROLE
        Task<bool> UserHasRole(string id, string role);
    }
}
