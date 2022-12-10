using MediatR;
using RealEstate.CQRS.BehaviorModels.ResponseModels;
using RealEstate.CQRS.Commands.Update;
using RealEstate.Infrastructure.Data.Identity;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.CQRS.Handlers.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Response>
    {
        private readonly IApplicationDbRepository repo;

        public UpdateUserHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public Task<Response> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updatedUser = new ApplicationUser()
            {
                UserName = request.UserName,
                Email = request.Email,
            };

            repo.Update(updatedUser);

            return (Task<Response>)Task.CompletedTask;
        }
    }
}
