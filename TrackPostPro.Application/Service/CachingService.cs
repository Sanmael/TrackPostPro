using Microsoft.Extensions.Caching.Distributed;
using TrackPostPro.Application.Interfaces;

namespace TrackPostPro.Application.Service
{
    public class CachingService : ICachingService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly DistributedCacheEntryOptions _options;

        public CachingService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;

            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };
        }

        public async Task<string> GetAsync(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
            await _distributedCache.SetStringAsync(key, value, _options);
        }
    }
}
