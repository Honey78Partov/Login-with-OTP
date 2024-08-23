namespace LoginWithOTP.Infrastructure.CacheManager
{
    public interface IOtpCacheManager
    {
        void AddOtp(string key, string code);
    }
}
