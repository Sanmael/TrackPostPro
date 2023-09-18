using Aplication.Commands.PersonCommands.CreatePerson;
using FluentValidation;
using System.Data;
using TrackPostPro.Application.CustomMessages;

namespace PersonAPI.FluentValidation
{
    public class PersonValidationJson : AbstractValidator<CreatePersonCommand>
    {
        private const int MinimumLength = 5;
        private const int MaximumAge = 120;
        private const int MinimumAge = 16;
        public PersonValidationJson()
        {
            RuleFor(person => person.Name).MinimumLength(MinimumLength).WithMessage(ErrorMessage.NameLenght);
            RuleFor(person => person.Age).NotEmpty().WithMessage(ErrorMessage.Requiredfield);
            RuleFor(person => person.Password).NotEmpty().WithMessage(ErrorMessage.Requiredfield);
            RuleFor(person => person.Age).Must(age => age > MinimumAge && age < MaximumAge).WithMessage(string.Format(ErrorMessage.InvalidAgeMessage, MinimumAge, MaximumAge));
        }
    }
}
