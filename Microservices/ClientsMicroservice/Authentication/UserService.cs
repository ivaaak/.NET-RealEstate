using ClientsMicroservice.Authentication.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.DTOs.Clients;
using RealEstate.Shared.Models.DTOs.Search;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Identity;
using System.Security.Cryptography;
using System.Text;

namespace ClientsMicroservice.Authentication
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;

        private IMediator mediator;

        public UserService(
            IApplicationDbRepository _repo,
            IMediator _mediator)
        {
            repo = _repo;
            mediator = _mediator;
        }

        // GET BY ID
        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await repo.GetByIdAsync<ApplicationUser>(id);
        }

        // GET BY USERNAME AND PASSWORD
        public async Task<ApplicationUser> GetUserByUsernameAndPassword(string username, string password)
        {
            return await repo
                .All<ApplicationUser>()
                .Where(x => x.UserName == username && x.PasswordHash == password)
                .FirstOrDefaultAsync();
        }

        // GET FOR EDIT
        public async Task<ClientEditDTO> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<Client>(id);

            return new ClientEditDTO()
            {
                Client_Id = user.Client_Id,
                Client_Name = user.Client_Name,
                Client_Address = user.Client_Address,
                Client_Details = user.Client_Details,
                Contact_Person = user.Contact_Person,
                EMail = user.EMail,
                Phone = user.Phone,
                Mobile = user.Mobile,
                Contracts = user.Contracts,
                Time_Created = user.Time_Created,
            };
        }

        // GET ALL
        public async Task<IEnumerable<ClientDTO>> GetUsers()
        {
            return await repo.All<Client>()
            .Select(u => new ClientDTO()
            {
                Client_Id = u.Client_Id,
                Client_Name = u.Client_Name,
                Client_Address = u.Client_Address,
                Client_Details = u.Client_Details,
                Contact_Person = u.Contact_Person,
                EMail = u.EMail,
                Phone = u.Phone,
                Mobile = u.Mobile,
                Contracts = u.Contracts,
                Time_Created = u.Time_Created,
            })
            .ToListAsync();
        }

        // UPDATE
        public async Task<bool> UpdateUser(ClientEditDTO model)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<Client>(model.Client_Id);

            if (user != null)
            {
                user.Client_Name = model.Client_Name;
                user.Client_Details = model.Client_Details;
                user.Client_Address = model.Client_Address;
                user.Contact_Person = model.Contact_Person;
                user.EMail = model.EMail;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // HARD DELETE
        public async Task<bool> HardDeleteUser(string id)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<Client>(id);

            if (user != null)
            {
                repo.Delete(user);
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // SOFT DELETE
        public async Task<bool> SoftDeleteUser(string id)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<ApplicationUser>(id);

            if (user != null)
            {
                user.IsDeleted = true;
                user.DeletedOn = DateTime.UtcNow;
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        // CHANGE PASSWORD
        public async Task<bool> ChangePassword(string id, string newPassword)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<Client>(id);

            if (user != null)
            {
                // Validate the new password
                if (ValidatePassword(newPassword))
                {
                    // Hash the new password
                    string hashedPassword = HashPassword(newPassword);

                    // Update the user's password
                    user.PasswordHash = hashedPassword;
                    await repo.SaveChangesAsync();
                    result = true;
                }
            }

            return result;
        }

        // HASH PASSWORD
        private string HashPassword(string password)
        {
            // Use a password hashing algorithm to hash the password
            // For example, you can use the SHA256 algorithm provided by the System.Security.Cryptography namespace
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute the hash of the password
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the hash to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // VALIDATE PW
        private bool ValidatePassword(string password)
        {
            if (password.Length < 8)
            {
                // Password is too short
                return false;
            }

            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower))
            {
                // Password does not contain a capital letter
                return false;
            }

            // Password is valid
            return true;
        }

        // SEARCH USERS
        public async Task<IEnumerable<ClientDTO>> SearchUsers(string searchTerm)
        {
            // Build a LINQ query to search the repository for users that match the search term
            var query = from u in repo.All<Client>()
                        where
                        u.Client_Name.Contains(searchTerm) ||
                        u.Client_Address.Contains(searchTerm) ||
                        u.Client_Details.Contains(searchTerm) ||
                        u.Contact_Person.Contains(searchTerm) ||
                        u.EMail.Contains(searchTerm) ||
                        u.Phone.Contains(searchTerm) ||
                        u.Mobile.Contains(searchTerm)
                        select u;

            // Execute the query and return the matching users as a list of ClientViewModel objects
            return await query.Select(u => new ClientDTO()
            {
                Client_Id = u.Client_Id,
                Client_Name = u.Client_Name,
                Client_Address = u.Client_Address,
                Client_Details = u.Client_Details,
                Contact_Person = u.Contact_Person,
                EMail = u.EMail,
                Phone = u.Phone,
                Mobile = u.Mobile,
                Contracts = u.Contracts,
                Time_Created = u.Time_Created,
            }).ToListAsync();
        }

        // GET USER ROLES
        public async Task<string> GetUserRole(string id)
        {
            var user = await repo.GetByIdAsync<Client>(id);

            if (user != null)
            {
                return user.Roles.ToString();
            }
            else
            {
                return "";
            }
        }

        // USER HAS ROLE
        public async Task<bool> UserHasRole(string id, string role)
        {
            var user = await repo.GetByIdAsync<Client>(id);

            if (user != null)
            {
                foreach (var userRole in user.Roles)
                {
                    return userRole.ToString() == role;
                }
                return false;
            }
            return false;
        }

        // MEDIATOR

        // MEDIATOR CREATE USER
        public async Task<bool> MediatorCreateUser(Client client)
        {
            // TODO return await mediator.Send(new CreateClientCommand(client));
            return await Task.FromException<bool>(new NotImplementedException());
        }

        // MEDIATOR GET BY ID
        public async Task<ClientDTO> MediatorGetClientById(string clientId)
        {
            return await mediator.Send(new GetClientByIdQuery(clientId));
        }

        // MEDIATOR GET ALL
        public async Task<List<ClientDTO>> MediatorGetClients()
        {
            return await mediator.Send(new GetClientListQuery());
        }

        // MEDIATOR DELETE
        public async Task<bool> MediatorDeleteClient(int estateId)
        {
            // TODO return await mediator.Send(new DeleteClientByIdCommand(estateId));
            return await Task.FromException<bool>(new NotImplementedException());
        }

        // MEDIATOR SEARCH
        public async Task<SearchDTO> MediatorSearchClient(string query)
        {
            return await mediator.Send(new ClientsSearchQuery(query));
        }
    }
}
