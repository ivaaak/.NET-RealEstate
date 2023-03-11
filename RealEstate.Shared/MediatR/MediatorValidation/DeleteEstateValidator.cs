using FluentValidation;
using RealEstate.Shared.MediatR.Commands;

namespace RealEstate.Shared.MediatR.MediatorValidation
{
    public class DeleteEstateValidator : AbstractValidator<EstateCommand>
    {
        public DeleteEstateValidator()
        {
            RuleFor(x => x.ID)
                .NotNull()
                    .WithErrorCode("missing_field_value")
                    .WithMessage("The {ID} does not contain value")
                .GreaterThanOrEqualTo(1)
                    .WithErrorCode("bad_format")
                    .WithMessage("{ID} should have a value greatet than zero (0)");
        }
    }
}
