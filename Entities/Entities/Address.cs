using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Entities
{
    public class Address : BaseEntity
    {
        public Guid PersonId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
        public string PublicPlace { get; set; }
        public bool IsPrincipalAddress { get; set; }

        public Address(Guid personId, string city, string state, string postalCode, string neighborhood, string publicPlace, bool isPrincipalAddress)
        {
            Id = Guid.NewGuid();
            PersonId = personId;
            City = city;
            State = state;
            PostalCode = postalCode;
            Neighborhood = neighborhood;
            PublicPlace = publicPlace;
            IsPrincipalAddress = isPrincipalAddress;
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
