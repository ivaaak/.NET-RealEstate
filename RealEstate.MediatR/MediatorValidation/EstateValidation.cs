using FluentValidation;
using RealEstate.MediatR.Commands;

namespace RealEstate.MediatR.MediatorValidation
{
    public class EstateValidation : AbstractValidator<EstateCommand>
    {
        public void ValidateID()
        {
            RuleFor(p => p.ID)
                .GreaterThan(0).WithMessage("The ID must be greater than zero");
        }

        public void ValidateTitle()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("The Title cannot be empty")
                .MaximumLength(150).WithMessage("The Title must be a maximum of 150 characters");
        }
    }
}
