using RealEstate.Shared.Models.Entities.Users;
using System.Linq.Expressions;

namespace ClientsMicroservice.Data.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> FindAsync(int pageNumber = 0, int pageSize = 10);

        Task<IEnumerable<UserEntity>> FindAsync(
            Expression<Func<UserEntity, bool>> query,
            int pageNumber = 0,
            int pageSize = 10);

        Task<UserEntity> FindByUsernameAsync(string name);

        Task<UserEntity> FindByIdAsync(Guid id);

        Task<IEnumerable<UserAttribute>> GetAttributesAsync(Guid userId);

        Task UpdateAsync(UserEntity user);
    }
}
