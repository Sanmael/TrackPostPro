using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }

        public User(string name, string email, bool isAdmin)
        {
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Name = name;
            Email = email;
            IsAdmin = isAdmin;
        }
    }
}
