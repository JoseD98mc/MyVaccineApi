using FluentValidation;
using MyVaccine.WebApi.Dtos.UsersAllergy;

namespace MyVaccine.WebApi.Validators
{
    public class UsersAllergyRequestDtoValidator : AbstractValidator<UsersAllergyRequestDto>
    {
        public UsersAllergyRequestDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");

            RuleFor(x => x.AllergyId)
                .NotEmpty().WithMessage("AllergyId is required.");
        }
    }
}
