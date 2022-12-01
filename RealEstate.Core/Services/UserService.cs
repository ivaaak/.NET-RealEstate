using Microsoft.EntityFrameworkCore;
using RealEstate.Core.ServiceContracts;
using RealEstate.Core.ViewModels.Clients;
using RealEstate.Infrastructure.Data.Identity;
using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;

        public UserService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await repo.GetByIdAsync<ApplicationUser>(id);
        }

        public async Task<ClientEditViewModel> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<Client>(id);

            return new ClientEditViewModel()
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

        public async Task<IEnumerable<ClientViewModel>> GetUsers()
        {
            return await repo.All<Client>()
            .Select(u => new ClientViewModel()
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

        public async Task<bool> UpdateUser(ClientEditViewModel model)
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
    }
}
