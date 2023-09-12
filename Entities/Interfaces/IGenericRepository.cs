using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Interfaces
{
    public interface IGenericRepository
    {
        public Task Insert<T>(string query, T param);
        public Task Update<T>(string query, T param);
        public Task Delete<T>(string query, T param);
    }
}
