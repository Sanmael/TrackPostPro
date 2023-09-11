using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Token
    {
        public Guid Id {  get;  set; }
        public Guid PersonId { get;  set; }                
        public string TextClear { get;  set; }
        public string HashPass { get;  set; }

        public Token NewToken(Guid personId, string textClear, string hashPass)
        {
            Id = Guid.NewGuid();
            PersonId = personId;
            TextClear = textClear;
            HashPass = hashPass;

            return this;
        }
        public void UpdateToken(string textClear, string hashPass)
        {
            TextClear = textClear;
            HashPass = hashPass; 
        }
    }
}
