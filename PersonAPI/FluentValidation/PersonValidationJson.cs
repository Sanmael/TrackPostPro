using FluentValidation;
using TrackPostPro.Application.CustomMessages;
using TrackPostPro.Application.Requests;
using TrackPostPro.Application.UtilsValidations;

namespace PersonAPI.FluentValidation
{
    public class PersonValidationJson : AbstractValidator<PersonRequest>
    {
        private const int NameMinimumLength = 5;        
        private const int MaximumAge = 120;
        private const int MinimumAge = 16;

        public PersonValidationJson()
        {
            ValidateName();
            ValidateBirthDate();
            ValidatePostalCode();
        }

        private void ValidateName()
        {
            RuleFor(person => person.Name)
                .MinimumLength(NameMinimumLength)
                .WithMessage(string.Format(ErrorMessage.FieldLength, nameof(PersonRequest.Name), NameMinimumLength));
        }

        private void ValidateBirthDate()
        {
            RuleFor(person => person.BirthDate)
                .NotNull()
                .Must(personBirthDate => FieldsValidation.BeAtLeast18YearsOld(personBirthDate, MinimumAge, MaximumAge))
                .WithMessage(string.Format(ErrorMessage.InvalidAgeMessage, MinimumAge, MaximumAge));
        }

        private void ValidatePostalCode()
        {
            RuleFor(person => person.PostalCode).Must((personPostalcode) => FieldsValidation.IsValidCEP(personPostalcode)).WithMessage(ErrorMessage.InvalidPostalCode);
        }
    }
}
