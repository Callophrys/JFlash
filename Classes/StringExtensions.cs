namespace JFlash.Classes;

public static class StringExtensions
{
    // TODO use a reg ex at some point...maybe

    /// <summary>
    /// Remove extraneous comma and space characters from a string.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Updated <see cref="string"/>.</returns>
    public static string Scrub(this string item) => item?
        .Replace(",,", ",")
        .Replace(", ,", ", ")
        .Trim([',', ' '])
        .Replace(",", ", ")
        .Replace("  ", " ")
        .Replace("  ", " ") ?? string.Empty;

    /// <summary>
    /// Takes out all the #-escaped elements from a comma-separated string.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="delimiter"></param>
    /// <param name="escape"></param>
    /// <returns>Updated <see cref="string"/>.</returns>
    public static string ExcludeEscapedSubElements(this string item, string delimiter = ",", char escape = '#')
    {
        if (string.IsNullOrWhiteSpace(item)) return string.Empty;
        if (!item.Contains(escape)) return item;

        List<string> answers = item.Split(
            delimiter,
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
        ).ToList();
        if (answers.Count < 1) return string.Empty;
        if (answers.Count == 1) return item;

        List<string> answersToShow = [];
        foreach (string answer in answers)
        {
            if (answer[0] != escape) answersToShow.Add(answer);
        }

        return string.Join(", ", answersToShow);
    }

    /// <summary>
    /// Removes the #-escape character from the elements of a string while
    /// retaining all of the elements.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="delimiter"></param>
    /// <param name="escape"></param>
    /// <returns>Updated <see cref="string"/>.</returns>
    public static string RemoveSubElementEscapes(this string item, string delimiter = ",", char escape = '#')
    {
        if (string.IsNullOrWhiteSpace(item)) return string.Empty;
        if (!item.Contains(escape)) return item;

        List<string> answers = item.Split(
            delimiter,
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
        ).ToList();
        if (answers.Count < 1) return string.Empty;
        if (answers.Count == 1) return item;

        List<string> answersToShow = [];
        foreach (string answer in answers)
        {
            answersToShow.Add(answer[0] == escape ? answer[1..] : answer);
        }

        return string.Join(", ", answersToShow);
    }

    /// <summary>
    /// Checks each element of an answer string for hyphens. If there is a
    /// hyphen, for each of these, <br/> it will add an answer element where
    /// the hyphens are replaced with nothing, and will also add a <br/>second
    /// answer with the hyphens replaced with space characters.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="delimiter"></param>
    /// <returns>Updated <see cref="string"/>.</returns>
    /// <remarks>
    /// Both of the new elements for each element identified will have an
    /// "#" escape character prepended.
    /// </remarks>
    public static string ResolveHyphens(this string item, string delimiter = ",", char escapeCharacter = '#')
    {
        if (string.IsNullOrWhiteSpace(item)) return string.Empty;
        if (!item.Contains('-')) return item;

        List<string> elements = [];
        foreach (string rawElement in item.Split(delimiter, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            string element = rawElement.Trim();
            elements.Add(element);  

            if (element.Contains("-"))
            {
                if (element.StartsWith(escapeCharacter))
                {
                    // The main element is already escaped and thus the new
                    // elements are already escaped.
                    elements.Add(element.Replace("-", " "));  
                    elements.Add(element.Replace("-", string.Empty));  
                }
                else
                {
                    // Escape just the new elements.
                    elements.Add(escapeCharacter + element.Replace("-", " "));  
                    elements.Add(escapeCharacter + element.Replace("-", string.Empty));  
                }
            }
        }

        return string.Join(", ", elements.Distinct());
    }
}
