using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Interfaces
{
    public interface IContext
    {
        public IDbConnection DbConnection { get; }
        public IDbTransaction Transaction { get; set; }
        public void Dispose();
    }
}
