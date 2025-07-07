using JFlash.Classes;

namespace JFlash.Forms;

public partial class JfQuestionaireForm : Form
{
    private readonly string LangFrom;
    private readonly string LangTo;

    private readonly JfQuestionSet QuestionSet;
    private readonly JFlashForm parentForm;

    private JfMistakes? MistakesForm
    {
        get => parentForm.MistakesForm;
        set => parentForm.MistakesForm = value;
    }

    public JfQuestionaireForm(
        JFlashForm mainForm,
        int desiredQuestionCount,
        string langFrom,
        string langTo)
    {
        LangFrom = langFrom;
        LangTo = langTo;

        parentForm = mainForm;
        parentForm.Hide();

        InitializeComponent();
        btnNextQuestion.Text = "\u2771";
        btnNextQuestion.Padding = new(2, 0, 0, 1);
        this.LoadWindowState(mainForm);

        PrepareControls(desiredQuestionCount);
        SetRandomFont();

        // Prepare randomized Question Set (q&a pairs) and scores.
        QuestionSet = new JfQuestionSet(
            parentForm.QuestionFiles,
            parentForm.QuestionCount,
            desiredQuestionCount);

        if (MistakesForm == null || MistakesForm.IsDisposed)
        {
            MistakesForm = new JfMistakes(JFlashForm.LogFile);
        }

        NextQuestion();
    }

    #region Private Methods

    private void ClearQuestion()
    {
        lblQuestionTitle.Text = "No more questions";
        lblQuestionInstruction.Text = string.Empty;
        lblQuestionQuery.Text = string.Empty;
        lblQuestionHint.Text = string.Empty;

        btnNextQuestion.Enabled = false;
        btnFinish.Text = "&Finish";
        btnFinish.Focus();
    }

    private void EvaluateAnswer()
    {
        if (QuestionSet.CurrentQuestion == null)
        {
            txtLastQuery.Text = string.Empty;
            return;
        }

#pragma warning disable IDE0059 // Unnecessary assignment of a value
        JfQuestion question = QuestionSet.CurrentQuestion;
#pragma warning restore IDE0059 // Unnecessary assignment of a value

        txtLastQuery.Text = QuestionSet.CurrentQuestion.PostPrompt;

        if (QuestionSet.IsEntryCorrect(txtAnswer.Text))
        {
            lblStatusResultRight.Text = QuestionSet.countCorrect.ToString();

            txtLastQuery.ForeColor = Color.Blue;

            txtLastAttempt.Text = $"Correct entry: {txtAnswer.Text}";
            txtLastAttempt.ForeColor = Color.Blue;

            if (QuestionSet.CurrentQuestion.HasMultipleAnswers)
            {
                txtLastAnswer.Text = $"Other(s): {QuestionSet.CurrentQuestion.ScrubbedAnswer(txtAnswer.Text)}";
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
                txtAnswer.Text,
                QuestionSet.CurrentQuestion.SetName);
        }

        if (!string.IsNullOrEmpty(QuestionSet.CurrentQuestion.Additional))
        {
            txtAdditional.Text = QuestionSet.CurrentQuestion.FormattedAdditional;
        }

        if (QuestionSet.isFinished)
        {
            txtAnswer.Enabled = false;
            lblStatusResultScore.Text = $"{(Convert.ToInt32(100 * QuestionSet.countCorrect / parentForm.QuestionCount))}%";

            ClearQuestion();
            btnFinish.Select();
        }
        else
        {
            NextQuestion();
        }

        txtAnswer.Clear();
    }

    private void NextQuestion()
    {
        JfQuestion? q = QuestionSet.NextQuestion();
        if (q == null)
        {
            ClearQuestion();
            txtAnswer.Enabled = false;

            return;
        }

        lblQuestionTitle.Text = q.Title;
        lblQuestionQuery.Text = q.Prompt;
        if ((LangFrom == "Hirigana" || LangFrom == "Katakana" || LangFrom == "Romaji") &&
            (LangTo == "Kanji" || LangTo == "English") &&
            !string.IsNullOrEmpty(q.Hint))
        {
            lblQuestionHint.Text = q.Hint;
        }
        else
        {
            lblQuestionHint.Text = string.Empty;
        }

        lblStatusResultAttempted.Text = QuestionSet.questionNumber.ToString();
        int result = QuestionSet.questionNumber > 1
            ? Convert.ToInt32(100 * QuestionSet.countCorrect / (QuestionSet.questionNumber - 1))
            : 100;
        lblStatusResultScore.Text = $"{result}%";
        groupBoxQuestion.Text = $"&Question {QuestionSet.questionNumber} of {QuestionSet.countAttempted}";
    }

    private void PrepareControls(int questionCount)
    {
        lblQuestionHint.Text = string.Empty;
        lblStatusResultTotal.Text = questionCount.ToString();
        txtLastQuery.Text = string.Empty;
        txtLastAttempt.Text = string.Empty;
        txtLastAnswer.Text = string.Empty;
        txtAdditional.Text = string.Empty;
        lblQuestionInstruction.Text = string.Format("Enter the {1} for the presented {0}", LangFrom, LangTo);
        btnFinish.Text = "A&bandon";

        if (LangFrom == "Romaji" || LangFrom == "English")
        {
            txtLastQuery.Font = new Font("Meiryo", 12, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastQuery.Location = new Point(120, 24);
        }
        else
        {
            txtLastQuery.Font = new Font("Meiryo", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastQuery.Location = new Point(120, 16);
        }
    }

    private void SetRandomFont()
    {
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

        lblQuestionQuery.Font = LangFrom switch
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
    }

    #endregion Private Methods

    #region Event Handlers

    private void BtnFinish_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void BtnMistakes_Click(object sender, EventArgs e)
    {
        parentForm.ToggleMistakesForm();
    }

    private void BtnNextQuestion_Click(object sender, EventArgs e)
    {
        EvaluateAnswer();
    }

    private void JFQuestionaireForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        parentForm.Show();
    }

    private void JfQuestionaireForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.SaveWindowState();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        switch (keyData)
        {
            case Keys.Alt | Keys.N:
            case Keys.Control | Keys.N:
            case Keys.Control | Keys.Right:
            case Keys.PageDown:
                EvaluateAnswer();
                break;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void TxtAnswer_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyValue == 13)
        {
            e.SuppressKeyPress = true;
            EvaluateAnswer();
        }
    }

    #endregion Event Handlers
}