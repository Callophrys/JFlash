using System.Web;

namespace JFlash.Classes;

public static class QuestionFields
{
    public const int FieldCount   = 9;
    public const int MinQuestion = 2;
    public const int MaxQuestion = 6;

    public const int Lesson       = 0;
    public const int Structure    = 1;
    public const int Kanji        = 2;
    public const int Hirigana     = 3;
    public const int Katakana     = 4;
    public const int Romaji       = 5;
    public const int English      = 6;
    public const int BriefHint    = 7;
    public const int DetailedHint = 8;
}

readonly record struct QuestionEntry(string[] Parts)
{
    public string Lesson       => Parts.Length > QuestionFields.Lesson ? Parts[QuestionFields.Lesson] : string.Empty;
    public string Structure    => Parts.Length > QuestionFields.Structure ? Parts[QuestionFields.Structure] : string.Empty;
    public string Kanji        => Parts.Length > QuestionFields.Kanji ? Parts[QuestionFields.Kanji] : string.Empty;
    public string Hirigana     => Parts.Length > QuestionFields.Hirigana ? Parts[QuestionFields.Hirigana] : string.Empty;
    public string Katakana     => Parts.Length > QuestionFields.Katakana ? Parts[QuestionFields.Katakana] : string.Empty;
    public string Romaji       => Parts.Length > QuestionFields.Romaji ? Parts[QuestionFields.Romaji] : string.Empty;
    public string English      => Parts.Length > QuestionFields.English ? Parts[QuestionFields.English] : string.Empty;
    public string BriefHint    => Parts.Length > QuestionFields.BriefHint ? Parts[QuestionFields.BriefHint] : string.Empty;
    public string DetailedHint => Parts.Length > QuestionFields.DetailedHint ? Parts[QuestionFields.DetailedHint] : string.Empty;

    public string this[int index] => index < Parts.Length ? Parts[index] : string.Empty;

    public static bool TryParse(string[] parts, ref QuestionEntry questionEntry)
    {
        questionEntry = new QuestionEntry(parts);
        return true;
    }
}

public class QuestionEntries
{
    public string Lesson { get; set; } = string.Empty;
    public string Structure { get; set; } = string.Empty;
    public string Kanji { get; set; } = string.Empty;
    public string Hirigana { get; set; } = string.Empty;
    public string Katakana { get; set; } = string.Empty;
    public string Romaji { get; set; } = string.Empty;
    public string English { get; set; } = string.Empty;
    public string BriefHint { get; set; } = string.Empty;
    public string DetailedHint { get; set; } = string.Empty;

    /// <summary>
    /// Correct answer. This is the value to be entered by the user.
    /// </summary>
    public string Answer => indexTo <= QuestionFields.MaxQuestion ? sourceEntry[indexTo] : string.Empty;

    /// <summary>
    /// Source question. This is read by the user and requires a response.
    /// </summary>
    public string Prompt => indexFrom <= QuestionFields.MaxQuestion ? sourceEntry[indexFrom] : string.Empty;

    protected readonly int indexFrom;
    protected readonly int indexTo;

    public readonly string[] sourceEntry = [];

    public QuestionEntries(string line, int indexFrom, int indexTo)
    {
        this.indexFrom = indexFrom;
        this.indexTo = indexTo;

        sourceEntry = line.Split([';', '；'], StringSplitOptions.None);
        if (sourceEntry.Length <= QuestionFields.MaxQuestion)
        {
            Array.Resize(ref sourceEntry, QuestionFields.MaxQuestion);
        }

        if (sourceEntry.Length < QuestionFields.MinQuestion) return;
        if (indexFrom < QuestionFields.MinQuestion || indexFrom > QuestionFields.MaxQuestion) return;
        if (indexTo < QuestionFields.MinQuestion || indexTo > QuestionFields.MaxQuestion) return;

        QuestionEntry questionEntry = new();
        if (!QuestionEntry.TryParse(sourceEntry, ref questionEntry)) return;

        this.Lesson = questionEntry.Lesson;
        this.Structure = questionEntry.Structure;
        this.Kanji = questionEntry.Kanji;
        this.Hirigana = questionEntry.Hirigana;
        this.Katakana = questionEntry.Katakana;
        this.Romaji = questionEntry.Romaji;
        this.English = questionEntry.English;
        this.BriefHint = questionEntry.BriefHint;
        this.DetailedHint = questionEntry.DetailedHint;
    }
} 
