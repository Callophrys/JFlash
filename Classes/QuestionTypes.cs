namespace JFlash.Classes;

public static class QuestionTypes
{
    public enum JFCHOICES
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

    public static string JfIntToChoiceString(int choice) => choice switch
    {
        QuestionFields.Hirigana => "Hirigana",
        QuestionFields.Katakana => "Katakana",
        QuestionFields.Romaji => "Romaji",
        QuestionFields.English => "English",
        _ => "Kanji",
    };

    public static int JfStringToChoiceIndex(string choice) => (int)(choice switch
    {
        "Hirigana" => JFCHOICES.Hirigana,
        "Katakana" => JFCHOICES.Katakana,
        "Romaji" => JFCHOICES.Romaji,
        "English" => JFCHOICES.English,
        _ => JFCHOICES.Kanji,
    });
}
