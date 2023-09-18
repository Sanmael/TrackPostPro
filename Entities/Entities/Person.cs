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
        public int Age { get; private set; }
        public Person()
        {
                
        }
        public Person(Guid id ,string name, int age)
        {
            Id = id;
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Name = name;
            Age = age;
        }
    }
}
