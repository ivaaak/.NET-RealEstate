using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.DTOs.Listings;
using RealEstate.Shared.Models.Entities.Listings;
using RealEstate.Shared.Models.QueryObjects;
using System.Linq.Expressions;

namespace ListingsMicroservice.Services
{
    public class ListingQueryService : IListingQueryService
    {
        private readonly IRepository repository;

        private readonly IMapper mapper;

        public ListingQueryService(
            IRepository repository,
            IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        // Filter / Sort / Paginate
        public async Task<PagedResult<ListingDTO>> FindByCriteriaAsync(SearchCriteriaObject criteria)
        {
            var query = repository.All<Listing>();

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

            // Map Listing to ListingDTO
            var listingDTOs = mapper.Map<IEnumerable<ListingDTO>>(query);

            return new PagedResult<ListingDTO>
            {
                Items = listingDTOs,
                TotalItems = totalCount,
                PageNumber = criteria.PageNumber,
                PageSize = criteria.PageSize
            };
        }


        // Sorting
        private IQueryable<Listing> ApplySorting(SearchCriteriaObject criteria, IQueryable<Listing>? query)
        {
            // Apply sorting
            if (!string.IsNullOrEmpty(criteria.SortByColumn) && query != null)
            {
                // Try to find a field in the Listing Entity == SortBy in the SearchCriteriaObject
                var sortingProperty = typeof(Listing).GetProperty(criteria.SortByColumn);

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
                    // For example, you can sort by a default column like Listing_Name
                    query = criteria.SortDescending
                        ? query.OrderByDescending(e => e.Name)
                        : query.OrderBy(e => e.Name);
                }
            }

            return query;
        }


        // Filtration
        private IQueryable<Listing> ApplyFiltering(SearchCriteriaObject criteria, string? searchTerm, IQueryable<Listing>? query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (!string.IsNullOrEmpty(criteria.FilterByColumn) && !string.IsNullOrEmpty(searchTerm))
            {
                var filteringProperty = typeof(Listing).GetProperty(criteria.FilterByColumn);

                if (filteringProperty != null)
                {
                    var parameter = Expression.Parameter(typeof(Listing), "e");
                    var propertyAccess = Expression.Property(parameter, filteringProperty);
                    var searchValue = Expression.Constant(searchTerm, typeof(string));
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var toLowerMethod = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);

                    // Make the search case-insensitive
                    var propertyToLower = Expression.Call(propertyAccess, toLowerMethod);
                    var searchValueToLower = Expression.Call(searchValue, toLowerMethod);

                    var containsExpression = Expression.Call(propertyToLower, containsMethod, searchValueToLower);
                    var lambda = Expression.Lambda<Func<Listing, bool>>(containsExpression, parameter);
                    return query.Where(lambda);
                }
                else
                {
                    // Filtering column doesnt exist
                    throw new ArgumentException($"Sorting column '{criteria.FilterByColumn}' does not exist.");
                }
            }

            // If no filter criteria are provided, return the original query
            return query;
        }


        // Pagination
        private IQueryable<Listing> ApplyPagination(SearchCriteriaObject criteria, IQueryable<Listing>? query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (criteria.PageNumber >= 0 && criteria.PageSize > 0)
            {
                var pagedQuery = query
                    .Skip((criteria.PageNumber - 1) * criteria.PageSize)
                    .Take(criteria.PageSize);

                query = (IQueryable<Listing>)pagedQuery.ToList();
            }
            else
            {
                throw new ArgumentException(nameof(criteria));
            }

            return query;
        }
    }
}
