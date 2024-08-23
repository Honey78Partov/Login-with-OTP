using System.Text.RegularExpressions;

namespace LoginWithOTP.Utilities
{
    public static class PhoneNumberValidator
    {
        public static bool IsValid(string PhoneNumber)
        {

            const string pattern = @"/((0?9)|(\\+?989))\\d{2}\\W?\\d{3}\\W?\\d{4}/g";
            return Regex.IsMatch(PhoneNumber, pattern);
        }   
    }
}
