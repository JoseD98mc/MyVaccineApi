using FluentValidation;
using MyVaccine.WebApi.Dtos.Vaccine;

namespace MyVaccine.WebApi.Validators
{
    public class VaccineRequestDtoValidator : AbstractValidator<VaccineRequestDto>
    {
        public VaccineRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name must not exceed 255 characters.");
        }
    }
}
