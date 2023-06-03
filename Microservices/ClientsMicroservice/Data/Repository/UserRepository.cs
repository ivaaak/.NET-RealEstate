#nullable disable
using ClientsMicroservice.Data.Context;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.Entities.Users;
using System.Linq.Expressions;

namespace ClientsMicroservice.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDBContext _context;

        public UserRepository(UsersDBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<UserEntity>> FindAsync(int pageNumber = 0, int pageSize = 10)
        {
            return await _context.UserEntities.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
        }


        public async Task<IEnumerable<UserEntity>> FindAsync(Expression<Func<UserEntity, bool>> query, int pageNumber = 0,
            int pageSize = 10)
        {
            return await _context.UserEntities.Where(query).Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
        }


        public Task UpdateAsync(UserEntity user)
        {
            _context.UserEntities.Update(user);
            return _context.SaveChangesAsync();
        }

        public async Task<UserEntity> FindByIdAsync(Guid id)
        {
            return await _context.UserEntities.FirstAsync(x => x.Id == id.ToString());
        }


        public async Task<UserEntity> FindByUsernameAsync(string name)
        {
            return await _context.UserEntities.FirstOrDefaultAsync(x => x.Username == name);
        }


        public async Task<IEnumerable<UserAttribute>> GetAttributesAsync(Guid userId)
        {
            var user = await _context.UserEntities.Include(x => x.UserAttributes).FirstAsync(x => x.Id == userId.ToString());
            if (user == null)
            {
                return null;
            }
            return user.UserAttributes;
        }


        //public async Task<KeycloakUserEntity> InsertOneAsync(KeycloakUserEntity userEntity)
        //{
        //    // save userEntity
        //    _context.UserEntities.Add(userEntity);
        //    await _context.SaveChangesAsync();

        //    return userEntity;
        //}


        //public Task DeleteAsync(KeycloakUserEntity userEntity)
        //{
        //    _context.UserEntities.Remove(userEntity);
        //    return _context.SaveChangesAsync();
        //}
    }
}
