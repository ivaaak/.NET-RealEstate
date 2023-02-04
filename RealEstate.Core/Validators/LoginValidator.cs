using FluentValidation;
using RealEstate.Models.ViewModels.Login;

namespace RealEstate.Core.Validators
{

    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(a => a.Email)
                .EmailAddress()
                .WithMessage("E-mail isnt valid!");

            RuleFor(a => a.Password)
                .NotEmpty()
                .WithMessage("Password is required.");

            RuleFor(a => a.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Password confirmation is required");

            RuleFor(a => a.ConfirmPassword)
                .Equal(b => b.Password)
                .WithMessage("Passwords dont match.");
        }
    }

}
