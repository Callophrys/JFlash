using JFlash.Classes;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace JFlash.Forms;

public partial class JFlashForm : Form
{
    public Dictionary<string, JfQuestionFile> QuestionFiles { get; private set; } = [];
    public int QuestionCount = 0;

    private const string ALLQUESTIONSTITLE = "Test &all questions in selected sets: ";
    private readonly List<CheckBox> AllCheckBoxes = [];
    private readonly Dictionary<string, GroupFiles> selectedGroupFiles = [];
    private readonly List<CheckBox> toggleCheckBoxes = [];

    private bool skipEventsChkSelectAll = false;
    private bool skipEventsChkToggleAll = false;

    private string questionPath = string.Empty;
    public JfMistakes? MistakesForm { get; set; }

    private int subsetSize = 7;
    private const int ScrollBarWidth = 17; // standard scrollbar width on Windows
    private int previousClientWidth;

    private bool ShowMistakes;

    public static readonly string LogFile = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "jflash",
        "mistakes.log");

    public JFlashForm()
    {
        InitializeComponent();
        AcceptButton = btnGo;
        rbAllQuestions.Text = ALLQUESTIONSTITLE + "0";
        cmbFrom.Items.AddRange(QuestionTypes.choices);
        cmbTo.Items.AddRange(QuestionTypes.choices);

        nsQuestionLimit.Maximum = 1;

        string temp = RegistryHelper.LoadSetting("from", "Kanji");
        cmbFrom.Text = QuestionTypes.choices.Contains(temp) ? temp : "Kanji";

        temp = RegistryHelper.LoadSetting("to", "Romaji");
        cmbTo.Text = QuestionTypes.choices.Contains(temp) ? temp : "Romaji";

        decimal ssz = Math.Max(1, Convert.ToDecimal(RegistryHelper.LoadSetting("subsetsize", 7)));
        if (ssz > nsSubsetSize.Maximum) nsSubsetSize.Maximum = ssz;
        nsSubsetSize.Value = Math.Max(1, Convert.ToDecimal(RegistryHelper.LoadSetting("subsetsize", 7)));

        // Should always work in normal circumstances.
        questionPath = RegistryHelper.LoadSetting("questions", string.Empty);
        if (Directory.Exists(questionPath))
        {
            BuildQuestions();
            UpdateChkExpandAllOnceWithoutEffects();
            return;
        }

        // Dev-oriented path based on where the pre-made questions exist.
        questionPath = @"..\Questions";
        if (Directory.Exists(questionPath))
        {
            questionPath = Path.GetFullPath(questionPath);
            RegistryHelper.SaveSetting("questions", questionPath);
            BuildQuestions();
            UpdateChkExpandAllOnceWithoutEffects();
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
                BuildQuestions();
                UpdateChkExpandAllOnceWithoutEffects();
            }
        }

        // Just point to My Documents and hope there are files. Simply let
        // the user pick the question files location from this point on.
        questionPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        RegistryHelper.SaveSetting("questions", questionPath);

        BuildQuestions();
        UpdateChkExpandAllOnceWithoutEffects();
    }

    #region Public Methods

    public void ToggleMistakesForm()
    {
        bool mistakesFormMissingOrDown = MistakesForm == null || MistakesForm.IsDisposed;

        if (!ShowMistakes)
        {
            if (mistakesFormMissingOrDown) MistakesForm = new JfMistakes(LogFile);
            MistakesForm!.Show();
        }
        else if (!mistakesFormMissingOrDown)
        {
            MistakesForm!.Hide();
        }

        ShowMistakes = !ShowMistakes;
    }

    public void WriteMistakesLog(string query, string correctEntry, string wrongEntry, string setName)
    {
        MistakesForm?.WriteMistakesLog(query, correctEntry, wrongEntry, setName);
    }

    #endregion Public Methods

    #region Private Methods

    private void BuildQuestionaire()
    {
        UpdateQuestionFiles();

        Form frm = new JfQuestionaireForm(this
            , rbLimitQuestions.Checked ? Convert.ToInt16(nsQuestionLimit.Value) : QuestionCount
            , cmbFrom.Text
            , cmbTo.Text);
        frm.Show();
    }

    private void BuildQuestions()
    {
        QuestionFiles.Clear();
        toggleCheckBoxes.Clear();
        selectedGroupFiles.Clear();
        AllCheckBoxes.Clear();
        // Keep the inner pane if it exists yet. It is the only child.
        if (pnlQuestionFiles.Controls.Count > 0)
        {
            pnlQuestionFiles.Controls[0].Controls.Clear();
        }

        if (string.IsNullOrEmpty(questionPath)) return;

        DirectoryInfo dir = new(questionPath);
        SortedDictionary<string, List<string>> groupingSets = [];
        SortedDictionary<string, Dictionary<string, JfQuestionFile>> testGroupingSets = [];
        Dictionary<string, GroupFiles> savedGroupFiles = GetSavedSelectionOptions(Convert.ToInt32(nsSubsetSize.Value));
        Dictionary<string, Dictionary<string, JfQuestionFile>> testGroupSubGroups = [];

        List<CheckBox> questionFileCheckBoxes = [];
        List<CheckBox> groupingCheckBoxes = [];

        SortedDictionary<string, List<string>> testD = [];

        int maxSourceQuestions = 0;
        foreach (FileInfo fi in dir.GetFiles("*.jpf"))
        {
            var groupingName = Path.GetFileNameWithoutExtension(fi.Name);
            var tempQuestionFile = new QuestionFile(fi.FullName);
            maxSourceQuestions = Math.Max(maxSourceQuestions, tempQuestionFile.QuestionCount);
            var dictionaryOfSubsets = tempQuestionFile.GenerateSubsets(Math.Min(tempQuestionFile.QuestionCount, (int)nsSubsetSize.Value));

            // Convert subsets of "file" QuestionFile into set of subsets.
            var subsetQuestionFiles = JFQuestionFileFactory.GenerateQuestionFiles(dictionaryOfSubsets, 2, 3);

            testGroupSubGroups.Add(groupingName, subsetQuestionFiles);
        }

        // Prevent control from supporting silly numbers but do
        // support subsets that can encompass the file with the
        // most questions.
        nsSubsetSize.Maximum = maxSourceQuestions;

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

        bool firstCheckboxCreated = false;

        int counter = 0;
        foreach (var group in testGroupSubGroups.Keys)
        {
            // 1. Toggle expansion
            //

            // 1.a. Create toggle checkbox 
            var toggle = new CheckBox
            {
                Text = $"▼ {group}",
                Appearance = Appearance.Button,
                Checked = true,
                Font = new Font(DefaultFont, FontStyle.Bold),
                BackColor = Color.LightSteelBlue,
                Name = $"chkSelectSetToggle{group}",
                //Dock = DockStyle.Top,

                Width = panelWidth,
            };

            toggleCheckBoxes.Add(toggle);

            // 2. Collapsible panel
            //
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

            // 3. "Select All" checkbox
            //

            // 3.a. Create and place in first position of group panel.
            var selectAllCheckBox = new CheckBox
            {
                Text = $"&{++counter}. Select All",
                AutoSize = true,
                Font = new Font(DefaultFont, FontStyle.Bold),
                Width = panelWidth,
            };

            // Create a pane so user can click anywhere across the "parent" pane to click.
            var selectAllPane = new Panel();
            selectAllPane.Width = panelWidth;
            selectAllPane.Height = selectAllCheckBox.Height;
            selectAllPane.Controls.Add(selectAllCheckBox);
            selectAllPane.Click += (s, e) => selectAllCheckBox.Checked = !selectAllCheckBox.Checked;

            groupingCheckBoxes.Add(selectAllCheckBox);
            groupPanel.Controls.Add(selectAllPane);

            // 4. Add item checkboxes
            //

            // All checkboxes in grouping.
            var groupCheckBoxes = new List<CheckBox>();

            // Populate with the actual questions.
            //foreach (var item in group.Value)
            foreach (var item in testGroupSubGroups[group])
            {
                GroupFiles gp = savedGroupFiles.TryGetValue(group, out GroupFiles? x) ? x : new GroupFiles();
                bool isFileSelected = gp.files.Contains(item.Key);

                var cb = new CheckBox
                {
                    Checked = isFileSelected,
                    Text = item.Key,
                    AutoSize = true,
                    Padding = new Padding(10, 0, 0, 0),
                    Width = panelWidth,
                };

                if (isFileSelected)
                {
                    var qf = item.Value;

                    QuestionFiles.Add(cb.Text, qf);

                    gp.Expanded = toggle.Checked;
                    gp.files.Add(cb.Text);

                    selectedGroupFiles.TryAdd(group, gp);
                }

                cb.CheckedChanged += (s, e) =>
                {
                    if (cb.Checked)
                    {
                        /* cb.Text is same as item; both are the filename */
                        var qf = item.Value;

                        QuestionFiles.Add(cb.Text, qf);

                        // NOTE: gp from the outside checkbox creation method
                        gp.Expanded = toggle.Checked;
                        gp.files.Add(cb.Text);

                        selectedGroupFiles.TryAdd(group, gp);
                    }
                    else
                    {
                        QuestionFiles.Remove(item.Key);

                        // NOTE: gp seached for inside this handler method.
                        //       Perhaps needed since gp could be destroyed
                        //       by now.
                        if (selectedGroupFiles.TryGetValue(group, out GroupFiles? gp))
                        {
                            gp.Expanded = toggle.Checked;
                            if (gp.files.Contains(cb.Text)) gp.files.Remove(cb.Text);
                        }
                    }

                    var selectedGroupFilesJson = JsonSerializer.Serialize(selectedGroupFiles);
                    RegistryHelper.SaveSetting("selection", selectedGroupFilesJson);

                    UpdateQuestionFileSets();

                    // If an item is unchecked, uncheck "Select All" for the grouping.
                    if (!cb.Checked && selectAllCheckBox.Checked)
                    {
                        selectAllCheckBox.Checked = false;

                        // Update for the everything, all-groupsets, control.
                        if (chkSelectAll.Checked)
                        {
                            skipEventsChkSelectAll = true;
                            chkSelectAll.CheckState = questionFileCheckBoxes.Any(c => c.Checked)
                                ? CheckState.Indeterminate
                                : CheckState.Unchecked;
                            skipEventsChkSelectAll = false;
                        }
                    }
                    else if (groupCheckBoxes.All(x => x.Checked))
                    {
                        selectAllCheckBox.Checked = true;

                        // Update for the everything, all-groupsets, control.
                        if (questionFileCheckBoxes.Count == questionFileCheckBoxes.Count(c => c.Checked))
                        {
                            skipEventsChkSelectAll = true;
                            chkSelectAll.CheckState = CheckState.Checked;
                            skipEventsChkSelectAll = false;
                        }
                    }
                };

                cb.KeyUp += (s, e) =>
                {
                    if (e.KeyValue == 13)
                    {
                        if (cb.Checked) BuildQuestionaire();
                        else cb.Checked = true;
                    }
                };

                var checkboxPane = new Panel();
                checkboxPane.Margin = new(0);
                checkboxPane.Width = panelWidth;
                checkboxPane.Height = cb.Height;
                checkboxPane.Controls.Add(cb);
                checkboxPane.Click += (s, e) => cb.Checked = !cb.Checked;

                groupCheckBoxes.Add(cb);        // save ref in grouping list
                questionFileCheckBoxes.Add(cb); // save ref to everything list
                groupPanel.Controls.Add(checkboxPane);
            }

            // 3.b. (Select all continued) Check if "Select All" needs to be checked
            selectAllCheckBox.Checked = groupCheckBoxes.Count == groupCheckBoxes.Count(c => c.Checked);

            // 3.c. Add event handler to "Select All"
            selectAllCheckBox.CheckedChanged += (s, e) =>
            {
                if (!selectAllCheckBox.Checked
                    && groupCheckBoxes.Count != groupCheckBoxes.Count(c => c.Checked))
                {
                    return;
                }

                foreach (var cb in groupCheckBoxes)
                {
                    cb.Checked = selectAllCheckBox.Checked;
                }

                skipEventsChkSelectAll = true;
                chkSelectAll.CheckState = groupingCheckBoxes.All(c => c.Checked)
                    ? CheckState.Checked
                    : chkSelectAll.Checked && groupingCheckBoxes.Any(c => c.Checked)
                        ? CheckState.Indeterminate
                        : CheckState.Unchecked;
                ;
                skipEventsChkSelectAll = false;
            };

            selectAllCheckBox.KeyUp += (s, e) =>
            {
                if (e.KeyValue == 13)
                {
                    BuildQuestionaire();
                }
            };

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

            // 1.b. (Toggle continued) Set checked and actual panel
            //      expansion of toggle before adding handlers.
            toggle.Checked = GetToggleState(savedGroupFiles, group, counter);
            toggle.Text = $"{(toggle.Checked ? "▼" : "▶")} {group}";
            groupPanel.Visible = toggle.Checked;

            // 1.c. Add event handlers.
            toggle.CheckedChanged += (s, e) =>
            {
                toggle.Text = $"{(toggle.Checked ? "▼" : "▶")} {group}";
                groupPanel.Visible = toggle.Checked;

                if (selectedGroupFiles.TryGetValue(group, out GroupFiles? gp))
                {
                    gp.Expanded = toggle.Checked;
                }
                else
                {
                    gp = new GroupFiles()
                    {
                        Expanded = toggle.Checked,
                    };
                    selectedGroupFiles.Add(group, gp);
                }

                var selectedGroupFilesJson = JsonSerializer.Serialize(selectedGroupFiles);
                RegistryHelper.SaveSetting("selection", selectedGroupFilesJson);

                UpdateChkExpandAllOnceWithoutEffects();
            };

            toggle.KeyDown += (s, e) =>
            {
                if (e.KeyValue == 13) toggle.Checked = !toggle.Checked;
            };

            // Required for the enter key press work on the keydown event.
            toggle.PreviewKeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) e.IsInputKey = true;
            };

            // 5. Add toggle and groupPanel to the TableLayoutPanel
            //
            flowTableQuestions.RowCount += 2;
            flowTableQuestions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            flowTableQuestions.Controls.Add(toggle, 0, flowTableQuestions.RowCount - 2);

            flowTableQuestions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            flowTableQuestions.Controls.Add(groupPanel, 0, flowTableQuestions.RowCount - 1);

            AllCheckBoxes.AddRange([.. groupCheckBoxes]);

            // 6. Update handler for everything checkbox.
            chkSelectAll.CheckedChanged += (s, e) =>
            {
                if (skipEventsChkSelectAll) return;

                foreach (var cb in groupCheckBoxes)
                {
                    // Checking all of these will update the select all for
                    // the grouping.
                    // TODO: Maybe check the group select all groupings
                    // instead. Those events would automatically set the
                    // for all the checkboxes in a group. Ugh -- too many
                    // events raising more events!
                    cb.Checked = chkSelectAll.Checked;
                }

                var selectedGroupFilesJson = JsonSerializer.Serialize(selectedGroupFiles);
                RegistryHelper.SaveSetting("selection", selectedGroupFilesJson);
            };
        }

        // 7. Update total count and enable go button.
        UpdateQuestionFileSets();

        if (groupingCheckBoxes.All(x => x.Checked))
        {
            skipEventsChkSelectAll = true;
            chkSelectAll.Checked = true;
            chkSelectAll.CheckState = CheckState.Checked;
            skipEventsChkSelectAll = false;
        }

        pnlQuestionFiles.Controls.Clear();
        pnlQuestionFiles.Controls.Add(flowTableQuestions);

        flowTableQuestions.ResumeLayout();
    }

    private void JFlashForm_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
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

    private static Dictionary<string, GroupFiles> GetSavedSelectionOptions(int currentSubsetSize)
    {
        string savedGroupFilesText = RegistryHelper.LoadSetting("selection", string.Empty);
        object? tempSavedGroupFiles;
        try
        {
            tempSavedGroupFiles = JsonSerializer.Deserialize(savedGroupFilesText, typeof(Dictionary<string, GroupFiles>));
            Dictionary<string, GroupFiles> savedGroupFiles =
                tempSavedGroupFiles != null ? (Dictionary<string, GroupFiles>)tempSavedGroupFiles : [];

            foreach (var a in savedGroupFiles.Values)
            {
                HashSet<string> filteredFiles = [];
                foreach (var s in a.files)
                {
                    var x = Convert.ToInt32(s[^2..]);
                    if (x % currentSubsetSize == 0) filteredFiles.Add(s);
                }

                a.files = filteredFiles;
            }

            // Update storage in reg. -- kind of a hack here.
            var savedGroupFilesJson = JsonSerializer.Serialize(savedGroupFiles);
            RegistryHelper.SaveSetting("selection", savedGroupFilesJson);

            return savedGroupFiles;
        }
        catch
        {
            return [];
        }
    }

    private static bool GetToggleState(Dictionary<string, GroupFiles> dictionary, string key, int counter)
    {
        // If missing or post-reset, close up all groups except the first.
        if (dictionary.Count < 1)
        {
            return (counter <= 1);
        }

        // If group is found then collapse or expand per value.
        if (dictionary.TryGetValue(key, out var gp))
        {
            return gp.Expanded;
        }

        // If group not found just collapse it.
        return false;
    }

    private void HandlePanelSizing()
    {
        //Console.WriteLine("resizing panel");

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

    private void UpdateChkExpandAllOnceWithoutEffects()
    {
        bool expand = toggleCheckBoxes.All(c => c.Checked);
        if (!skipEventsChkToggleAll && chkExpandAll.Checked != expand)
        {
            skipEventsChkToggleAll = true;

            chkExpandAll.Checked = expand;
            chkExpandAll.Text = expand ? "▼" : "▶";

            skipEventsChkToggleAll = false;
        }
    }

    private void UpdateQuestionFiles()
    {
        foreach (var questionSet in QuestionFiles.Values)
        {
            foreach (var question in questionSet.JfQuestions)
            {
                question.UpdateQuestion(
                    QuestionTypes.JfStringToChoiceIndex(cmbFrom.Text),
                    QuestionTypes.JfStringToChoiceIndex(cmbTo.Text));
            }
        }
    }

    private void UpdateQuestionFileSets()
    {
        int total = QuestionFiles.Sum((kvp) => kvp.Value.Questions.Count);

        rbAllQuestions.Text = ALLQUESTIONSTITLE + total;
        QuestionCount = total;

        nsQuestionLimit.Maximum = total;

        GoEnabled();
    }

    private void GoEnabled()
    {
        btnGo.Enabled = QuestionCount > 0 && (
            rbAllQuestions.Checked && nsSubsetSize.Value > 0 ||
            rbLimitQuestions.Checked && nsQuestionLimit.Value > 0);
    }

    [GeneratedRegex(@"^(.*?)(\d+.*|[ -_][^ -_]+)$")]
    private static partial Regex RegexFilenamePrefix();

    #endregion Private Methods

    #region Event Handlers

    private void BtnExit_Click(object sender, EventArgs e) => Close();

    private void BtnGo_Click(object sender, EventArgs e) => BuildQuestionaire();

    private void BtnMistakes_Click(object sender, EventArgs e) => ToggleMistakesForm();

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

            BuildQuestions();
        }
    }

    private void BtnSwapFormats_Click(object sender, EventArgs e)
    {
        if (cmbFrom.SelectedItem == null && cmbTo.SelectedItem == null) return;

        (cmbTo.SelectedItem, cmbFrom.SelectedItem) = (cmbFrom.SelectedItem, cmbTo.SelectedItem);
    }

    private void ChkExpandAll_CheckedChanged(object sender, EventArgs e)
    {
        if (skipEventsChkToggleAll) return;

        skipEventsChkToggleAll = true;

        pnlQuestionFiles.Controls[0].SuspendLayout();

        chkExpandAll.Text = chkExpandAll.Checked ? "▼" : "▶";
        foreach (CheckBox cb in toggleCheckBoxes.Where(x => x.Checked != chkExpandAll.Checked))
        {
            cb.Checked = chkExpandAll.Checked;
        }
        pnlQuestionFiles.Controls[0].ResumeLayout();

        skipEventsChkToggleAll = false;
    }

    private void CmbFrom_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyValue == 13)
        {
            RegistryHelper.SaveSetting("from", cmbFrom.Text);
        }
    }

    private void CmbFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        RegistryHelper.SaveSetting("from", cmbFrom.Text);
    }

    private void CmbTo_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyValue == 13)
        {
            RegistryHelper.SaveSetting("to", cmbTo.Text);
        }
    }

    private void CmbTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        RegistryHelper.SaveSetting("to", cmbTo.Text);
    }

    private void NsQuestionLimit_Enter(object sender, EventArgs e)
    {
        rbLimitQuestions.Checked = true;
    }

    private void NsQuestionLimit_ValueChanged(object sender, EventArgs e) => GoEnabled();

    private void NsSubsetSize_ValueChanged(object sender, EventArgs e)
    {
        subsetSize = (int)nsSubsetSize.Value;
        RegistryHelper.SaveSetting("subsetsize", subsetSize.ToString());
        BuildQuestions();
    }

    private void PnlQuestionFiles_ControlAdded(object sender, ControlEventArgs e) => HandlePanelSizing();

    private void PnlQuestionFiles_ControlRemoved(object sender, ControlEventArgs e) => HandlePanelSizing();

    private void PnlQuestionFiles_SizeChanged(object sender, EventArgs e) => HandlePanelSizing();

    //private void Questions_KeyDown(object sender, KeyEventArgs e)
    //{
    //    if (e.KeyValue == 13) BtnGo_Click(sender, e);
    //}

    private void RbAllQuestions_CheckedChanged(object sender, EventArgs e) => GoEnabled();

    private void RbLimitQuestions_CheckedChanged(object sender, EventArgs e) => GoEnabled();

    private void JFlashForm_Load(object sender, EventArgs e)
    {
        //Rectangle r = ScreenHelper.GetFormDimensions(this);
        //if (r.Width != 0)
        //{
        //    Size = r.Size;
        //    Location = r.Location;
        //}
    }

    private void JFlashForm_Move(object sender, EventArgs e)
    {
        //ScreenHelper.SaveFormDimensions(this);
    }

    private void JFlashForm_Resize(object sender, EventArgs e)
    {
        //ScreenHelper.SaveFormDimensions(this);
    }

    private void JFlashForm_Shown(object sender, EventArgs e)
    {
        return;

        TableLayoutPanel? tlp = null;
        foreach (Control ctrl in pnlQuestionFiles.Controls)
            if (ctrl is TableLayoutPanel cb)
                tlp = ctrl as TableLayoutPanel;

        if (tlp != null)
        {
            //foreach (Control ctrl in tlp.Controls)

            int h = tlp.Margin.Vertical;
            foreach (Control ctrl in tlp.Controls)
            {
                h += ctrl.Height;
                if (ctrl is CheckBox cb && cb.Checked)
                {
                    //pnlQuestionFiles.ScrollControlIntoView(cb); // Scroll to the first checked checkbox
                    //var offset = h - pnlQuestionFiles.Height - cb.Height;
                    //tlp.ScrollControlIntoView(cb);

                    /* Bottom */
                    //var offset = tlp.DisplayRectangle.Height - tlp.ClientRectangle.Height + cb.ClientRectangle.Height;

                    var offset = tlp.DisplayRectangle.Height - tlp.ClientRectangle.Height; // - cb.ClientRectangle.Height;
                    tlp.AutoScrollPosition = new Point(0, h); // h - tlp.DisplayRectangle.Height);

                    //var offset = cb.Top - pnlQuestionFiles.Top;
                    //pnlQuestionFiles.AutoScroll = true;
                    //pnlQuestionFiles.AutoScrollPosition = new Point(0, 300);
                    break;
                }
            }
        }
    }

    #endregion Event Handlers
}
