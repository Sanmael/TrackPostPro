namespace TrackPostPro.Application.CustomMessages
{
    public static class ErrorMessage
    {
        public const string Requiredfield = "Campo Obrigadorio";
        public const string FieldLength = "Campo {0} deve conter minimo de {1} caracteres";
        public const string InternalServerErrorMessage = "Ocorreu um erro interno no servidor ao processar a solicitação.";
        public const string InvalidAgeMessage = "Idade minima de {0} e maxima de {1} anos.";
        public const string InvalidPostalCode = "Campo deve conter no mínimo 8 caracteres e ser um CEP válido";
    }
}