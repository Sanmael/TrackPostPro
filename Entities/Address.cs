using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Address
    {
        public Guid Id { get; private set; }
        public Guid PersonId { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Neighborhood { get; private set; }
        public string PublicPlace { get; private set; }
        public bool IsPrincipalAddress { get; private set; }

        public Address(Guid personId, string city, string state, string postalCode, string neighborhood, string publicPlace, bool isPrincipalAddress)
        {
            PersonId = personId;
            City = city;
            State = state;
            PostalCode = postalCode;
            Neighborhood = neighborhood;
            PublicPlace = publicPlace;
            IsPrincipalAddress = isPrincipalAddress;
        }
    }
}
