using JFlash.Forms;

namespace JFlash;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Old
        //Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new JFlashForm());
    }
}
