namespace TrackPostPro.Application.CustomMessages
{
    public static class ErrorMessage
    {
        public const string Requiredfield = "Campo Obrigadorio";
        public const string NameLenght = "Campo Nome deve conter minimo de 6 caracteres";
        public const string InternalServerErrorMessage = "Ocorreu um erro interno no servidor ao processar a solicitação.";
        public const string InvalidAgeMessage = "A idade do usuário deve estar entre {0} e {1} anos.";
    }
}
