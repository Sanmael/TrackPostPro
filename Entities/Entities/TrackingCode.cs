using DomainTrackPostPro.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Entities
{
    public class TrackingCode : BaseEntity
    {        
        public Guid PersonId { get; set; }
        public string Code { get; set; } = "";
        public TrackingCodeStatus Status { get; set; }
        public DateTime NextSearch { get; set; }
        public int NumberOfTries { get; set; }
        public TrackingCode CreateTrackingCode(Guid personId, string code)
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            PersonId = personId;
            Code = code;
            Status = TrackingCodeStatus.Active;
            NextSearch = DateTime.Now;
            NumberOfTries = 0;

            return this;
        }
        public void UpdateTrackingCode(TrackingCodeStatus status, DateTime nextSearch)
        {
            Status = status;
            NextSearch = nextSearch;
            UpdateDate = DateTime.Now;
        }
    }
}
