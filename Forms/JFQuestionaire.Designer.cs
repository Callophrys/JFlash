namespace JFlash.Forms
{
    partial class JfQuestionaireForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JfQuestionaireForm));
            btnFinish = new Button();
            btnMistakes = new Button();
            btnNextQuestion = new Button();
            groupBoxQuestion = new GroupBox();
            groupResult = new GroupBox();
            groupStatus = new GroupBox();
            lblLastAns = new Label();
            lblQuestionHint = new Label();
            lblQuestionInstruction = new Label();
            lblQuestionQuery = new Label();
            lblQuestionTitle = new Label();
            lblStatusCurrent = new Label();
            lblStatusResultAttempted = new Label();
            lblStatusResultRight = new Label();
            lblStatusResultScore = new Label();
            lblStatusResultTotal = new Label();
            lblStatusResultWrong = new Label();
            lblStatusRight = new Label();
            lblStatusScore = new Label();
            lblStatusTotal = new Label();
            lblStatusWrong = new Label();
            txtAdditional = new TextBox();
            txtAnswer = new TextBox();
            txtLastAnswer = new TextBox();
            txtLastAttempt = new TextBox();
            txtLastQuery = new TextBox();
            groupBoxQuestion.SuspendLayout();
            groupStatus.SuspendLayout();
            groupResult.SuspendLayout();
            SuspendLayout();
            // 
            // btnFinish
            // 
            btnFinish.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFinish.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFinish.Location = new Point(5, 440);
            btnFinish.Margin = new Padding(2);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(90, 28);
            btnFinish.TabIndex = 1;
            btnFinish.Text = "&Finish";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += BtnFinish_Click;
            // 
            // groupBoxQuestion
            // 
            groupBoxQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxQuestion.Controls.Add(btnNextQuestion);
            groupBoxQuestion.Controls.Add(lblQuestionHint);
            groupBoxQuestion.Controls.Add(lblQuestionTitle);
            groupBoxQuestion.Controls.Add(lblQuestionQuery);
            groupBoxQuestion.Controls.Add(lblQuestionInstruction);
            groupBoxQuestion.Controls.Add(txtAnswer);
            groupBoxQuestion.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxQuestion.Location = new Point(8, 7);
            groupBoxQuestion.Margin = new Padding(2);
            groupBoxQuestion.Name = "groupBoxQuestion";
            groupBoxQuestion.Padding = new Padding(2);
            groupBoxQuestion.Size = new Size(350, 224);
            groupBoxQuestion.TabIndex = 0;
            groupBoxQuestion.TabStop = false;
            groupBoxQuestion.Text = "&Question";
            // 
            // btnNextQuestion
            // 
            btnNextQuestion.Location = new Point(323, 194);
            btnNextQuestion.Name = "btnNextQuestion";
            btnNextQuestion.Size = new Size(20, 23);
            btnNextQuestion.TabIndex = 6;
            btnNextQuestion.Text = ">";
            btnNextQuestion.UseVisualStyleBackColor = true;
            btnNextQuestion.Click += BtnNextQuestion_Click;
            // 
            // lblQuestionHint
            // 
            lblQuestionHint.AutoSize = true;
            lblQuestionHint.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionHint.Location = new Point(10, 174);
            lblQuestionHint.Margin = new Padding(2);
            lblQuestionHint.MaximumSize = new Size(335, 48);
            lblQuestionHint.Name = "lblQuestionHint";
            lblQuestionHint.Size = new Size(26, 13);
            lblQuestionHint.TabIndex = 4;
            lblQuestionHint.Text = "Hint";
            // 
            // lblQuestionTitle
            // 
            lblQuestionTitle.AutoSize = true;
            lblQuestionTitle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionTitle.Location = new Point(10, 32);
            lblQuestionTitle.Margin = new Padding(2);
            lblQuestionTitle.Name = "lblQuestionTitle";
            lblQuestionTitle.Size = new Size(27, 13);
            lblQuestionTitle.TabIndex = 1;
            lblQuestionTitle.Text = "Title";
            // 
            // lblQuestionQuery
            // 
            lblQuestionQuery.AutoSize = true;
            lblQuestionQuery.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionQuery.Location = new Point(10, 88);
            lblQuestionQuery.Margin = new Padding(2);
            lblQuestionQuery.MaximumSize = new Size(335, 48);
            lblQuestionQuery.Name = "lblQuestionQuery";
            lblQuestionQuery.Size = new Size(35, 13);
            lblQuestionQuery.TabIndex = 3;
            lblQuestionQuery.Text = "Query";
            // 
            // lblQuestionInstruction
            // 
            lblQuestionInstruction.AutoSize = true;
            lblQuestionInstruction.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionInstruction.Location = new Point(10, 60);
            lblQuestionInstruction.Margin = new Padding(2);
            lblQuestionInstruction.Name = "lblQuestionInstruction";
            lblQuestionInstruction.Size = new Size(40, 13);
            lblQuestionInstruction.TabIndex = 2;
            lblQuestionInstruction.Text = "Prompt";
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(7, 195);
            txtAnswer.Margin = new Padding(2);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(320, 20);
            txtAnswer.TabIndex = 5;
            txtAnswer.KeyDown += TxtAnswer_KeyDown;
            // 
            // groupStatus
            // 
            groupStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupStatus.Controls.Add(lblStatusResultTotal);
            groupStatus.Controls.Add(lblStatusResultAttempted);
            groupStatus.Controls.Add(lblStatusResultScore);
            groupStatus.Controls.Add(lblStatusResultWrong);
            groupStatus.Controls.Add(lblStatusResultRight);
            groupStatus.Controls.Add(lblStatusTotal);
            groupStatus.Controls.Add(lblStatusCurrent);
            groupStatus.Controls.Add(lblStatusScore);
            groupStatus.Controls.Add(lblStatusWrong);
            groupStatus.Controls.Add(lblStatusRight);
            groupStatus.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupStatus.Location = new Point(366, 7);
            groupStatus.Margin = new Padding(2);
            groupStatus.Name = "groupStatus";
            groupStatus.Padding = new Padding(2);
            groupStatus.Size = new Size(144, 224);
            groupStatus.TabIndex = 3;
            groupStatus.TabStop = false;
            groupStatus.Text = "Status";
            // 
            // lblStatusResultTotal
            // 
            lblStatusResultTotal.AutoSize = true;
            lblStatusResultTotal.Location = new Point(103, 133);
            lblStatusResultTotal.Margin = new Padding(2, 0, 2, 0);
            lblStatusResultTotal.Name = "lblStatusResultTotal";
            lblStatusResultTotal.Size = new Size(13, 13);
            lblStatusResultTotal.TabIndex = 9;
            lblStatusResultTotal.Text = "0";
            lblStatusResultTotal.TextAlign = ContentAlignment.TopRight;
            // 
            // lblStatusResultAttempted
            // 
            lblStatusResultAttempted.AutoSize = true;
            lblStatusResultAttempted.Location = new Point(103, 105);
            lblStatusResultAttempted.Margin = new Padding(2, 0, 2, 0);
            lblStatusResultAttempted.Name = "lblStatusResultAttempted";
            lblStatusResultAttempted.Size = new Size(13, 13);
            lblStatusResultAttempted.TabIndex = 8;
            lblStatusResultAttempted.Text = "0";
            lblStatusResultAttempted.TextAlign = ContentAlignment.TopRight;
            // 
            // lblStatusResultScore
            // 
            lblStatusResultScore.AutoSize = true;
            lblStatusResultScore.Location = new Point(103, 78);
            lblStatusResultScore.Margin = new Padding(2, 0, 2, 0);
            lblStatusResultScore.Name = "lblStatusResultScore";
            lblStatusResultScore.Size = new Size(13, 13);
            lblStatusResultScore.TabIndex = 7;
            lblStatusResultScore.Text = "0";
            lblStatusResultScore.TextAlign = ContentAlignment.TopRight;
            // 
            // lblStatusResultWrong
            // 
            lblStatusResultWrong.AutoSize = true;
            lblStatusResultWrong.Location = new Point(103, 52);
            lblStatusResultWrong.Margin = new Padding(2, 0, 2, 0);
            lblStatusResultWrong.Name = "lblStatusResultWrong";
            lblStatusResultWrong.Size = new Size(13, 13);
            lblStatusResultWrong.TabIndex = 6;
            lblStatusResultWrong.Text = "0";
            lblStatusResultWrong.TextAlign = ContentAlignment.TopRight;
            // 
            // lblStatusResultRight
            // 
            lblStatusResultRight.AutoSize = true;
            lblStatusResultRight.Location = new Point(103, 28);
            lblStatusResultRight.Margin = new Padding(2, 0, 2, 0);
            lblStatusResultRight.Name = "lblStatusResultRight";
            lblStatusResultRight.Size = new Size(13, 13);
            lblStatusResultRight.TabIndex = 5;
            lblStatusResultRight.Text = "0";
            lblStatusResultRight.TextAlign = ContentAlignment.TopRight;
            // 
            // lblStatusTotal
            // 
            lblStatusTotal.AutoSize = true;
            lblStatusTotal.Location = new Point(12, 132);
            lblStatusTotal.Margin = new Padding(2, 0, 2, 0);
            lblStatusTotal.Name = "lblStatusTotal";
            lblStatusTotal.Size = new Size(34, 13);
            lblStatusTotal.TabIndex = 4;
            lblStatusTotal.Text = "Total:";
            // 
            // lblStatusCurrent
            // 
            lblStatusCurrent.AutoSize = true;
            lblStatusCurrent.Location = new Point(12, 104);
            lblStatusCurrent.Margin = new Padding(2, 0, 2, 0);
            lblStatusCurrent.Name = "lblStatusCurrent";
            lblStatusCurrent.Size = new Size(44, 13);
            lblStatusCurrent.TabIndex = 3;
            lblStatusCurrent.Text = "Current:";
            // 
            // lblStatusScore
            // 
            lblStatusScore.AutoSize = true;
            lblStatusScore.Location = new Point(12, 77);
            lblStatusScore.Margin = new Padding(2, 0, 2, 0);
            lblStatusScore.Name = "lblStatusScore";
            lblStatusScore.Size = new Size(38, 13);
            lblStatusScore.TabIndex = 2;
            lblStatusScore.Text = "Score:";
            // 
            // lblStatusWrong
            // 
            lblStatusWrong.AutoSize = true;
            lblStatusWrong.Location = new Point(12, 51);
            lblStatusWrong.Margin = new Padding(2, 0, 2, 0);
            lblStatusWrong.Name = "lblStatusWrong";
            lblStatusWrong.Size = new Size(42, 13);
            lblStatusWrong.TabIndex = 1;
            lblStatusWrong.Text = "Wrong:";
            // 
            // lblStatusRight
            // 
            lblStatusRight.AutoSize = true;
            lblStatusRight.Location = new Point(12, 28);
            lblStatusRight.Margin = new Padding(2, 0, 2, 0);
            lblStatusRight.Name = "lblStatusRight";
            lblStatusRight.Size = new Size(35, 13);
            lblStatusRight.TabIndex = 0;
            lblStatusRight.Text = "Right:";
            // 
            // btnMistakes
            // 
            btnMistakes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnMistakes.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMistakes.Location = new Point(423, 440);
            btnMistakes.Margin = new Padding(2);
            btnMistakes.Name = "btnMistakes";
            btnMistakes.Size = new Size(90, 28);
            btnMistakes.TabIndex = 2;
            btnMistakes.Text = "&Mistakes";
            btnMistakes.UseVisualStyleBackColor = true;
            btnMistakes.Click += BtnMistakes_Click;
            // 
            // groupResult
            // 
            groupResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupResult.Controls.Add(txtLastQuery);
            groupResult.Controls.Add(txtAdditional);
            groupResult.Controls.Add(txtLastAttempt);
            groupResult.Controls.Add(txtLastAnswer);
            groupResult.Controls.Add(lblLastAns);
            groupResult.Location = new Point(8, 231);
            groupResult.Name = "groupResult";
            groupResult.Size = new Size(503, 204);
            groupResult.TabIndex = 12;
            groupResult.TabStop = false;
            groupResult.Text = "Result";
            // 
            // txtLastQuery
            // 
            txtLastQuery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtLastQuery.BackColor = SystemColors.Control;
            txtLastQuery.BorderStyle = BorderStyle.None;
            txtLastQuery.Font = new Font("Meiryo", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastQuery.ForeColor = SystemColors.WindowText;
            txtLastQuery.Location = new Point(120, 16);
            txtLastQuery.Margin = new Padding(2);
            txtLastQuery.Name = "txtLastQuery";
            txtLastQuery.ReadOnly = true;
            txtLastQuery.Size = new Size(380, 40);
            txtLastQuery.TabIndex = 12;
            txtLastQuery.TabStop = false;
            txtLastQuery.Text = "Wrong";
            // 
            // txtAdditional
            // 
            txtAdditional.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtAdditional.BackColor = SystemColors.Control;
            txtAdditional.BorderStyle = BorderStyle.None;
            txtAdditional.Font = new Font("Meiryo", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdditional.ForeColor = Color.Green;
            txtAdditional.Location = new Point(37, 149);
            txtAdditional.Margin = new Padding(2);
            txtAdditional.Multiline = true;
            txtAdditional.Name = "txtAdditional";
            txtAdditional.ReadOnly = true;
            txtAdditional.Size = new Size(465, 51);
            txtAdditional.TabIndex = 15;
            txtAdditional.TabStop = false;
            txtAdditional.Text = "Additional";
            // 
            // txtLastAttempt
            // 
            txtLastAttempt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtLastAttempt.BackColor = SystemColors.Control;
            txtLastAttempt.BorderStyle = BorderStyle.None;
            txtLastAttempt.Font = new Font("Meiryo", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastAttempt.ForeColor = Color.Blue;
            txtLastAttempt.Location = new Point(37, 62);
            txtLastAttempt.Margin = new Padding(2);
            txtLastAttempt.Name = "txtLastAttempt";
            txtLastAttempt.ReadOnly = true;
            txtLastAttempt.Size = new Size(465, 24);
            txtLastAttempt.TabIndex = 13;
            txtLastAttempt.TabStop = false;
            txtLastAttempt.Text = "Wrong";
            // 
            // txtLastAnswer
            // 
            txtLastAnswer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtLastAnswer.BackColor = SystemColors.Control;
            txtLastAnswer.BorderStyle = BorderStyle.None;
            txtLastAnswer.Font = new Font("Meiryo", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastAnswer.ForeColor = Color.Firebrick;
            txtLastAnswer.Location = new Point(37, 90);
            txtLastAnswer.Margin = new Padding(2);
            txtLastAnswer.Multiline = true;
            txtLastAnswer.Name = "txtLastAnswer";
            txtLastAnswer.ReadOnly = true;
            txtLastAnswer.Size = new Size(465, 55);
            txtLastAnswer.TabIndex = 14;
            txtLastAnswer.TabStop = false;
            txtLastAnswer.Text = "Corrected\r\nor other answers";
            // 
            // lblLastAns
            // 
            lblLastAns.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblLastAns.AutoSize = true;
            lblLastAns.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastAns.Location = new Point(4, 24);
            lblLastAns.Margin = new Padding(2, 0, 2, 0);
            lblLastAns.Name = "lblLastAns";
            lblLastAns.Size = new Size(112, 20);
            lblLastAns.TabIndex = 11;
            lblLastAns.Text = "Last Question:";
            // 
            // JfQuestionaireForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 473);
            Controls.Add(groupResult);
            Controls.Add(btnMistakes);
            Controls.Add(groupStatus);
            Controls.Add(groupBoxQuestion);
            Controls.Add(btnFinish);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MinimumSize = new Size(539, 464);
            Name = "JfQuestionaireForm";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.Manual;
            Text = "Japanese Flash Cards - Questionaire";
            FormClosing += JfQuestionaireForm_FormClosing;
            FormClosed += JFQuestionaireForm_FormClosed;
            groupBoxQuestion.ResumeLayout(false);
            groupBoxQuestion.PerformLayout();
            groupStatus.ResumeLayout(false);
            groupStatus.PerformLayout();
            groupResult.ResumeLayout(false);
            groupResult.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxQuestion;
        private GroupBox groupResult;
        private GroupBox groupStatus;
        private Button btnFinish;
        private Button btnMistakes;
        private Button btnNextQuestion;
        private Label lblLastAns;
        private Label lblQuestionHint;
        private Label lblQuestionInstruction;
        private Label lblQuestionQuery;
        private Label lblQuestionTitle;
        private Label lblStatusCurrent;
        private Label lblStatusResultAttempted;
        private Label lblStatusResultRight;
        private Label lblStatusResultScore;
        private Label lblStatusResultTotal;
        private Label lblStatusResultWrong;
        private Label lblStatusRight;
        private Label lblStatusScore;
        private Label lblStatusTotal;
        private Label lblStatusWrong;
        private TextBox txtAdditional;
        private TextBox txtAnswer;
        private TextBox txtLastAnswer;
        private TextBox txtLastAttempt;
        private TextBox txtLastQuery;
    }
}