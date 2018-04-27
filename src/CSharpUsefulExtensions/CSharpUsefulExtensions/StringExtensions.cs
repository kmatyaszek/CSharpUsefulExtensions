using System;

namespace CSharpUsefulExtensions
{
    public static class StringExtensions
    {
        public static string Left(this string value, int length)
        {
            if (string.IsNullOrEmpty(value)) return value;

            return value.Length <= length ? value : value.Substring(0, length);
        }

        public static string Right(this string value, int length)
        {
            if (string.IsNullOrEmpty(value)) return value;

            return length >= value.Length ? value : value.Substring(value.Length - length);
        }

        public static string AppendIfMissing(this string value, string suffix, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(suffix)) return value;

            if (value.EndsWith(suffix, stringComparison)) return value;

            return value + suffix;
        }

        public static string PrependIfMissing(this string value, string prefix, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix)) return value;

            if (value.StartsWith(prefix, stringComparison)) return value;

            return prefix + value;
        }
    }
}
