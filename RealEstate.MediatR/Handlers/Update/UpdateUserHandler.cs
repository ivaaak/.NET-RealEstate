using MediatR;
using RealEstate.Data.Repository;
using RealEstate.MediatR.BehaviorModels.ResponseModels;
using RealEstate.MediatR.Commands.Update;
using RealEstate.Models.Entities.Identity;

namespace RealEstate.MediatR.Handlers.Update
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
