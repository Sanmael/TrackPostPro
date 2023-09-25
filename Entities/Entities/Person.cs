using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; private set; } 
        public DateTime BirthDate { get; private set; }
        public string PhoneNumber { get; private set; } = string.Empty;
        public string? NickName { get; private set; }
        public string? ProfilePicture { get; private set; }
        public Person()
        {
                
        }
        public Person(string name, DateTime birthDate)
        {            
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Name = name;
            BirthDate = birthDate;
        }
    }
}
