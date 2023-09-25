using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.Linq.Expressions;

namespace RealEstate.Shared.Data.Repository
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> All<T>() where T : class, IDeletableEntity;

        IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class, IDeletableEntity;

        IQueryable<T> AllReadonly<T>() where T : class, IDeletableEntity;

        IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class, IDeletableEntity;

        Task<T> GetByIdAsync<T>(object id) where T : class, IDeletableEntity;

        IQueryable<T> GetByIdsAsync<T>(object[] id) where T : class, IDeletableEntity;

        Task AddAsync<T>(T entity) where T : class, IDeletableEntity;

        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class, IDeletableEntity;

        void Update<T>(T entity) where T : class, IDeletableEntity; // softdelete check here?

        void UpdateRange<T>(IEnumerable<T> entities) where T : class, IDeletableEntity;

        void Delete<T>(T entity) where T : class, IDeletableEntity;

        void Detach<T>(T entity) where T : class, IDeletableEntity;

        int SaveChanges();

        Task<int> SaveChangesAsync();


        // Soft Delete:
        Task DeleteAsync<T>(object id) where T : class, IDeletableEntity;

        void DeleteRange<T>(IEnumerable<T> entities) where T : class, IDeletableEntity;

        void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class, IDeletableEntity;

        Task UndeleteAsync<T>(object id) where T : class, IDeletableEntity;
    }
}
