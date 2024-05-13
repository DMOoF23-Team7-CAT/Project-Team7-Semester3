using FluentValidation;
using Rally.Core.Entities;

namespace Rally.Application.Validators
{
    public class SignValidator : AbstractValidator<Sign>
    {
        public SignValidator()
        {            
            RuleFor(s => s.TrackId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(s => s.SignNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than {ComparisonValue}");

        }
    }
}
