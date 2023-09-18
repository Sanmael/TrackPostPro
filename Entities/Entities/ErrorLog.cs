using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Entities
{
    public class ErrorLog
    {
        public Guid Id { get; private set; }
        public string ServiceName { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string Message { get; private set; }
        public string StackTrace { get; private set; }
        public ErrorLog(DateTime timestamp, string message, string stackTrace, string serviceName)
        {
            Id = Guid.NewGuid();
            Timestamp = timestamp;
            Message = message;
            StackTrace = stackTrace;
            ServiceName = serviceName;
        }
    }
}
