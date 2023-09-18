namespace TrackPostPro.Application.Interfaces
{
    public interface ICachingService
    {
        public Task SetAsync(string key, string value);
        public Task<string> GetAsync(string key);
    }
}
