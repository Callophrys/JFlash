using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace jflash
{
    public partial class JFlashForm : Form
    {
        public IList<JFQuestionFile> SelectedQuestionFiles = new List<JFQuestionFile>();
        public int QuestionCount = 0;

        private const String ALLQUESTIONSTITLE = "Test a&ll questions in selected sets: ";
        private IDictionary<string, JFQuestionFile> QuestionFiles = new Dictionary<string, JFQuestionFile>();

        private bool bSkipHandler = false;

        public JFlashForm()
        {

            InitializeComponent();
            rbAllQuestions.Text = ALLQUESTIONSTITLE + "0";
            nsUpDown.Minimum = nsUpDown.Maximum = 0;

            DirectoryInfo dir = new DirectoryInfo(@"..\JFlash\Questions");

            var groups = new SortedDictionary<string, List<string>>();

            foreach (FileInfo f in dir.GetFiles("*.jpf"))
            {
                string groupName = GetFilenamePrefix(f.Name);
                if (!groups.ContainsKey(groupName))
                {
                    groups.Add(groupName, new List<string>());
                }

                groups[groupName].Add(f.Name);
            }
            dir = null;

            int panelWidth = this.panel1.Width - 26;

            var flpQuestions = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                //BackColor = SystemColors.ControlLightLight,
                //BackColor = Color.DarkOrange,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
            };

            this.panel1.Controls.Add(flpQuestions);

            bool firstCheckboxCreated = false;

            foreach (var group in groups)
            {
                int totalItems = group.Value.Count + 1; // +1 for "Select All"
                int itemHeight = 24; // or use cb.PreferredHeight

                var groupBox = new GroupBox
                {
                    Text = group.Key,
                    //BackColor = SystemColors.ControlLightLight,
                    //BackColor = Color.Azure,
                    Padding = new Padding(10),
                    AutoSize = false,
                    Width = panelWidth,
                    Height = (totalItems * itemHeight) + 38 - (totalItems),
                };

                var innerPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Top,
                    AutoScroll = true,
                    //BackColor = SystemColors.ControlLightLight,
                    //BackColor = Color.Fuchsia,
                    FlowDirection = FlowDirection.TopDown,
                    Height = (totalItems * itemHeight) - totalItems,
                    WrapContents = false
                };

                var checkBoxes = new List<CheckBox>();

                // "Select All" checkbox
                var selectAllCheckBox = new CheckBox
                {
                    Text = "Select All",
                    AutoSize = true,
                    //BackColor = Color.ForestGreen,
                    Font = new Font(DefaultFont, FontStyle.Bold)
                };

                selectAllCheckBox.CheckedChanged += (s, e) =>
                {
                    if (!selectAllCheckBox.Checked) return;

                    foreach (var cb in checkBoxes)
                    {
                        cb.Checked = selectAllCheckBox.Checked;
                    }
                };

                selectAllCheckBox.KeyDown += (s, e) => questions_KeyDown(s, e);

                // Put this in since alt-A on label always takes to the first
                // control, but not quite. This looks cleaner.
                if (!firstCheckboxCreated)
                {
                    selectAllCheckBox.Enter += (s, e) =>
                    {
                        flpQuestions.ScrollControlIntoView(groupBox);
                    };
                    firstCheckboxCreated = true;
                }

                innerPanel.Controls.Add(selectAllCheckBox);

                // Add item checkboxes
                foreach (var item in group.Value)
                {
                    var cb = new CheckBox
                    {
                        Text = item,
                        AutoSize = true,
                        Padding = new Padding(10, 0, 0, 0)
                    };

                    // If an item is unchecked, uncheck "Select All"
                    cb.CheckedChanged += (s, e) =>
                    {
                        if (cb.Checked)
                        {
                            QuestionFiles.Add(item, new JFQuestionFile(cb.Text));
                        }
                        else
                        {
                            if (QuestionFiles.ContainsKey(item))
                            {
                                QuestionFiles.Remove(item);
                            }
                        }

                        UpdateQuestionFileSets();

                        if (!cb.Checked && selectAllCheckBox.Checked)
                        {
                            selectAllCheckBox.Checked = false;
                        }
                        else if (checkBoxes.All(x => x.Checked))
                        {
                            selectAllCheckBox.Checked = true;
                        }
                    };

                    checkBoxes.Add(cb);
                    innerPanel.Controls.Add(cb);
                }

                groupBox.Controls.Add(innerPanel);
                flpQuestions.Controls.Add(groupBox);
            }
        }

        private string GetFilenamePrefix(string name)
        {
            string fileName = System.IO.Path.GetFileName(name);
            if (!string.IsNullOrEmpty(fileName))
            {
                string baseName = Path.GetFileNameWithoutExtension(fileName);
                var match = Regex.Match(baseName, @"^(.*?)(\d+.*|[ -_][^ -_]+)$");
                if (match.Success)
                {
                    Console.WriteLine("this on");
                    return match.Groups[1].Value.TrimEnd(' ', '-');
                }

                match = Regex.Match(baseName, @"/(.*?)( |-)(\p{L}+)$/");
                if (match.Success)
                {
                    Console.WriteLine("that one");
                    return match.Groups[1].Value.TrimEnd(' ', '-');
                }
            }

            return string.Empty;
        }

        private void UpdateQuestionFileSets() //int iInsert, bool bAdd)
        {
            int total = QuestionFiles.Sum((kvp) => kvp.Value.m_iNumQuestions);
            SelectedQuestionFiles = QuestionFiles.Values.ToList();

            rbAllQuestions.Text = ALLQUESTIONSTITLE + total;
            QuestionCount = total;

            nsUpDown.Maximum = total;
            if (nsUpDown.Minimum < 1)
                nsUpDown.Value = total;
            nsUpDown.Minimum = Math.Sign(total);

            btnGo.Enabled = (total > 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Form frm = new JFQuestionaireForm(this, rbLimitQuestions.Checked ? Convert.ToInt16(nsUpDown.Value) : QuestionCount);
            frm.Show();
        }

        private void nsUpDown_Enter(object sender, EventArgs e)
        {
            rbLimitQuestions.Checked = true;
        }

        private void questions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnGo_Click(sender, e);
        }
    }
}