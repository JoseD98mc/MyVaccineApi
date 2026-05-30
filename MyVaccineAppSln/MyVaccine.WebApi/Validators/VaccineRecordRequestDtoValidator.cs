using FluentValidation;
using MyVaccine.WebApi.Dtos.VaccineRecord;

namespace MyVaccine.WebApi.Validators
{
    public class VaccineRecordRequestDtoValidator : AbstractValidator<VaccineRecordRequestDto>
    {
        public VaccineRecordRequestDtoValidator()
        {
            RuleFor(x => x.VaccineId)
                .NotEmpty().WithMessage("VaccineId is required.");

            RuleFor(x => x.DateAdministered)
                .NotEmpty().WithMessage("DateAdministered is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("DateAdministered cannot be in the future.");

            RuleFor(x => x.AdministeredLocation)
                .MaximumLength(255).WithMessage("AdministeredLocation must not exceed 255 characters.");

            RuleFor(x => x.AdministeredBy)
                .MaximumLength(255).WithMessage("AdministeredBy must not exceed 255 characters.");
        }
    }
}
