using JFlash.Classes;
using System.Diagnostics;

namespace JFlash.Forms;

public partial class JfMistakes : Form
{
    public JfMistakes(string logFile)
    {
        InitializeComponent();

        FormInfo defaultFormInfo = new()
        {
            Rectangle = new()
            {
                Size = ClientSize,
            },
            IsMaximized = false,
            StartPosition = StartPosition,
        };

        ScreenHelper.LoadWindowState(this, defaultFormInfo);

        Debug.WriteLine("JFMistakes constructor");

        // Start logging on construction.
        jfListViewMistakes.Start(logFile);
    }

    public void WriteMistakesLog(string query, string correctEntry, string wrongEntry, string setName)
    {
        jfListViewMistakes.WriteLogLine(query, correctEntry, wrongEntry, setName);
    }

    private void BtnClear_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            "Do you want to clear the entire mistake history?",
            "Clear",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2
        );

        if (result == DialogResult.Yes)
        {
            jfListViewMistakes.ClearLogs();
        }
    }

    private void BtnClose_Click(object sender, EventArgs e)
    {
        Hide();
    }

    private void JFMistakes_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Might want pause file watcher.
        e.Cancel = true;
        Hide();
    }

    private void JfMistakes_VisibleChanged(object sender, EventArgs e)
    {
        if (!Visible)
        {
            ScreenHelper.SaveWindowState(this);
        }
    }
}
