using FluentValidation;
using Rally.Core.Entities;

namespace Rally.Application.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

            RuleFor(c => c.Rules)
                .MaximumLength(1000)
                .WithMessage("{PropertyName} must not exceed {MaxLength} characters");
        }
    }
}

