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
    }
}
