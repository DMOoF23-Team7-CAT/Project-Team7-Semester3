
using FluentValidation;
using Rally.Core.Entities;

namespace Rally.Application.Validators
{
    public class EquipmentValidator : AbstractValidator<Equipment>
    {
        public EquipmentValidator()
        {
            RuleFor(x => x.EquipmentBaseId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(x => x.SignId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}

