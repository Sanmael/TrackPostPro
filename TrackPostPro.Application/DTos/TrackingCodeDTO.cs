using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Enums;

namespace TrackPostPro.Application.DTos
{
    public class TrackingCodeDTO
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public TrackingCodeDTO(TrackingCode trackingCode)
        {
            Id = trackingCode.Id;
            PersonId = trackingCode.PersonId;
            Code = trackingCode.Code;
            Status = trackingCode.Status.ToString();            
        }
    }
}
