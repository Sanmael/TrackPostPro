using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainTrackPostPro.Entities;

namespace DomainTrackPostPro.Interfaces
{
    public interface ITokenRepository 
    {
        public Task CreateToken(Token token);
        public Task<Token> GetToken(Guid personId);
        public Task ResetCredential(Token token);
        public Task DeleteToken(Token token);
    }
}