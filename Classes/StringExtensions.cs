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

    public static string ExcludeEscapedSubElements(this string item, string delimiter = ",", char escape = '#')
    {
        if (!item.Contains(escape)) return item;

        List<string> elements = [];
        foreach (string element in item.Split(delimiter, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            if (element[0] != escape) elements.Add(element);
        }

        return string.Join(", ", elements);
    }

    public static string RemoveSubElementEscapes(this string item, string delimiter = ",", char escape = '#')
    {
        if (!item.Contains(escape)) return item;

        List<string> elements = [];
        foreach (string element in item.Split(delimiter, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            elements.Add(element[0] == escape ? element[1..] : element);
        }

        return string.Join(", ", elements);
    }
}
