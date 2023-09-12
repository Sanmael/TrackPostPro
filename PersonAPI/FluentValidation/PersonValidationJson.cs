using Aplication.Commands.PersonCommands.CreatePerson;
using FluentValidation;
using TrackPostPro.Application.CustomErrorMessages;

namespace PersonAPI.FluentValidation
{
    public class PersonValidationJson : AbstractValidator<CreatePersonCommand>
    {
        private int MinimumLength = 5;
        public PersonValidationJson()
        {
                RuleFor(person => person.Name).NotEmpty().MinimumLength(MinimumLength).WithMessage(ErrorMessage.NameLenght);
                RuleFor(person => person.Age).NotEmpty().WithMessage(ErrorMessage.Requiredfield);
                RuleFor(person => person.Password).NotEmpty().WithMessage(ErrorMessage.Requiredfield);
        }
    }
}
