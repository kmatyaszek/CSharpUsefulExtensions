using System.Text;

namespace CSharpUsefulExtensions
{
    public static class StringBuilderExtensions
    {
        public static bool IsEmpty(this StringBuilder stringBuilder)
        {
            return stringBuilder.Length == 0;
        }

        public static bool IsNullOrEmpty(this StringBuilder stringBuilder)
        {
            return stringBuilder == null || stringBuilder.IsEmpty();
        }

        public static bool IsNullOrWhiteSpace(this StringBuilder stringBuilder)
        {
            return stringBuilder.IsNullOrEmpty() || stringBuilder.ToString().Trim().Length == 0;
        }
    }
}