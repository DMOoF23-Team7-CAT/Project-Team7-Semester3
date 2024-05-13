using FluentValidation;
using Rally.Core.Entities;

namespace Rally.Application.Validators
{
    public class SignBaseValidator : AbstractValidator<SignBase>
    {
        public SignBaseValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(s => s.Description)                
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed {MaxLength} characters");
            
            RuleFor(s => s.Image)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(s => s.CategoryId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(s => s.EquipmentBaseId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}
