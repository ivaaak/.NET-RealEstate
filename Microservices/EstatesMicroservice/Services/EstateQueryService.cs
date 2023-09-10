using AutoMapper;
using EstatesMicroservice.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.QueryObjects;

namespace EstatesMicroservice.Services
{
    public class EstateQueryService : IEstateQueryService
    {
        private readonly IRepository repository;

        private readonly IMapper mapper;

        private readonly IMediator mediator;

        public EstateQueryService(
            IRepository repository,
            IMapper mapper,
            IMediator mediator)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // Filter / Sort / Paginate
        public async Task<PagedResult<EstateDTO>> FindByCriteriaAsync(SearchCriteriaObject criteria)
        {
            var query = repository.All<Estate>();

            // Apply filters based on the criteria -> Search Term
            // TODO make this separate filters for multiple fields 
            // only 1 searchterm supported atm
            if (!string.IsNullOrEmpty(criteria.SearchTerm))
            {
                query = query.Where(e =>
                    e.Estate_Name.Contains(criteria.SearchTerm) ||
                    e.Estate_Description.Contains(criteria.SearchTerm) ||
                    e.Estate_Type.Type_Name.Contains(criteria.SearchTerm) ||
                    e.Listing.Name.Contains(criteria.SearchTerm));
            }

            // Apply sorting
            // Apply sorting
            if (!string.IsNullOrEmpty(criteria.SortBy))
            {
                // Try to find a field in the Estate Entity == SortBy in the SearchCriteriaObject
                var sortingProperty = typeof(Estate).GetProperty(criteria.SortBy);

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

            // Calculate total count before applying pagination
            var totalCount = await query.CountAsync();

            // Apply pagination
            var pagedQuery = query
                .Skip((criteria.PageNumber - 1) * criteria.PageSize)
                .Take(criteria.PageSize);

            var estates = await pagedQuery.ToListAsync();

            var estateDTOs = mapper.Map<IEnumerable<EstateDTO>>(estates);

            return new PagedResult<EstateDTO>
            {
                Items = estateDTOs,
                TotalItems = totalCount,
                PageNumber = criteria.PageNumber,
                PageSize = criteria.PageSize
            };
        }
    }
}
