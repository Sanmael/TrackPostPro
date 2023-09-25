namespace TrackPostPro.Application.DTos
{
    public class TokenDTO
    {
        public Guid UserId { get; set; }
        public string HashPass { get; set; }
        public string TextClear { get; set; }
        public TokenDTO(Guid userId, string pass, string textClear)
        {
            UserId = userId;
            HashPass = pass;
            TextClear = textClear;
        }
        public TokenDTO(Guid userId, string pass)
        {
            UserId = userId;
            HashPass = pass;
        }
    }
}