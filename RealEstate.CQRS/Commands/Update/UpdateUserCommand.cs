using MediatR;
using RealEstate.CQRS.Pipeline;

namespace RealEstate.CQRS.Commands
{
    public class UpdateUserCommand : IRequest<Response>
    {
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string ConfirmPassword { get; }

        public UpdateUserCommand(string name, string email, string password, string confirmPassword)
        {
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
