using FluentValidation;
using MyVaccine.WebApi.Dtos.FamilyGroup;

namespace MyVaccine.WebApi.Validators
{
    public class FamilyGroupRequestDtoValidator : AbstractValidator<FamilyGroupRequestDto>
    {
        public FamilyGroupRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name must not exceed 255 characters.");
        }
    }
}
