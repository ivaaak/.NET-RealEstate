#nullable disable
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.Linq.Expressions;

namespace RealEstate.Shared.Data.Repository
{
    public class Repository : IRepository
    {
        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet<T>() where T : class
        {
            return Context.Set<T>();
        }

// Add Methods
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await DbSet<T>().AddRangeAsync(entities);
        }

// Get All Methods with Soft Delete
        public IQueryable<T> All<T>() where T : class, IDeletableEntity
        {
            return DbSet<T>()
                .Where(e => !e.IsDeleted)
                .AsQueryable();
        }

        public IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class, IDeletableEntity
        {
            return DbSet<T>()
                .Where(e => !e.IsDeleted)
                .Where(search)
                .AsQueryable();
        }

        public IQueryable<T> AllReadonly<T>() where T : class, IDeletableEntity
        {
            return DbSet<T>()
                .Where(e => !e.IsDeleted)
                .AsQueryable()
                .AsNoTracking();
        }

        public IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class, IDeletableEntity
        {
            return DbSet<T>()
                .Where(e => !e.IsDeleted)
                .Where(search)
                .AsQueryable()
                .AsNoTracking();
        }

// Get All Methods
        public async Task<T> GetByIdAsync<T>(object id) where T : class, IDeletableEntity
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<T> GetByIdsAsync<T>(object[] id) where T : class, IDeletableEntity
        {
            return await DbSet<T>().FindAsync(id);
        }

// Save Methods
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

// Update Methods
        public void Update<T>(T entity) where T : class
        {
            DbSet<T>().Update(entity);
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            DbSet<T>().UpdateRange(entities);
        }

//  Delete Methods
        public void Delete<T>(T entity) where T : class
        {
            EntityEntry entry = Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                DbSet<T>().Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

        public async Task DeleteAsync<T>(object id) where T : class, IDeletableEntity
        {
            T entity = await GetByIdAsync<T>(id);

            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DeletedOn = DateTime.UtcNow;
                Update(entity);
            }
        }

        public void DeleteRange<T>(IEnumerable<T> entities) where T : class, IDeletableEntity
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletedOn = DateTime.UtcNow;
            }

            UpdateRange(entities);
        }

        public void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class, IDeletableEntity
        {
            var entities = All(deleteWhereClause);
            DeleteRange(entities);
        }

        public async Task UndeleteAsync<T>(object id) where T : class, IDeletableEntity
        {
            T entity = await GetByIdAsync<T>(id);

            if (entity != null)
            {
                entity.IsDeleted = false;
                entity.DeletedOn = null;
                Update(entity);
            }
        }

        public void Detach<T>(T entity) where T : class
        {
            EntityEntry entry = Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

// Implement the Dispose method / Pattern
// Sonar Rule 3881 (IDisposable should be implemented correctly)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}
