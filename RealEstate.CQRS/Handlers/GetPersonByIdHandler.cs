using MediatR;
using RealEstate.Core.ViewModels;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Data.Identity;
using RealEstate.Infrastructure.Data.Repositories;

namespace RealEstate.CQRS.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, UserViewModel>
    {
        private readonly IApplicationDbRepository repo;
        public GetPersonByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<UserViewModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;

            var foundUser = await repo.GetByIdAsync<ApplicationUser>(id);

            var userViewModel = new UserViewModel
            {
                Id = foundUser.Id,
                FirstName = foundUser.FirstName,
                LastName = foundUser.LastName,
                Email = foundUser.Email,
                NormalizedUserName = foundUser.NormalizedUserName,
                UserName = foundUser.UserName,
            };

            return userViewModel;
        }
    }
}
