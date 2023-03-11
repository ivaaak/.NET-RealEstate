using FluentValidation;
using RealEstate.Shared.MediatR.Commands;

namespace RealEstate.Shared.MediatR.MediatorValidation
{
    public class CreateEstateValidator : AbstractValidator<EstateCommand>
    {
        public CreateEstateValidator()
        {
            RuleFor(x => x.ID)
                .NotNull()
                    .WithErrorCode("missing_field_value")
                    .WithMessage("The {ID} does not contain value")
                .GreaterThanOrEqualTo(1)
                    .WithErrorCode("bad_format")
                    .WithMessage("{ID} should have a value greatet than zero (0)");

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithErrorCode("bad_format")
                .WithMessage("The {Title} should have a value with maximum length of 100");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500)
                .WithErrorCode("bad_format")
                .WithMessage("The {Description} should have a value with maximum length of 100");
        }
    }
}
