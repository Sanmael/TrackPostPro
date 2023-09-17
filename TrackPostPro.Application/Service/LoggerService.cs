using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using TrackPostPro.Application.Interfaces;

namespace TrackPostPro.Application.Service
{
    public class LoggerService : ILoggerService
    {
        private readonly ILoggerRepository _loggerRepository;

        public LoggerService(ILoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }

        public async Task SaveLog(Exception ex, string message, string serviceName)
        {
            ErrorLog errorLog = new ErrorLog(DateTime.Now, message, ex.ToString(), serviceName);

            await _loggerRepository.SaveLog(errorLog);
        }
    }
}
