namespace JFlash.Classes;

public static class JfHelper
{
    private static readonly string ErrorLogFile = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "jflash",
        "errors.log");

    public static void LogError(string message)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(ErrorLogFile) ?? string.Empty);
        File.AppendAllText(ErrorLogFile, message);
    }
}
