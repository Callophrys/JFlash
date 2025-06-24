namespace JFlash.Classes;

public class QuestionEntries
{
    public string Lesson { get; } = string.Empty;
    public string Structure { get; } = string.Empty;
    public string Kanji { get; } = string.Empty;
    public string Hirigana { get; } = string.Empty;
    public string Katakana { get; } = string.Empty;
    public string Romaji { get; } = string.Empty;
    public string English { get; } = string.Empty;
    public string BriefHint { get; } = string.Empty;
    public string DetailedHint { get; } = string.Empty;

    /// <summary>
    /// User answer. This is the value entered by the user.
    /// </summary>
    public string Answer => sourceEntry[indexTo];

    /// <summary>
    /// Source question. This is read by the user and requires a response.
    /// </summary>
    public string Prompt => sourceEntry[indexFrom].ExcludeEscapedSubElements();

    /// <summary>
    /// Post prompt is what is shown after the question has been assessed.
    /// </summary>
    public string PostPrompt => sourceEntry[indexFrom].RemoveSubElementEscapes();

    protected int indexFrom;
    protected int indexTo;

    public readonly string[] sourceEntry = [];

    public QuestionEntries(string line, int indexFrom, int indexTo)
    {
        this.indexFrom = indexFrom;
        this.indexTo = indexTo;

        sourceEntry = line.Split([';', '；'], StringSplitOptions.None);
        if (sourceEntry.Length <= QuestionFields.MaxQuesInx)
        {
            Array.Resize(ref sourceEntry, QuestionFields.MaxQuesInx + 1);
        }

        if (sourceEntry.Length < QuestionFields.MinQuesIdx) return;
        if (indexFrom < QuestionFields.MinQuesIdx || indexFrom > QuestionFields.MaxQuesInx) return;
        if (indexTo < QuestionFields.MinQuesIdx || indexTo > QuestionFields.MaxQuesInx) return;

        QuestionEntry questionEntry = new();
        if (!QuestionEntry.TryParse(sourceEntry, ref questionEntry)) return;

        Lesson = questionEntry.Lesson;
        Structure = questionEntry.Structure;
        Kanji = questionEntry.Kanji;
        Hirigana = questionEntry.Hirigana;
        Katakana = questionEntry.Katakana;
        Romaji = questionEntry.Romaji;
        English = questionEntry.English;
        BriefHint = questionEntry.BriefHint;
        DetailedHint = questionEntry.DetailedHint;
    }
}
