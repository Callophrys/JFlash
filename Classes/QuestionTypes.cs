namespace JFlash.Classes;

public static class QuestionTypes
{
    public enum JPCHOICES
    {
        Kanji = QuestionFields.Kanji,
        Hirigana = QuestionFields.Hirigana,
        Katakana = QuestionFields.Katakana,
        Romaji = QuestionFields.Romaji,
        English = QuestionFields.English,
    }

    public static readonly string[] choices =
    [
        "Kanji",
        "Hirigana",
        "Katakana",
        "Romaji",
        "English",
    ];

    public static string JpIntToChoiceString(int choice) => choice switch
    {
        QuestionFields.Hirigana => "Hirigana",
        QuestionFields.Katakana => "Katakana",
        QuestionFields.Romaji => "Romaji",
        QuestionFields.English => "English",
        _ => "Kanji",
    };

    public static int JpStringToChoiceIndex(string choice) => (int)(choice switch
    {
        "Hirigana" => JPCHOICES.Hirigana,
        "Katakana" => JPCHOICES.Katakana,
        "Romaji" => JPCHOICES.Romaji,
        "English" => JPCHOICES.English,
        _ => JPCHOICES.Kanji,
    });
}
