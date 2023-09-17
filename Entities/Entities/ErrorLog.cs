using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Entities
{
    public class ErrorLog
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

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
