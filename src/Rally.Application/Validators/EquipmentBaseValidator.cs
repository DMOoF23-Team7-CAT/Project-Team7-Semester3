
using FluentValidation;
using Rally.Core.Entities;

namespace Rally.Application.Validators
{
    public class EquipmentBaseValidator : AbstractValidator<EquipmentBase>
    {
        public EquipmentBaseValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than {ComparisonValue}");
                
            RuleFor(s => s.Image)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}

