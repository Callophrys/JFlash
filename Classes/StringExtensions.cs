namespace JFlash
{
    public static class StringExtensions
    {
        public static string Scrub(this string item) => item
            .Replace(",,", ",")
            .Replace(", ,", ", ")
            .Trim([',', ' '])
            .Replace(",", ", ")
            .Replace("  ", " ")
            .Replace("  ", " ");
    }
}
