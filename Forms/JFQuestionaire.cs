using JFlash.Classes;

namespace JFlash.Forms;

public partial class JFQuestionaireForm : Form
{
    private readonly JFQuestionSet QuestionSet;
    private readonly JFlashForm parentForm;

    private JFMistakes? MistakesForm
    {
        get { return parentForm.MistakesForm; }
        set { parentForm.MistakesForm = value; }
    }

    private readonly string LangFrom;
    private readonly string LangTo;

    public JFQuestionaireForm(JFlashForm frm, int desiredQuestionCount, string langFrom, string langTo)
    {
        LangFrom = langFrom;
        LangTo = langTo;

        parentForm = frm;
        parentForm.Hide();
        InitializeComponent();
        lblQuestionHint.Text = string.Empty;
        int x = parentForm.Location.X + (parentForm.Width - this.Width) / 2;
        int y = parentForm.Location.Y + (parentForm.Height - this.Height) / 2;
        Location = new Point(x, y);
        btnFinish.Enabled = false;
        lblStatusResultTotal.Text = desiredQuestionCount.ToString();
        txtLastQuery.Text = string.Empty;
        txtLastAttempt.Text = string.Empty;
        txtLastAnswer.Text = string.Empty;
        txtAdditional.Text = string.Empty;

        lblQuestionInstruction.Text = string.Format("Enter the {1} for the presented {0}", langFrom, langTo);

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

        const int fontSizeMin = 20;
        const int fontSizeMax = 28;

        lblQuestionQuery.Font = langFrom switch
        {
            "English" => new Font(
                                    "MS Sans Serif",
                                    16,
                                    FontStyle.Regular,
                                    GraphicsUnit.Point,
                                    0),
            "Romaji" => new Font(
                                    "Arial",
                                    16,
                                    FontStyle.Regular,
                                    GraphicsUnit.Point,
                                    0),
            _ => new Font(
                                        fonts[rnd.Next(0, fonts.Length - 1)],
                                        rnd.Next(fontSizeMin, fontSizeMax),
                                        new FontStyle[3] {
                    FontStyle.Regular,
                    FontStyle.Bold,
                    FontStyle.Italic
                                        }[rnd.Next(0, 2)],
                                        GraphicsUnit.Point,
                                        0),
        };

        // Need to set up randomized Question Set (q&a pairs)
        // and scores
        // Load first in set
        QuestionSet = new JFQuestionSet(parentForm.QuestionFiles
            , parentForm.QuestionCount
            , desiredQuestionCount);

        if (MistakesForm == null || MistakesForm.IsDisposed)
        {
            MistakesForm = new JFMistakes();
        }

        MistakesForm.StartLogging(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "jflash", "mistakes.log")); 

        NextQuestion();
    }

    public void ClearQuestion()
    {
        lblQuestionTitle.Text = "No more questions";
        lblQuestionInstruction.Text = string.Empty;
        lblQuestionQuery.Text = string.Empty;
    }

    public void NextQuestion()
    {
        JFQuestion? q = QuestionSet.NextQuestion();
        if (q == null)
        {
            ClearQuestion();
            txtAnswer.Enabled = false;
            btnFinish.Enabled = true;
            btnFinish.Focus();

            return;
        }

        lblQuestionTitle.Text = q.Title;
        lblQuestionQuery.Text = q.Prompt;
        if ((LangFrom == "Hirigana" || LangFrom == "Katakana" || LangFrom == "Romaji") &&
            (LangTo == "Kanji" || LangTo == "English"))
        {
            lblQuestionHint.Text = q.Hint;
        }

        lblStatusResultAttempted.Text = QuestionSet.questionNumber.ToString();
        int result = QuestionSet.questionNumber > 1
            ? Convert.ToInt32(100 * QuestionSet.countCorrect / (QuestionSet.questionNumber - 1))
            : 100;
        lblStatusResultScore.Text = $"{result}%";
        groupBoxQuestion.Text = $"&Question {QuestionSet.questionNumber} of {QuestionSet.countAttempted}";
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

        txtLastQuery.Text = QuestionSet.CurrentQuestion.Prompt;

        if (QuestionSet.IsEntryCorrect(txtAnswer.Text))
        {
            lblStatusResultRight.Text = QuestionSet.countCorrect.ToString();

            txtLastQuery.ForeColor = Color.Blue;

            txtLastAttempt.Text = $"Correct entry: {txtAnswer.Text}";
            txtLastAttempt.ForeColor = Color.Blue;

            if (QuestionSet.CurrentQuestion.HasMultipleAnswers)
            {
                txtLastAnswer.Text = $"Others: {QuestionSet.CurrentQuestion.ScrubbedAnswer(txtAnswer.Text)}";
                txtLastAnswer.ForeColor = Color.Blue;
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

            txtLastAnswer.Text = $"Answer was: {QuestionSet.CurrentQuestion.FormattedAnswer}";
            txtLastAnswer.ForeColor = Color.Firebrick;

            parentForm.WriteMistakesLog(
                QuestionSet.CurrentQuestion.Prompt,
                QuestionSet.CurrentQuestion.Answer,
                txtAnswer.Text);
        }

        if (!string.IsNullOrEmpty(QuestionSet.CurrentQuestion.Additional))
        {
            txtAdditional.Text = QuestionSet.CurrentQuestion.FormattedAdditional;
        }

        if (QuestionSet.isFinished)
        {
            btnAbandon.Enabled = false;
            btnFinish.Enabled = true;
            txtAnswer.Enabled = false;

            lblStatusResultScore.Text = $"{(Convert.ToInt32(100 * QuestionSet.countCorrect / parentForm.QuestionCount))}%";

            ClearQuestion();
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
        Close();
    }

    private void JFQuestionaireForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        parentForm.Show();
    }

    private void BtnMistakes_Click(object sender, EventArgs e)
    {
        parentForm.ToggleMistakesForm();
    }

}