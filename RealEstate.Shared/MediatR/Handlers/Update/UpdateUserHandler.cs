using MediatR;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.MediatR.BehaviorModels.ResponseModels;
using RealEstate.Shared.MediatR.Commands.Update;
using RealEstate.Shared.Models.Entities.Identity;

namespace RealEstate.Shared.MediatR.Handlers.Update
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
