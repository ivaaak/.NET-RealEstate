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

        private readonly TimeSpan _defaultCacheExpiration = TimeSpan.FromMinutes(30);


// ================================== Add Methods ==================================
        public async Task AddAsync<T>(T entity) where T : class, IDeletableEntity
        {
            DbSet<T>().Add(entity);
            await SaveChangesAsync();

            // Update the cache with the newly added entity 
            var cacheKey = GetCacheKey<T>("GetById");
            _cacheService.Set(cacheKey, All<T>(), _defaultCacheExpiration);
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class, IDeletableEntity
        {
            DbSet<T>().AddRange(entities);
            await SaveChangesAsync();

            // Update the cache with the newly added entities 
            var cacheKey = GetCacheKey<T>("GetById");
            _cacheService.Set(cacheKey, All<T>(), _defaultCacheExpiration);
        }


// ================================== Get All Methods  ==================================
        public IQueryable<T> All<T>() where T : class, IDeletableEntity
        {
            var cacheKey = GetCacheKey<T>("GetAll");

            if (_cacheService.KeyExists(cacheKey))
            {
                return _cacheService.Get<IQueryable<T>>(cacheKey);
            }
            var data = DbSet<T>()
                .Where(e => !e.IsDeleted)
                .AsQueryable();

            // Add data to the cache for subsequent requests 
            _cacheService.Set(cacheKey, data, _defaultCacheExpiration);

            return data;
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
        public async Task<T> GetByIdAsync<T>(object id) where T : class, IDeletableEntity
        {
            // Create a unique cache key for this entity instance
            var cacheKey = GetCacheKey<T>("GetById", id);

            // Attempt to get the entity from the cache
            var cachedEntity = _cacheService.Get<T>(cacheKey);

            if (cachedEntity != null)
            {
                // If the entity is found in the cache, return it
                return cachedEntity;
            }
            else
            {
                // If not found in the cache, query the database
                var entity = await DbSet<T>()
                    .Where(e => !e.IsDeleted && id.Equals(e.Id))
                    .FirstOrDefaultAsync();

                if (entity != null)
                {
                    // If the entity is found in the database, store it in the cache
                    _cacheService.Set(cacheKey, entity);

                    return entity;
                }
                else
                {
                    // If the entity is not found in the database, return null
                    return null;
                }
            }
        }


        public IQueryable<T> GetByIdsAsync<T>(object[] id) where T : class, IDeletableEntity
        {
            return DbSet<T>().Where(e => !e.IsDeleted && id.Contains(e.Id)).AsQueryable();
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


// Helper method to get the cache key for GetById<T>
// GetCacheKey("id_goes_here", "GetById")
// Example output -  Listing_GetById_5f4e6f0c-3d3d-4d2a-9a7b-1e3bde8fcf98
        private string GetCacheKey<T>(string methodSignature, object? id = null) where T : class, IDeletableEntity
        {
            return $"{typeof(T).Name}_{methodSignature}_{id}";
        }


// ================================== Implement the Dispose method / Pattern  ==================================
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
