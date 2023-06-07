using AutoMapper;
using ClientsMicroservice.Data.Repository;
using ClientsMicroservice.Services.Interfaces;
using RealEstate.Shared.Models.Entities.Users;

namespace ClientsMicroservice.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository) //IMapper mapper)
        {
            _userRepository = userRepository;
            // _mapper = mapper;
        }


        // GetUserById
        public Task<UserEntity> GetUserById(Guid UserId)
        {
            var user = _userRepository.FindByIdAsync(UserId);

            return user;
        }

        // GetUserByUserName
        public Task<UserEntity> GetUserByUserName(string Username)
        {
            var user = _userRepository.FindByUsernameAsync(Username);

            return user;
        }

        // GetUserAttributesById
        public Task<IEnumerable<UserAttribute>> GetUserAttributesById(Guid UserId)
        {
            var attributes = _userRepository.GetAttributesAsync(UserId);

            return attributes;
        }


        // GetUsers
        public IEnumerable<UserEntity> GetUsers(int Page, int PageSize)
        {
            IEnumerable<UserEntity> result;
            if (PageSize != 0)
            {
                result = _userRepository.FindAsync(Page, PageSize).Result;
            }
            else
            {
                result = _userRepository.FindAsync().Result;
            }

            return result;
        }
    }
}
