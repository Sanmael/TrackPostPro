using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using Serilog;

namespace Context.Repositories
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly Serilog.ILogger _logger;
        private readonly IGenericRepository _genericRepository;

        public LoggerRepository(IGenericRepository genericRepository)
        {
                _logger = new LoggerConfiguration()
               .MinimumLevel.Error()
               .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();

            _genericRepository = genericRepository;
        }

        public async Task SaveLog(ErrorLog errorLog)
        {
            await _genericRepository.Insert(errorLog);
        }
    }
}
