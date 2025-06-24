namespace JFlash.Classes;

readonly record struct QuestionEntry(string[] Parts)
{
    public string Lesson => Parts.Length > QuestionFields.Lesson ? Parts[QuestionFields.Lesson] : string.Empty;
    public string Structure => Parts.Length > QuestionFields.Structure ? Parts[QuestionFields.Structure] : string.Empty;
    public string Kanji => Parts.Length > QuestionFields.Kanji ? Parts[QuestionFields.Kanji] : string.Empty;
    public string Hirigana => Parts.Length > QuestionFields.Hirigana ? Parts[QuestionFields.Hirigana] : string.Empty;
    public string Katakana => Parts.Length > QuestionFields.Katakana ? Parts[QuestionFields.Katakana] : string.Empty;
    public string Romaji => Parts.Length > QuestionFields.Romaji ? Parts[QuestionFields.Romaji] : string.Empty;
    public string English => Parts.Length > QuestionFields.English ? Parts[QuestionFields.English] : string.Empty;
    public string BriefHint => Parts.Length > QuestionFields.BriefHint ? Parts[QuestionFields.BriefHint] : string.Empty;
    public string DetailedHint => Parts.Length > QuestionFields.DetailedHint ? Parts[QuestionFields.DetailedHint] : string.Empty;

    public string this[int index] => index < Parts.Length ? Parts[index] : string.Empty;

    public static bool TryParse(string[] parts, ref QuestionEntry questionEntry)
    {
        parts[QuestionFields.Romaji] = parts[QuestionFields.Romaji].ResolveHyphens();
        questionEntry = new QuestionEntry(parts);
        return true;
    }
}
