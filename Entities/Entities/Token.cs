using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Entities
{
    public class Token : BaseEntity
    {
        public Guid PersonId { get; set; }
        public string TextClear { get; set; }
        public string HashPass { get; set; }

        public Token NewToken(Guid personId, string textClear, string hashPass)
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            PersonId = personId;
            TextClear = textClear;
            HashPass = hashPass;

            return this;
        }
        public void UpdateToken(string textClear, string hashPass)
        {
            TextClear = textClear;
            HashPass = hashPass;
            UpdateDate = DateTime.Now;
        }
    }
}
