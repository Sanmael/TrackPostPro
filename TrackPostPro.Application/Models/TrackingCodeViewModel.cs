using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Enums;

namespace TrackPostPro.Application.Models
{
    public class TrackingCodeViewModel
    {
        public Guid Id { get; set; }                
        public Guid PersonId { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }        
        public TrackingCodeViewModel EntityToDto(TrackingCode trackingCode)
        {
            Id = trackingCode.Id;
            PersonId = trackingCode.PersonId;
            Code = trackingCode.Code;
            Status = trackingCode.Status.ToString();            
            return this;
        }
    }
}
