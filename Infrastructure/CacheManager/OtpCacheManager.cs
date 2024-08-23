using Microsoft.Extensions.Caching.Memory;

namespace LoginWithOTP.Infrastructure.CacheManager
{
    public class OtpCacheManager(IMemoryCache memoryCache) : IOtpCacheManager
    {
        public void AddOtp(string key, string code)
        {
            throw new NotImplementedException();
        }
    }
}
