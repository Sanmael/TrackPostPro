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
        public Guid PersonId { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Neighborhood { get; private set; }
        public string PublicPlace { get; private set; }
        public bool IsPrincipalAddress { get; private set; }
        public Address()
        {
            
        }
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
        public void UpdateNewPrincipalAddress()
        {
            IsPrincipalAddress = true;
            UpdateDate = DateTime.Now;
        }
    }
}
