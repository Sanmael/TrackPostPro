namespace TrackPostPro.Application.Interfaces
{
    public interface ILoggerService
    {
        public Task SaveLog(Exception ex, string message, string? serviceName);
    }
}
