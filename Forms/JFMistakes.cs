using JFlash.Components;
using Microsoft.VisualBasic.Logging;

namespace JFlash.Forms;

//// 
//// listView1
//// 
//listViewGroup2.Header = "Results";
//listViewGroup2.Name = "listViewGroup1";
//listViewGroup2.Subtitle = "Kanji to English";
//listView1.Groups.AddRange(new ListViewGroup[] { listViewGroup2 });
//listView1.Location = new Point(6, 22);
//listView1.Name = "listView1";
//listview1.size = new size(267, 247);
//listView1.TabIndex = 0;
//listView1.UseCompatibleStateImageBehavior = false;


public partial class JFMistakes : Form
{
    public JFMistakes()
    {
        InitializeComponent();
    }

    public void StartLogging(string logfile)
    {
        jfListViewMistakes.Start(logfile);
    }

    public void WriteMistakesLog(string query, string correctEntry, string wrongEntry)
    {
        jfListViewMistakes.WriteLogLine(query, correctEntry, wrongEntry);
    }

    private void btnClear_Click(object sender, EventArgs e)
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

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
