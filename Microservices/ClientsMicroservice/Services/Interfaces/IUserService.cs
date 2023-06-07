using RealEstate.Shared.Models.Entities.Users;

namespace ClientsMicroservice.Services.Interfaces
{
    public interface IUserService
    {
        // GetUserById
        public Task<UserEntity> GetUserById(Guid UserId);


        // GetUserByUserName
        public Task<UserEntity> GetUserByUserName(string Username);


        // GetUserAttributesById
        public Task<IEnumerable<UserAttribute>> GetUserAttributesById(Guid UserId);


        // GetUsers
        public IEnumerable<UserEntity> GetUsers(int Page, int PageSize);
    }
}
