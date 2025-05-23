namespace JFlash
{
    public static class StringExtensions
    {
        public static string Scrub(this string item) => item.Replace(",,", ",").Trim([',', ' ']).Replace(",", ", ");
    }
}
