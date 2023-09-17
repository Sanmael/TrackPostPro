using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Interfaces
{
    public interface IUnitOfWork
    {
        public void BeginTransaction();
        public void Commit();
        public void Rollback();        
    }
}
