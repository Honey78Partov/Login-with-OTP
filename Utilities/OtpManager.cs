using System.Security.Cryptography;

namespace LoginWithOTP.Utilities
{
    public static class OtpManager
    {
        public static int GenerateNewCode()
        {
            return RandomNumberGenerator.GetInt32(12345, 99999);
        }
    }
}
