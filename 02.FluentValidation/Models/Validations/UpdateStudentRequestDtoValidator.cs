using _02.FluentValidation.Models.DTO;
using FluentValidation;

namespace _02.FluentValidation.Models.Validations
{
    public class UpdateStudentRequestDtoValidator : AbstractValidator<UpdateStudentRequestDto>
    {
        public UpdateStudentRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is not valid");            
        }
    }
}
