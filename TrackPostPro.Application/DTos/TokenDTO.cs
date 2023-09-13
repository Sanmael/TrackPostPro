namespace TrackPostPro.Application.DTos
{
    public class TokenDTO
    {
        public Guid PersonId { get; set; }
        public string HashPass { get; set; }
        public string TextClear { get; set; }
        public TokenDTO(Guid personId, string hashPass, string textClear)
        {
            PersonId = personId;
            HashPass = hashPass;
            TextClear = textClear;
        }
        public TokenDTO(Guid personId, string hashPass)
        {
            PersonId = personId;
            HashPass = hashPass;
        }
    }
}
