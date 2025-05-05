using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace jflash
{
    public partial class JFQuestionaireForm : Form
    {
        private JFQuestionSet m_QuestionSet;
        private JFlashForm m_frmMain;

        public JFQuestionaireForm(JFlashForm frm, int DesiredQuestionCount)
        {
            m_frmMain = frm;
            InitializeComponent();

            m_frmMain.Hide();
            btnFinish.Enabled = false;
            lblTotal.Text = DesiredQuestionCount.ToString();
            lblLastAns.Text = "";
            txtLastResponseA.Text = "";
            txtLastResponseB.Text = "";

            // Also randomize font choice and font style
            Random rnd = new Random();
            lblQuestion.Font = new System.Drawing.Font(
                  new String[9] { "Arial", "Batang", "Dotum", "DotumChe", "Gulim", "GulimChe", "NSimSun", "MS Mincho", "MSLingLiu" }[rnd.Next(0, 8)]
                , (float)rnd.Next(12, 20)
                , new System.Drawing.FontStyle[3] { System.Drawing.FontStyle.Regular, System.Drawing.FontStyle.Bold, System.Drawing.FontStyle.Italic }[rnd.Next(0, 2)]
                , System.Drawing.GraphicsUnit.Point
                , ((byte)(0)));


            // Need to set up randomized Question Set (q&a pairs)
            // and scores
            // Load first in set
            m_QuestionSet = new JFQuestionSet(m_frmMain.m_SelectedQuestionFiles
                , m_frmMain.m_iCtQuestions
                , DesiredQuestionCount );
            NextQuestion();
        }

        private void btnAbandon_Click(object sender, EventArgs e)
        {
            m_frmMain.Show();
            this.Close();
        }

        public void NextQuestion()
        {
            JFQuestion q = m_QuestionSet.NextQuestion();
            lblPrompt.Text = q.m_strPrompt;
            lblQuestion.Text = q.m_strQuestion;

            lblAttempted.Text = m_QuestionSet.m_iQuestionNo.ToString();
            lblScore.Text = (m_QuestionSet.m_iQuestionNo > 1 ? Convert.ToInt32(100 * m_QuestionSet.m_iNumRight / (m_QuestionSet.m_iQuestionNo - 1)) : 100 ) + "%";

            grpbxQuestion.Text = "Question " + m_QuestionSet.m_iQuestionNo + " of " + m_QuestionSet.m_iCtDesired;
        }

        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                lblLastAns.Text = m_QuestionSet.m_iQuestionNo + ") " + m_QuestionSet.m_CurrentQuestion.m_strQuestion;
                if (m_QuestionSet.IsEntryCorrect(txtAnswer.Text))
                {
                    lblRight.Text = m_QuestionSet.m_iNumRight.ToString();
                    lblLastAns.ForeColor = System.Drawing.Color.Blue;
                    txtLastResponseA.Text = "Correct entry:  " + txtAnswer.Text;
                    txtLastResponseA.ForeColor = System.Drawing.Color.Blue;
                    if (m_QuestionSet.m_CurrentQuestion.HasMultipleAnswers())
                    {
                        txtLastResponseB.Text = "Others:  " + m_QuestionSet.m_CurrentQuestion.m_strAnswer.Replace(txtAnswer.Text,"").Replace(",,",",").Trim(',').Replace(",",", ");
                        txtLastResponseB.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        txtLastResponseB.Text = "";
                    }
                }
                else
                {
                    lblWrong.Text = m_QuestionSet.m_iNumWrong.ToString();
                    lblLastAns.ForeColor = System.Drawing.Color.Red;
                    txtLastResponseA.Text = "Wrong entry:  " + txtAnswer.Text;
                    txtLastResponseA.ForeColor = System.Drawing.Color.Red;
                    txtLastResponseB.Text = "Correct is:  " + m_QuestionSet.m_CurrentQuestion.m_strAnswer.Replace(",",", ");
                    txtLastResponseB.ForeColor = System.Drawing.Color.Red;
                }

                if (m_QuestionSet.m_bFinished)
                {
                    btnAbandon.Enabled = false;
                    btnFinish.Enabled = true;
                    txtAnswer.Enabled = false;
                    lblScore.Text = Convert.ToInt32(100 * m_QuestionSet.m_iNumRight / m_frmMain.m_iCtQuestions) + "%";
                }
                else
                    NextQuestion();

                txtAnswer.Clear();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();  // JFQuestionaireForm_FormClosed will show main
        }

        private void JFQuestionaireForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_frmMain.Show();
        }
    }
}