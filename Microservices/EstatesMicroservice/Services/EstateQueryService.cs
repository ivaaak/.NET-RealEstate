using AutoMapper;
using EstatesMicroservice.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.QueryObjects;
using System.Linq.Expressions;

namespace EstatesMicroservice.Services
{
    public class EstateQueryService : IEstateQueryService
    {
        private readonly IRepository repository;

        private readonly IMapper mapper;

        public EstateQueryService(
            IRepository repository,
            IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Filter / Sort / Paginate
        public async Task<PagedResult<EstateDTO>> FindByCriteriaAsync(SearchCriteriaObject criteria)
        {
            var query = repository.All<Estate>();

            // Filtration
            var filteredQuery = ApplyFiltering(criteria, criteria.SearchTerm, query);
            if (filteredQuery != null) { query = filteredQuery; }

            // Sorting
            var sortedQuery = ApplySorting(criteria, query);
            if (sortedQuery != null) { query = sortedQuery; }

            // Calculate total count before applying pagination
            var totalCount = await query.CountAsync();

            // Pagination
            var pagedQuery = ApplyPagination(criteria, query);
            if (pagedQuery != null) { query = pagedQuery; }

            // Map Estates to EstateDTOs
            var estateDTOs = mapper.Map<IEnumerable<EstateDTO>>(query);

            return new PagedResult<EstateDTO>
            {
                Items = estateDTOs,
                TotalItems = totalCount,
                PageNumber = criteria.PageNumber,
                PageSize = criteria.PageSize
            };
        }


        // Sorting
        private IQueryable<Estate> ApplySorting(SearchCriteriaObject criteria, IQueryable<Estate>? query)
        {
            // Apply sorting
            if (!string.IsNullOrEmpty(criteria.SortByColumn) && query != null)
            {
                // Try to find a field in the Estate Entity == SortBy in the SearchCriteriaObject
                var sortingProperty = typeof(Estate).GetProperty(criteria.SortByColumn);

                if (sortingProperty != null) // Sorting column found -> sort by its key
                {
                    query = criteria.SortDescending
                        ? query.OrderByDescending(e => sortingProperty.GetValue(e))
                        : query.OrderBy(e => sortingProperty.GetValue(e));
                }
                else
                {
                    // Handle the case where the specified sorting column doesn't exist
                    // You can throw an exception or apply a default sorting logic here
                    // For example, you can sort by a default column like Estate_Name
                    query = criteria.SortDescending
                        ? query.OrderByDescending(e => e.Estate_Name)
                        : query.OrderBy(e => e.Estate_Name);
                }
            }

            return query;
        }


        // Filtration
        private IQueryable<Estate> ApplyFiltering(SearchCriteriaObject criteria, string? searchTerm, IQueryable<Estate>? query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (!string.IsNullOrEmpty(criteria.FilterByColumn) && !string.IsNullOrEmpty(searchTerm))
            {
                var filteringProperty = typeof(Estate).GetProperty(criteria.FilterByColumn);

                if (filteringProperty != null)
                {
                    var parameter = Expression.Parameter(typeof(Estate), "e");
                    var propertyAccess = Expression.Property(parameter, filteringProperty);
                    var searchValue = Expression.Constant(searchTerm, typeof(string));
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var toLowerMethod = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);

                    // Make the search case-insensitive
                    var propertyToLower = Expression.Call(propertyAccess, toLowerMethod);
                    var searchValueToLower = Expression.Call(searchValue, toLowerMethod);

                    var containsExpression = Expression.Call(propertyToLower, containsMethod, searchValueToLower);
                    var lambda = Expression.Lambda<Func<Estate, bool>>(containsExpression, parameter);
                    return query.Where(lambda);
                }
                else
                {
                    throw new ArgumentException($"Sorting column '{criteria.FilterByColumn}' does not exist.");
                }
            }

            return query;
        }


        // Pagination
        private IQueryable<Estate> ApplyPagination(SearchCriteriaObject criteria, IQueryable<Estate>? query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (criteria.PageNumber >= 0 && criteria.PageSize > 0) {
                var pagedQuery = query
                    .Skip((criteria.PageNumber - 1) * criteria.PageSize)
                    .Take(criteria.PageSize);

                query = (IQueryable<Estate>)pagedQuery.ToList();
            } 
            else 
            {
                throw new ArgumentException(nameof(criteria));
            }

            return query;
        }
    }
}
