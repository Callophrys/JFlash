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
        private JFQuestionSet QuestionSet;
        private JFlashForm parentForm;

        public JFQuestionaireForm(JFlashForm frm, int desiredQuestionCount)
        {
            parentForm = frm;
            parentForm.Hide();
            InitializeComponent();
            int x = parentForm.Location.X + (parentForm.Width - this.Width) / 2;
            int y = parentForm.Location.Y + (parentForm.Height - this.Height) / 2;
            this.Location = new Point(x, y);
            btnFinish.Enabled = false;
            lblStatusResultTotal.Text = desiredQuestionCount.ToString();
            txtLastQuery.Text = string.Empty;
            txtLastAttempt.Text = string.Empty;
            txtLastAnswer.Text = string.Empty;
            txtAdditional.Text = string.Empty;

            // Also randomize font choice and font style
            Random rnd = new Random(DateTime.UtcNow.Millisecond);
            lblQuestionQuery.Font = new System.Drawing.Font(
                  new String[6] { "0xProto", "Arial", "Bahnschrift", "Dubai", "Hasklug Nerd Font Mono", "Segoie UI" }[rnd.Next(0, 5)]
                , (float)rnd.Next(12, 20)
                , new System.Drawing.FontStyle[3] { System.Drawing.FontStyle.Regular, System.Drawing.FontStyle.Bold, System.Drawing.FontStyle.Italic }[rnd.Next(0, 2)]
                , System.Drawing.GraphicsUnit.Point
                , ((byte)(0)));


            // Need to set up randomized Question Set (q&a pairs)
            // and scores
            // Load first in set
            QuestionSet = new JFQuestionSet(parentForm.SelectedQuestionFiles
                , parentForm.QuestionCount
                , desiredQuestionCount );

            NextQuestion();
        }

        private void btnAbandon_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }

        public void NextQuestion()
        {
            JFQuestion q = QuestionSet.NextQuestion();
            lblQuestionPrompt.Text = q.Prompt;
            lblQuestionQuery.Text = q.Question;

            lblStatusResultAttempted.Text = QuestionSet.questionNumber.ToString();
            lblStatusResultScore.Text = (QuestionSet.questionNumber > 1 ? Convert.ToInt32(100 * QuestionSet.countCorrect / (QuestionSet.questionNumber - 1)) : 100 ) + "%";

            grpbxQuestion.Text = $"Question {QuestionSet.questionNumber} of {QuestionSet.countAttempted}";
        }

        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txtLastQuery.Text = QuestionSet.CurrentQuestion.Question;

                if (QuestionSet.IsEntryCorrect(txtAnswer.Text))
                {
                    lblStatusResultRight.Text = QuestionSet.countCorrect.ToString();

                    txtLastQuery.ForeColor = System.Drawing.Color.Blue;

                    txtLastAttempt.Text = $"Correct entry: {txtAnswer.Text}";
                    txtLastAttempt.ForeColor = System.Drawing.Color.Blue;

                    if (QuestionSet.CurrentQuestion.HasMultipleAnswers)
                    {
                        txtLastAnswer.Text = $"Others: {QuestionSet.CurrentQuestion.Answer.Replace(txtAnswer.Text,string.Empty).Replace(",,",",").Trim(',').Replace(",",", ")}";
                        txtLastAnswer.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        txtLastAnswer.Text = string.Empty;
                    }
                }
                else
                {
                    lblStatusResultWrong.Text = QuestionSet.countWrong.ToString();

                    txtLastQuery.ForeColor = System.Drawing.Color.Firebrick;

                    txtLastAttempt.Text = $"Wrong entry: {(!String.IsNullOrWhiteSpace(txtAnswer.Text) ? txtAnswer.Text : "[blank]")}";
                    txtLastAttempt.ForeColor = System.Drawing.Color.Firebrick;

                    txtLastAnswer.Text = $"Answer was: {QuestionSet.CurrentQuestion.Answer.Replace(",",", ")}";
                    txtLastAnswer.ForeColor = System.Drawing.Color.Firebrick;
                }

                if (!string.IsNullOrEmpty(QuestionSet.CurrentQuestion.Additional))
                {
                    txtAdditional.Text = QuestionSet.CurrentQuestion.Additional.Replace(",",", ");
                }

                if (QuestionSet.isFinished)
                {
                    btnAbandon.Enabled = false;
                    btnFinish.Enabled = true;
                    txtAnswer.Enabled = false;

                    lblStatusResultScore.Text = Convert.ToInt32(100 * QuestionSet.countCorrect / parentForm.QuestionCount) + "%";
                }
                else
                {
                    NextQuestion();
                }

                txtAnswer.Clear();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JFQuestionaireForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Show();
        }
    }
}