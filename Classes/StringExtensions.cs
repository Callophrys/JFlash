namespace JFlash.Classes;

public static class StringExtensions
{
    // TODO use a reg ex at some point...maybe
    public static string Scrub(this string item) => item?
        .Replace(",,", ",")
        .Replace(", ,", ", ")
        .Trim([',', ' '])
        .Replace(",", ", ")
        .Replace("  ", " ")
        .Replace("  ", " ") ?? string.Empty;
}
