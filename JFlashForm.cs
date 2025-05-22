using Microsoft.WindowsAPICodePack.Dialogs;
using System.Text.RegularExpressions;

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
        public Dictionary<string, JFQuestionFile> QuestionFiles { get; private set; } = [];
        public int QuestionCount = 0;

        private const string ALLQUESTIONSTITLE = "Test &all questions in selected sets: ";
        private readonly List<CheckBox> AllCheckBoxes = [];

        private string questionPath = string.Empty;

        private readonly string[] choices =
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

        public JFlashForm()
        {
            InitializeComponent();
            rbAllQuestions.Text = ALLQUESTIONSTITLE + "0";
            this.cmbFrom.Items.AddRange(choices);
            this.cmbTo.Items.AddRange(choices);

            nsUpDown.Minimum = nsUpDown.Maximum = 0;

            var temp = RegistryHelper.LoadSetting("from");
            cmbFrom.Text = choices.Contains(temp) ? temp : "Kanji";

            temp = RegistryHelper.LoadSetting("to");
            cmbTo.Text = choices.Contains(temp) ? temp : "Romaji";

            // Should always work in normal circumstances.
            questionPath = RegistryHelper.LoadSetting("questions");
            if (Directory.Exists(questionPath))
            {
                BuildQuestions(questionPath);
                return;
            }

            // Dev-oriented path based on where the pre-made questions exist.
            questionPath = @"..\Questions";
            if (Directory.Exists(questionPath))
            {
                questionPath = Path.GetFullPath(questionPath);
                RegistryHelper.SaveSetting("questions", questionPath);
                BuildQuestions(questionPath);
                return;
            }

            // Check if folder of executable or any sub-folder has files. Use
            // the folder path of the first found file. Yes this is arbitray if
            // there are more than one folder containing question files.
            questionPath = AppContext.BaseDirectory;
            var fn = Directory.EnumerateFiles(".", "*.jpf", SearchOption.AllDirectories).FirstOrDefault();
            if (fn != null)
            {
                questionPath = Path.GetDirectoryName(Path.GetFullPath(fn)) ?? string.Empty;
                if (questionPath != null)
                {
                    RegistryHelper.SaveSetting("questions", questionPath);
                    BuildQuestions(questionPath);
                }
            }

            // Just point to My Documents and hope there are files. Simply let
            // the user pick the question files location from this point on.
            questionPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            RegistryHelper.SaveSetting("questions", questionPath);
            BuildQuestions(questionPath);
        }

        private void BuildQuestionaire()
        {
            Form frm = new JFQuestionaireForm(this
                , rbLimitQuestions.Checked ? Convert.ToInt16(nsUpDown.Value) : QuestionCount
                , cmbFrom.Text
                , cmbTo.Text);
            frm.Show();
        }

        private void BuildQuestions(string qPath)
        {
            pnlQuestionFiles.Controls.Clear();

            DirectoryInfo dir = new(qPath);

            var groupingSets = new SortedDictionary<string, List<string>>();

            foreach (FileInfo f in dir.GetFiles("*.jpf"))
            {
                string groupName = GetFilenamePrefix(f.Name);
                if (!groupingSets.TryGetValue(groupName, out List<string>? value))
                {
                    value = [];
                    groupingSets.Add(groupName, value);
                }

                value.Add(f.Name);
            }

            int panelWidth = this.pnlQuestionFiles.Width - 16;

            var flowTableQuestions = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 1,
                RowCount = 0,
            };
            flowTableQuestions.SuspendLayout();

            this.pnlQuestionFiles.Controls.Add(flowTableQuestions);

            bool firstCheckboxCreated = false;

            int counter = 0;
            foreach (var group in groupingSets)
            {
                // 1. Create the toggle button or checkbox
                var toggle = new CheckBox
                {
                    Text = $"▼ {group.Key}",
                    Appearance = Appearance.Button,
                    Checked = true,
                    Font = new Font(DefaultFont, FontStyle.Bold),
                    BackColor = Color.LightSteelBlue,
                    //Dock = DockStyle.Top,

                    Width = panelWidth,
                };

                // Collapsible panel
                var groupPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    BackColor = Color.Azure,
                    Width = panelWidth,

                    Dock = DockStyle.Top,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                };

                var checkBoxes = new List<CheckBox>();

                // "Select All" checkbox
                var selectAllCheckBox = new CheckBox
                {
                    Text = $"Select All &{++counter}",
                    AutoSize = true,
                    Font = new Font(DefaultFont, FontStyle.Bold),
                    Width = panelWidth,
                };

                selectAllCheckBox.CheckedChanged += (s, e) =>
                {
                    if (!selectAllCheckBox.Checked && checkBoxes.Count != checkBoxes.Count(c => c.Checked)) return;

                    foreach (var cb in checkBoxes)
                    {
                        cb.Checked = selectAllCheckBox.Checked;
                    }
                };

                selectAllCheckBox.KeyDown += (s, e) => BuildQuestionaire();

                if (!firstCheckboxCreated)
                {
                    // Added since alt-A on label always sets to the first control,
                    // but scroll position is askew. This produces a cleaner UI feel.
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
                            QuestionFiles.Add(item, new JFQuestionFile(
                                Path.Combine(questionPath, cb.Text),
                                JpStringToChoiceIndex(cmbFrom.Text),
                                JpStringToChoiceIndex(cmbTo.Text)));
                        }
                        else
                        {
                            QuestionFiles.Remove(item);
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
                toggle.CheckedChanged += (s, e) =>
                {
                    toggle.Text = $"{(toggle.Checked ? "▼" : "▶")} {group.Key}";
                    groupPanel.Visible = toggle.Checked;
                };

                toggle.KeyDown += (s, e) =>
                {
                    if (e.KeyValue == 13) toggle.Checked = !toggle.Checked;
                };

                // 5. Add both to the TableLayoutPanel
                flowTableQuestions.RowCount += 2;
                flowTableQuestions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                flowTableQuestions.Controls.Add(toggle, 0, flowTableQuestions.RowCount - 2);

                flowTableQuestions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                flowTableQuestions.Controls.Add(groupPanel, 0, flowTableQuestions.RowCount - 1);

                AllCheckBoxes.AddRange([.. checkBoxes]);
                chkSelectAll.CheckedChanged += (s, e) =>
                {
                    foreach (var cb in checkBoxes)
                    {
                        cb.Checked = chkSelectAll.Checked;
                    }
                };

                // Close up all groups except the first.
                toggle.Checked = (counter <= 1);
            }

            flowTableQuestions.ResumeLayout();
        }

        private static string GetFilenamePrefix(string name)
        {
            string fileName = Path.GetFileName(name);
            if (!string.IsNullOrEmpty(fileName))
            {
                string baseName = Path.GetFileNameWithoutExtension(fileName);
                Match match = RegexFilenamePrefix().Match(baseName);
                if (match.Success)
                {
                    return match.Groups[1].Value.TrimEnd(' ', '-');
                }
            }

            return string.Empty;
        }

        private const int ScrollBarWidth = 17; // standard scrollbar width on Windows
        private int previousClientWidth;

        private void HandlePanelSizing()
        {
            Console.WriteLine("resizing panel");

            bool hasVerticalScrollBar = pnlQuestionFiles.VerticalScroll.Visible;
            //int widthAdjustment = hasVerticalScrollBar ? -ScrollBarWidth : ScrollBarWidth;

            // Only adjust if there's a change in scrollbar visibility
            if ((hasVerticalScrollBar && previousClientWidth == pnlQuestionFiles.ClientSize.Width + ScrollBarWidth) ||
                (!hasVerticalScrollBar && previousClientWidth == pnlQuestionFiles.ClientSize.Width - ScrollBarWidth))
            {
                // No change
                return;
            }

            // Adjust width of your target panel
            //yourAdjustablePanel.Width = pnlQuestionFiles.ClientSize.Width;
            //foreach (var ctrl in pnlQuestionFiles.Controls)
            //{
            //    if (ctrl is CheckBox or ctrl is Panel)
            //    {

            //    }
            //}

            previousClientWidth = pnlQuestionFiles.ClientSize.Width;
        }

        private void UpdateQuestionFiles()
        {
            foreach (var question in QuestionFiles.Values)
            {
                foreach (var q in question.Questions)
                {
                    q.UpdateQuestion(JpStringToChoiceIndex(cmbFrom.Text), JpStringToChoiceIndex(cmbTo.Text));
                }
            }
        }

        private void UpdateQuestionFileSets()
        {
            int total = QuestionFiles.Sum((kvp) => kvp.Value.Questions.Count);

            rbAllQuestions.Text = ALLQUESTIONSTITLE + total;
            QuestionCount = total;

            nsUpDown.Maximum = total;

            GoEnabled();
        }

        private void GoEnabled()
        {
            btnGo.Enabled = QuestionCount > 0 && rbAllQuestions.Checked
                || nsUpDown.Value > 0 && rbLimitQuestions.Checked;
        }

        [GeneratedRegex(@"^(.*?)(\d+.*|[ -_][^ -_]+)$")]
        private static partial Regex RegexFilenamePrefix();

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            BuildQuestionaire();
        }

        private void NsUpDown_Enter(object sender, EventArgs e)
        {
            rbLimitQuestions.Checked = true;
        }

        private void Questions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) BtnGo_Click(sender, e);
        }

        private void CmbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegistryHelper.SaveSetting("from", cmbFrom.Text);
            UpdateQuestionFiles();
        }

        private void CmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegistryHelper.SaveSetting("to", cmbTo.Text);
            UpdateQuestionFiles();
        }

        private void BtnQuestionPath_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Select a folder",
                InitialDirectory = questionPath,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                questionPath = dialog.FileName ?? questionPath ?? string.Empty;
                RegistryHelper.SaveSetting("questions", questionPath);

                BuildQuestions(questionPath);
            }
        }

        private void NsUpDown_ValueChanged(object sender, EventArgs e)
        {
            GoEnabled();
        }

        private void RbAllQuestions_CheckedChanged(object sender, EventArgs e)
        {
            GoEnabled();
        }

        private void RbLimitQuestions_CheckedChanged(object sender, EventArgs e)
        {
            GoEnabled();
        }

        private void PnlQuestionFiles_ControlAdded(object sender, ControlEventArgs e)
        {
            HandlePanelSizing();
        }

        private void PnlQuestionFiles_ControlRemoved(object sender, ControlEventArgs e)
        {
            HandlePanelSizing();
        }

        private void PnlQuestionFiles_SizeChanged(object sender, EventArgs e)
        {
            HandlePanelSizing();
        }

        private void cmbFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) BtnGo_Click(sender, e);
        }

        private void cmbTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) BtnGo_Click(sender, e);
        }
    }
}