using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Entities
{
    public class Token : BaseEntity
    {
        public Guid UserId { get; private set; }
        public string TextClear { get; private set; } 
        public string HashPass { get; private set; } 
        public Token(Guid personId, string textClear, string hashPass)
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            UserId = personId;
            TextClear = textClear;
            HashPass = hashPass;            
        }
        public void UpdateToken(string textClear, string hashPass)
        {
            TextClear = textClear;
            HashPass = hashPass;
            UpdateDate = DateTime.Now;
        }
    }
}
