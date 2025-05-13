using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace JFlash
{
    public enum JPCHOICES
    {
        Kanji = 0,
        Hirigana = 1,
        Katakana = 2,
        Romaji = 3,
        English = 4,
    }

    public partial class JFlashForm : Form
    {
        public List<JFQuestionFile> SelectedQuestionFiles = new List<JFQuestionFile>();
        public int QuestionCount = 0;

        private const String ALLQUESTIONSTITLE = "Test a&ll questions in selected sets: ";
        private IDictionary<string, JFQuestionFile> QuestionFiles = new Dictionary<string, JFQuestionFile>();
        private List<CheckBox> AllCheckBoxes = new List<CheckBox>();

        private bool bSkipHandler = false;

        private string[] choices = 
        {
            "Kanji",
            "Hirigana",
            "Katakana",
            "Romaji",
            "English",
        };

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

        public JFlashForm()
        {
            InitializeComponent();
            rbAllQuestions.Text = ALLQUESTIONSTITLE + "0";
            this.cmbFrom.Items.AddRange(choices);
            this.cmbTo.Items.AddRange(choices);

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

            var flowTableQuestions = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 1,
                RowCount = 0,
                //BackColor = SystemColors.ControlLightLight,
                //BackColor = Color.DarkOrange,
            };
            flowTableQuestions.SuspendLayout();

            this.panel1.Controls.Add(flowTableQuestions);

            bool firstCheckboxCreated = false;

            foreach (var group in groups)
            {
                //int totalItems = group.Value.Count + 1; // +1 for "Select All"
                //int itemHeight = 24; // or use cb.PreferredHeight

                // 1. Create the toggle button or checkbox
                var toggle = new CheckBox
                {
                    Text = $"▼ {group.Key}",
                    Appearance = Appearance.Button,
                    AutoSize = true,
                    //FlatStyle = FlatStyle.Flat,
                    Font = new Font(DefaultFont, FontStyle.Bold),
                    BackColor = Color.LightSteelBlue,
                    Dock = DockStyle.Top,
                };

                // Collapsible panel
                var groupPanel = new FlowLayoutPanel
                {
                    //Text = group.Key,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Dock = DockStyle.Top,
                    //BackColor = SystemColors.ControlLightLight,
                    BackColor = Color.Azure,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    //Width = panelWidth,
                    //Height = (totalItems * itemHeight) + 38 - (totalItems),
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
                    if (!selectAllCheckBox.Checked && checkBoxes.Count != checkBoxes.Count(c => c.Checked)) return;

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
                        flowTableQuestions.ScrollControlIntoView(groupPanel);
                    };
                    firstCheckboxCreated = true;
                }

                groupPanel.Controls.Add(selectAllCheckBox);

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
                            // TODO: If no entry exists for type of entry then skip
                            QuestionFiles.Add(item, new JFQuestionFile(cb.Text, JpStringToChoiceIndex(cmbFrom.Text), JpStringToChoiceIndex(cmbTo.Text)));
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
                    groupPanel.Controls.Add(cb);
                }

                // 4. Toggle expansion
                toggle.Checked = true;
                toggle.CheckedChanged += (s, e) =>
                {
                    if (toggle.Checked)
                    {
                        toggle.Text = $"▼ {group.Key}";
                    }
                    else
                    {
                        toggle.Text = $"▶ {group.Key}"; 
                    }
                    groupPanel.Visible = toggle.Checked;
                };

                // 5. Add both to the TableLayoutPanel
                flowTableQuestions.RowCount += 2;
                flowTableQuestions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                flowTableQuestions.Controls.Add(toggle, 0, flowTableQuestions.RowCount - 2);

                flowTableQuestions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                flowTableQuestions.Controls.Add(groupPanel, 0, flowTableQuestions.RowCount - 1);

                AllCheckBoxes.AddRange(checkBoxes.ToArray());
                chkSelectAll.CheckedChanged += (s, e) =>
                {
                    foreach (var cb in checkBoxes)
                    {
                        cb.Checked = chkSelectAll.Checked;
                    }
                };
            }

            flowTableQuestions.ResumeLayout();
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

                match = Regex.Match(baseName, @"(.*?)( |-)(\p{L}+)$");
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
            Form frm = new JFQuestionaireForm(this
                , rbLimitQuestions.Checked ? Convert.ToInt16(nsUpDown.Value) : QuestionCount
                , cmbFrom.Text
                , cmbTo.Text);
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

        private void cmbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateQuestionFiles();
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateQuestionFiles();
        }

        private void updateQuestionFiles()
        {
            foreach (var question in QuestionFiles.Values)
            {
                foreach (var q in question.Questions)
                {
                    q.UpdateQuestion(JpStringToChoiceIndex(cmbFrom.Text), JpStringToChoiceIndex(cmbTo.Text));
                }
            }
        }
    }
}