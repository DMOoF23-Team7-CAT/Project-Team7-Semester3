using FluentValidation;
using Rally.Core.Entities;

namespace Rally.Application.Validators
{
    public class EquipmentBaseValidator : AbstractValidator<EquipmentBase>
    {
        public EquipmentBaseValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(e => e.Image)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}
