namespace TrackPostPro.Application.DTos
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public TokenDTO Token { get; set; }

        public UserDTO(string userName, string password, string email)
        {
            UserName = userName;
            Email = email;
            Token = new TokenDTO(Id, password);
        }
    }
}