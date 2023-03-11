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
            RuleFor(p => p.Estate_Name)
                .NotEmpty().WithMessage("The Title cannot be empty")
                .MaximumLength(150).WithMessage("The Title must be a maximum of 150 characters");
        }

        public void ValidateDescription()
        {
            RuleFor(p => p.Estate_Description)
                .NotEmpty().WithMessage("The Description cannot be empty")
                .MaximumLength(500).WithMessage("The Description must be a maximum of 500 characters");
        }

        public void ValidateCategory()
        {
            RuleFor(p => p.Estate_Type.Type_Name)
                .NotEmpty().WithMessage("The Type cannot be empty")
                .MaximumLength(150).WithMessage("The Type must be a maximum of 150 characters");
        }

        public void ValidateBuildDate()
        {
            RuleFor(p => p.Estate_Year_Built)
                .GreaterThan(1900).WithMessage("The year built cannot be earlier than 1900.")
                .LessThan(DateTime.Now.Year).WithMessage("The build date cannot be in the future.");
        }

        public void ValidatePrice()
        {
            RuleFor(p => p.Listing.Price)
                .GreaterThan(0).WithMessage("The price must be greater than zero");
        }

        public void ValidateFloorSpace()
        {
            RuleFor(p => p.Floor_Space_Square_Meters)
                .GreaterThan(0).WithMessage("The floor space must be greater than zero");
        }
    }
}
