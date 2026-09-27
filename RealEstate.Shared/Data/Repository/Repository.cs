#nullable disable
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RealEstate.Shared.Data.Cache;
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.Linq.Expressions;

namespace RealEstate.Shared.Data.Repository
{
    public class Repository : IRepository
    {
        protected DbContext Context { get; set; }
        protected ICacheService _cacheService { get; set; }


        protected DbSet<T> DbSet<T>() where T : class
        {
            return Context.Set<T>();
        }

// ================================== Add Methods ==================================
        public async Task AddAsync<T>(T entity) where T : class, IDeletableEntity
        {
            DbSet<T>().Add(entity);
            await SaveChangesAsync();
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class, IDeletableEntity
        {
            DbSet<T>().AddRange(entities);
            await SaveChangesAsync();
        }


// ================================== Get All Methods  ==================================
        // Queries are intentionally not cached: an IQueryable can't be serialized/deserialized through Redis,
        // and cached (untracked) entities would silently break change tracking for updates.
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


        // ================================== Get Single Entity Methods  ==================================
        // All primary keys are strings (IDeletableEntity.Id), so ids passed as int/Guid are normalized to string
        public async Task<T> GetByIdAsync<T>(object id) where T : class, IDeletableEntity
        {
            var key = id?.ToString();

            return await DbSet<T>()
                .Where(e => !e.IsDeleted && e.Id == key)
                .FirstOrDefaultAsync();
        }


        public IQueryable<T> GetByIdsAsync<T>(object[] id) where T : class, IDeletableEntity
        {
            var keys = id.Select(i => i?.ToString()).ToArray();

            return DbSet<T>().Where(e => !e.IsDeleted && keys.Contains(e.Id)).AsQueryable();
        }


// ================================== Update Methods  ==================================
        public void Update<T>(T entity) where T : class, IDeletableEntity
        {
            DbSet<T>().Update(entity);
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : class, IDeletableEntity
        {
            DbSet<T>().UpdateRange(entities);
        }


// ================================== Delete Methods  ==================================
        public void Delete<T>(T entity) where T : class, IDeletableEntity
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
                await SaveChangesAsync();
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
            // GetByIdAsync filters out soft-deleted rows, so look the entity up directly
            var key = id?.ToString();
            T entity = await DbSet<T>().FirstOrDefaultAsync(e => e.Id == key);

            if (entity != null)
            {
                entity.IsDeleted = false;
                entity.DeletedOn = null;
                Update(entity);
                await SaveChangesAsync();
            }
        }

        public void Detach<T>(T entity) where T : class, IDeletableEntity
        {
            EntityEntry entry = Context.Entry(entity);

            entry.State = EntityState.Detached;
        }


// ================================== Save Methods  ==================================
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }


// ================================== Implement the Dispose method / Pattern  ==================================
// Sonar Rule 3881 (IDisposable should be implemented correctly)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // The DbContext is owned (and disposed/returned to the pool) by the DI container, not by the repository
        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
