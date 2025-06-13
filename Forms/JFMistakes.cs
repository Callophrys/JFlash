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

        // Start logging on construction.
        // TODO: move this out to JFForm.
        jfListViewMistakes.Start(JFlashForm.LogFile);
    }

    public void WriteMistakesLog(string query, string correctEntry, string wrongEntry)
    {
        jfListViewMistakes.WriteLogLine(query, correctEntry, wrongEntry);
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
        Close();
    }
}
