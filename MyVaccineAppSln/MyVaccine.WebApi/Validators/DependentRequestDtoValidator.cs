using FluentValidation;
using MyVaccine.WebApi.Dtos.Dependent;

namespace MyVaccine.WebApi.Validators
{
    public class DependentRequestDtoValidator : AbstractValidator<DependentRequestDto>
    {
        public DependentRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name must not exceed 255 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("DateOfBirth is required.")
                .LessThan(DateTime.UtcNow).WithMessage("DateOfBirth must be in the past.");
        }
    }
}
