using MediatR;
using RealEstate.Core.ViewModels;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Data.Identity;
using RealEstate.Infrastructure.Data.Repositories;

namespace RealEstate.CQRS.Handlers
{
    public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<UserListViewModel>>
    {
        private readonly IApplicationDbRepository repo;
        public GetPersonListHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public Task<List<UserListViewModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repo.All<ApplicationUser>()
                .Select(u => new UserListViewModel 
                    { 
                        Id = u.Id,
                        Email = u.Email, 
                        Name = u.UserName
                    })
                .ToList());
        }
    }
}
