using System.Text.RegularExpressions;

namespace LoginWithOTP.Utilities
{
    public static class EmailValidator
    {
        public static bool IsValid(string Email)
        {
            const string pattern = @"/[a-zA-Z0-9.-]+@[a-z-]+\.[a-z]{2,3}/";
            return Regex.IsMatch(Email, pattern);
        }

        public static bool IsItEmail(string Email)
        {
            return Email.Contains("@");
        }
    }
}
