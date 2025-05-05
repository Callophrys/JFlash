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
        public JFQuestionFile[] m_SelectedQuestionFiles;
        public int m_iCtQuestions = 0;

        private const String m_strAllQuestions = "Test a&ll questions in selected sets: ";
        private JFQuestionFile[] m_QuestionFiles;
        private bool bSkipHandler = false;

        private string GetFilenamePrefix(string name)
        {
            string fileName = System.IO.Path.GetFileName(name);
            if (!string.IsNullOrEmpty(fileName))
            {
                string baseName = Path.GetFileNameWithoutExtension(fileName);
                var match = Regex.Match(baseName, @"/(.*?)(\d+)$/");
                if (match.Success)
                {
                    return match.Groups[1].Value.TrimEnd(' ', '-');
                }

                match = Regex.Match(baseName, @"/(.*?)( |-)(\p{L}+)$/");
                if (match.Success)
                {
                    return match.Groups[1].Value.TrimEnd(' ', '-');
                }
            }

            return string.Empty;
        }

        public JFlashForm()
        {

            InitializeComponent();
            rbAllQuestions.Text = m_strAllQuestions + "0";
            nsUpDown.Minimum = nsUpDown.Maximum = 0;

            //DirectoryInfo dir = new DirectoryInfo(@"C:\Users\ndonat2\Documents\P&G Laptop\Miscellaneous\jflash\jflash");
            DirectoryInfo dir = new DirectoryInfo(@"..\JFlash\Questions");
            m_QuestionFiles = new JFQuestionFile[dir.GetFiles("*.jpf").Length];

            //int i = 0;
            //foreach( FileInfo f in dir.GetFiles("*.jpf"))
            //{
            //    clbQuestionSets.Items.Add(f.Name);
            //    m_QuestionFiles[i++] = new JFQuestionFile( f.FullName );
            //}

            //foreach (var group in data)
            int i = 0;
            foreach (FileInfo f in dir.GetFiles("*.jpf"))
            {
                m_QuestionFiles[i++] = new JFQuestionFile( f.FullName );

                string groupName = GetFilenamePrefix(f.Name);
                if (string.IsNullOrEmpty(groupName))
                {
                    var cb = new CheckBox
                    {
                        Text = f.Name,
                        AutoSize = true
                    };

                    //// If an item is unchecked, uncheck "Select All"
                    //cb.CheckedChanged += (s, e) =>
                    //{
                    //    if (!cb.Checked && selectAllCheckBox.Checked)
                    //    {
                    //        selectAllCheckBox.Checked = false;
                    //    }
                    //    else if (checkBoxes.All(x => x.Checked))
                    //    {
                    //        selectAllCheckBox.Checked = true;
                    //    }
                    //};

                    //checkBoxes.Add(cb);
                    //innerPanel.Controls.Add(cb);

                    flpQuestions.Controls.Add(cb);

                    continue;
                }

                //var groupBox = new GroupBox
                //{
                //    Text = groupName,
                //    AutoSize = true,
                //    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                //    Padding = new Padding(10)
                //};

                //var innerPanel = new FlowLayoutPanel
                //{
                //    Dock = DockStyle.Top,
                //    AutoSize = true,
                //    FlowDirection = FlowDirection.TopDown,
                //    WrapContents = false
                //};

                //var checkBoxes = new List<CheckBox>();

                //// "Select All" checkbox
                //var selectAllCheckBox = new CheckBox
                //{
                //    Text = "Select All",
                //    AutoSize = true,
                //    Font = new Font(DefaultFont, FontStyle.Bold)
                //};

                //selectAllCheckBox.CheckedChanged += (s, e) =>
                //{
                //    foreach (var cb in checkBoxes)
                //    {
                //        cb.Checked = selectAllCheckBox.Checked;
                //    }
                //};

                //innerPanel.Controls.Add(selectAllCheckBox);

                //// Add item checkboxes
                //foreach (var item in group)
                //{
                //    var cb = new CheckBox
                //    {
                //        Text = item,
                //        AutoSize = true
                //    };

                //    // If an item is unchecked, uncheck "Select All"
                //    cb.CheckedChanged += (s, e) =>
                //    {
                //        if (!cb.Checked && selectAllCheckBox.Checked)
                //        {
                //            selectAllCheckBox.Checked = false;
                //        }
                //        else if (checkBoxes.All(x => x.Checked))
                //        {
                //            selectAllCheckBox.Checked = true;
                //        }
                //    };

                //    checkBoxes.Add(cb);
                //    innerPanel.Controls.Add(cb);
                //}

                //groupBox.Controls.Add(innerPanel);
                //flpQuestions.Controls.Add(groupBox);
            }

            dir = null;
        }

        private void UpdateQuestionFileSets(int iInsert, bool bAdd)
        {
            int total = 0;
            int i = 0, k = 0;

            //m_SelectedQuestionFiles = new JFQuestionFile[clbQuestionSets.CheckedIndices.Count + (bAdd ? 1 : -1)];
            //while( i < clbQuestionSets.CheckedIndices.Count )
            //{
            //    if( bAdd || iInsert != clbQuestionSets.CheckedIndices[i] )
            //    {
            //        total += m_QuestionFiles[clbQuestionSets.CheckedIndices[i]].m_iNumQuestions;
            //        m_SelectedQuestionFiles[k] = m_QuestionFiles[clbQuestionSets.CheckedIndices[i]];
            //        k++;
            //    }
            //    i++;
            //}

            if (bAdd)
            {
                total += m_QuestionFiles[iInsert].m_iNumQuestions;
                m_SelectedQuestionFiles[m_SelectedQuestionFiles.Length-1] = m_QuestionFiles[iInsert];
            }

            rbAllQuestions.Text = m_strAllQuestions + total;
            m_iCtQuestions = total;

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
            Form frm = new JFQuestionaireForm(this, rbLimitQuestions.Checked ? Convert.ToInt16(nsUpDown.Value) : m_iCtQuestions);
            frm.Show();
        }

        private void nsUpDown_Enter(object sender, EventArgs e)
        {
            rbLimitQuestions.Checked = true;
        }

        private void clbQuestionSets_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!bSkipHandler)
            {
                bSkipHandler = true;
                //UpdateQuestionFileSets(((ListBox)sender).SelectedIndex, true ^ clbQuestionSets.GetItemChecked(((ListBox)sender).SelectedIndex));
                //chkSelectAll.Checked = (clbQuestionSets.CheckedIndices.Count > 0);
                bSkipHandler = false;
            }
        }

        private void clbQuestionSets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnGo_Click(sender, e);
        }

        //private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!bSkipHandler)
        //    {
        //        //bSkipHandler = true;
        //        for (int i = 0; i < clbQuestionSets.Items.Count; i++)
        //        {
        //            clbQuestionSets.SetItemCheckState(i, chkSelectAll.CheckState);
        //        }
        //        //bSkipHandler = false;
        //    }
        //}
    }
}