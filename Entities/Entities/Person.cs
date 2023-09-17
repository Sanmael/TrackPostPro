using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public Person CreateNewPerson(Guid id ,string name, int age)
        {
            Id = id;
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Name = name;
            Age = age;

            return this;
        }
    }
}
