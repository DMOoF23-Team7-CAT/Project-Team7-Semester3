using FluentValidation;
using Rally.Core.Entities;

namespace Rally.Application.Validators
{
    public class TrackValidator : AbstractValidator<Track>
    {
        public TrackValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

            RuleFor(t => t.Comment)
                .MaximumLength(500)
                .WithMessage("{PropertyName} must not exceed {MaxLength} characters");
            
            RuleFor(t => t.Location)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

            RuleFor(t => t.CategoryId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than {ComparisonValue}");
        }
    }
}

