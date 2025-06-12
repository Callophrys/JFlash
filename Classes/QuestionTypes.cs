namespace JFlash.Classes;

public static class QuestionTypes
{
    public enum JPCHOICES
    {
        Kanji = 0,
        Hirigana = 1,
        Katakana = 2,
        Romaji = 3,
        English = 4,
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
        1 => "Hirigana",
        2 => "Katakana",
        3 => "Romaji",
        4 => "English",
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
