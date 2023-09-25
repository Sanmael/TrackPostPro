using System.Text.RegularExpressions;

namespace TrackPostPro.Application.UtilsValidations
{
    public static class FieldsValidation
    {
        public static bool BeAtLeast18YearsOld(DateTime dateOfBirth, int minimumAge, int maximumAge)
        {
            DateTime today = DateTime.Today;

            int age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }
            return age >= minimumAge && age <= maximumAge;
        }
        public static bool IsValidCEP(string cep)
        {
            string cepPattern = @"^\d{5}-?\d{3}$";

            if (string.IsNullOrWhiteSpace(cep))
            {
                return false;
            }
            if (Regex.IsMatch(cep, cepPattern))
            {
                string numericDigits = new string(cep.Where(char.IsDigit).ToArray());

                if (numericDigits.Length == 8)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
