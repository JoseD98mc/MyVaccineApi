using FluentValidation;
using MyVaccine.WebApi.Dtos.Allergy;

namespace MyVaccine.WebApi.Validators
{
    public class AllergyRequestDtoValidator : AbstractValidator<AllergyRequestDto>
    {
        public AllergyRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        }
    }
}