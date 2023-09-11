using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface ITokenRepository 
    {
        public Task CreateToken(Guid personId, string pass);
        public string CreateHash(string pass, string textRandom);
        public Task<Token> GetToken(Guid personId);
        public Task ResetCredential(Guid personId, string pass);
    }
}