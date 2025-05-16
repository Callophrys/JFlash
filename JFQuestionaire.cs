using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JFlash
{
    public partial class JFQuestionaireForm : Form
    {
        private readonly JFQuestionSet QuestionSet;
        private readonly JFlashForm parentForm;

        public JFQuestionaireForm(JFlashForm frm, int desiredQuestionCount, string langFrom, string langTo)
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

            lblQuestionPrompt.Text = string.Format("Enter the {1} for the presented {0}", langFrom, langTo);

            // Also randomize font choice and font style
            Random rnd = new(DateTime.UtcNow.Millisecond);
            string[] fonts = [
                "0xProto",
                "Arial",
                "Bahnschrift",
                "BIZ UDGothic",
                "BIZ UDMincho",
                "BIZ UDPGothic",
                "BIZ UDMincho",
                "Dubai",
                "Hasklug Nerd Font Mono",
                "Meiryo",
                "Meiryo UI",
                "MS PMincho",
                "UD Digi Kyokasho N",
            ];

            lblQuestionQuery.Font = new System.Drawing.Font(fonts[rnd.Next(0, fonts.Length - 1)]
                , (float)rnd.Next(12, 20)
                , new System.Drawing.FontStyle[3] { System.Drawing.FontStyle.Regular, System.Drawing.FontStyle.Bold, System.Drawing.FontStyle.Italic }[rnd.Next(0, 2)]
                , System.Drawing.GraphicsUnit.Point
                , ((byte)(0)));


            // Need to set up randomized Question Set (q&a pairs)
            // and scores
            // Load first in set
            QuestionSet = new JFQuestionSet(parentForm.SelectedQuestionFiles
                , parentForm.QuestionCount
                , desiredQuestionCount);

            NextQuestion();
        }

        public void NextQuestion()
        {
            JFQuestion q = QuestionSet.NextQuestion();
            //lblQuestionPrompt.Text = q.Prompt;
            lblQuestionQuery.Text = q.Question;

            lblStatusResultAttempted.Text = QuestionSet.questionNumber.ToString();
            lblStatusResultScore.Text = (QuestionSet.questionNumber > 1 ? Convert.ToInt32(100 * QuestionSet.countCorrect / (QuestionSet.questionNumber - 1)) : 100 ) + "%";

            grpbxQuestion.Text = $"Question {QuestionSet.questionNumber} of {QuestionSet.countAttempted}";
        }

        private void EvaluateAnswer()
        {
            if (QuestionSet.CurrentQuestion == null)
            {
                txtLastQuery.Text = string.Empty;
                return;
            }

            // Just to turn off might be null warnings.
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            JFQuestion question = QuestionSet.CurrentQuestion;
#pragma warning restore IDE0059 // Unnecessary assignment of a value

            txtLastQuery.Text = QuestionSet.CurrentQuestion.Question;

            if (QuestionSet.IsEntryCorrect(txtAnswer.Text))
            {
                lblStatusResultRight.Text = QuestionSet.countCorrect.ToString();

                txtLastQuery.ForeColor = Color.Blue;

                txtLastAttempt.Text = $"Correct entry: {txtAnswer.Text}";
                txtLastAttempt.ForeColor = Color.Blue;

                if (QuestionSet.CurrentQuestion.HasMultipleAnswers)
                {
                    txtLastAnswer.Text = $"Others: {QuestionSet.CurrentQuestion.ScrubbedAnswer(txtAnswer.Text)}";
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

                txtLastQuery.ForeColor = Color.Firebrick;

                txtLastAttempt.Text = $"Wrong entry: {(!string.IsNullOrWhiteSpace(txtAnswer.Text) ? txtAnswer.Text : "[ blank ]")}";
                txtLastAttempt.ForeColor = Color.Firebrick;

                txtLastAnswer.Text = $"Answer was: {QuestionSet.CurrentQuestion.Answer.Replace(",",", ")}";
                txtLastAnswer.ForeColor = Color.Firebrick;
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

                lblStatusResultScore.Text = $"{(Convert.ToInt32(100 * QuestionSet.countCorrect / parentForm.QuestionCount))}%";
            }
            else
            {
                NextQuestion();
            }

            txtAnswer.Clear();
        }

        private void BtnAbandon_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }

        private void TxtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                EvaluateAnswer();
            }
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JFQuestionaireForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Show();
        }
    }
}