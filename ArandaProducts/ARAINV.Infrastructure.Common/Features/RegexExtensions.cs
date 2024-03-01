using System.Text.RegularExpressions;

namespace ARAINV.Infrastructure.Common.Features
{
    public static class RegexExtensions
    {
        public static bool VerifyValue(object value, string pattern)
        {
            return Regex.IsMatch(value == null ? "" : value.ToString(), pattern);
        }

        public static bool VerifyStringIsNullOrEmpty(string value)
        {
            return Regex.IsMatch(value, @"^\s*$") | string.IsNullOrEmpty(value) | value.Length == 0 | value == "null" | value == "NULL";
        }
    }
}
