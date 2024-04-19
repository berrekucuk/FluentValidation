using _02.FluentValidation.Models.DTO;
using FluentValidation;

namespace _02.FluentValidation.Models.Validations
{
    public class CreateUniversityRequestDtoValidator : AbstractValidator<CreateUniversityRequestDto>
    {
        public CreateUniversityRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
        }
    }
}
