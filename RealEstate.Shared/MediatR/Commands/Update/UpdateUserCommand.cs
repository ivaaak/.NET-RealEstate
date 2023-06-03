using MediatR;
using RealEstate.Shared.MediatR.BehaviorModels.ResponseModels;

namespace RealEstate.Shared.MediatR.Commands.Update
{
    public class UpdateUserCommand : IRequest<Response>
    {
        public string UserName { get; }

        public string Email { get; }

        public UpdateUserCommand(string username, string email)
        {
            UserName = username;
            Email = email;
        }
    }
}
