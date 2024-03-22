using FluentValidation;
using RealEstate.Shared.Models.Entities.Estates;

namespace RealEstate.Shared.Core.Validators
{
    public class EstateValidation : AbstractValidator<Estate>
    {
        public void ValidateID()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("The ID must be greater than zero");
        }

        public void ValidateTitle()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The Title cannot be empty")
                .MaximumLength(150).WithMessage("The Title must be a maximum of 150 characters");
        }

        public void ValidateDescription()
        {
            RuleFor(p => p.Summary)
                .NotEmpty().WithMessage("The Description cannot be empty")
                .MaximumLength(500).WithMessage("The Description must be a maximum of 500 characters");
        }

        public void ValidateCategory()
        {
            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("The Type cannot be empty")
                .MaximumLength(150).WithMessage("The Type must be a maximum of 150 characters");
        }
    }
}
