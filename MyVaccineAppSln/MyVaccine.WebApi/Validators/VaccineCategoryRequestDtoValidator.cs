using FluentValidation;
using MyVaccine.WebApi.Dtos.VaccineCategory;

namespace MyVaccine.WebApi.Validators
{
    public class VaccineCategoryRequestDtoValidator : AbstractValidator<VaccineCategoryRequestDto>
    {
        public VaccineCategoryRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        }
    }
}
