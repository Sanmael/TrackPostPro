namespace TrackPostPro.Application.Requests
{
    public class PersonRequest
    {
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string PostalCode { get; set; } = string.Empty;
    }
}
