namespace JFlash
{
    partial class JFQuestionaireForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JFQuestionaireForm));
            btnFinish = new Button();
            btnAbandon = new Button();
            groupBoxQuestion = new GroupBox();
            lblQuestionTitle = new Label();
            lblQuestionQuery = new Label();
            lblQuestionPrompt = new Label();
            txtAnswer = new TextBox();
            groupBox2 = new GroupBox();
            lblStatusResultTotal = new Label();
            lblStatusResultAttempted = new Label();
            lblStatusResultScore = new Label();
            lblStatusResultWrong = new Label();
            lblStatusResultRight = new Label();
            lblStatusTotal = new Label();
            lblStatusCurrent = new Label();
            lblStatusScore = new Label();
            lblStatusWrong = new Label();
            lblStatusRight = new Label();
            lblLastAns = new Label();
            txtLastAnswer = new TextBox();
            txtLastAttempt = new TextBox();
            txtAdditional = new TextBox();
            txtLastQuery = new TextBox();
            groupBoxQuestion.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnFinish
            // 
            btnFinish.Anchor = AnchorStyles.Bottom;
            btnFinish.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFinish.Location = new Point(155, 362);
            btnFinish.Margin = new Padding(2);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(94, 28);
            btnFinish.TabIndex = 1;
            btnFinish.Text = "&Finish";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += BtnFinish_Click;
            // 
            // btnAbandon
            // 
            btnAbandon.Anchor = AnchorStyles.Bottom;
            btnAbandon.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAbandon.Location = new Point(272, 362);
            btnAbandon.Margin = new Padding(2);
            btnAbandon.Name = "btnAbandon";
            btnAbandon.Size = new Size(94, 28);
            btnAbandon.TabIndex = 2;
            btnAbandon.Text = "A&bandon";
            btnAbandon.UseVisualStyleBackColor = true;
            btnAbandon.Click += BtnAbandon_Click;
            // 
            // groupBoxQuestion
            // 
            groupBoxQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxQuestion.Controls.Add(lblQuestionTitle);
            groupBoxQuestion.Controls.Add(lblQuestionQuery);
            groupBoxQuestion.Controls.Add(lblQuestionPrompt);
            groupBoxQuestion.Controls.Add(txtAnswer);
            groupBoxQuestion.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxQuestion.Location = new Point(8, 7);
            groupBoxQuestion.Margin = new Padding(2);
            groupBoxQuestion.Name = "groupBoxQuestion";
            groupBoxQuestion.Padding = new Padding(2);
            groupBoxQuestion.Size = new Size(350, 180);
            groupBoxQuestion.TabIndex = 0;
            groupBoxQuestion.TabStop = false;
            groupBoxQuestion.Text = "Question";
            // 
            // lblQuestionTitle
            // 
            lblQuestionTitle.AutoSize = true;
            lblQuestionTitle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionTitle.Location = new Point(10, 32);
            lblQuestionTitle.Margin = new Padding(2);
            lblQuestionTitle.Name = "lblQuestionTitle";
            lblQuestionTitle.Size = new Size(27, 13);
            lblQuestionTitle.TabIndex = 3;
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
            lblQuestionQuery.TabIndex = 2;
            lblQuestionQuery.Text = "Query";
            // 
            // lblQuestionPrompt
            // 
            lblQuestionPrompt.AutoSize = true;
            lblQuestionPrompt.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionPrompt.Location = new Point(10, 60);
            lblQuestionPrompt.Margin = new Padding(2);
            lblQuestionPrompt.Name = "lblQuestionPrompt";
            lblQuestionPrompt.Size = new Size(40, 13);
            lblQuestionPrompt.TabIndex = 1;
            lblQuestionPrompt.Text = "Prompt";
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(7, 147);
            txtAnswer.Margin = new Padding(2);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(335, 20);
            txtAnswer.TabIndex = 1;
            txtAnswer.KeyDown += TxtAnswer_KeyDown;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(lblStatusResultTotal);
            groupBox2.Controls.Add(lblStatusResultAttempted);
            groupBox2.Controls.Add(lblStatusResultScore);
            groupBox2.Controls.Add(lblStatusResultWrong);
            groupBox2.Controls.Add(lblStatusResultRight);
            groupBox2.Controls.Add(lblStatusTotal);
            groupBox2.Controls.Add(lblStatusCurrent);
            groupBox2.Controls.Add(lblStatusScore);
            groupBox2.Controls.Add(lblStatusWrong);
            groupBox2.Controls.Add(lblStatusRight);
            groupBox2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(366, 7);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(144, 180);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Status";
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
            // lblLastAns
            // 
            lblLastAns.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblLastAns.AutoSize = true;
            lblLastAns.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastAns.Location = new Point(5, 190);
            lblLastAns.Margin = new Padding(2, 0, 2, 0);
            lblLastAns.Name = "lblLastAns";
            lblLastAns.Size = new Size(112, 20);
            lblLastAns.TabIndex = 6;
            lblLastAns.Text = "Last Question:";
            // 
            // txtLastAnswer
            // 
            txtLastAnswer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtLastAnswer.BackColor = SystemColors.Control;
            txtLastAnswer.BorderStyle = BorderStyle.None;
            txtLastAnswer.Font = new Font("Meiryo", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastAnswer.ForeColor = Color.Firebrick;
            txtLastAnswer.Location = new Point(21, 252);
            txtLastAnswer.Margin = new Padding(2);
            txtLastAnswer.Multiline = true;
            txtLastAnswer.Name = "txtLastAnswer";
            txtLastAnswer.Size = new Size(489, 53);
            txtLastAnswer.TabIndex = 7;
            txtLastAnswer.Text = "Corrected\r\nor other answers";
            // 
            // txtLastAttempt
            // 
            txtLastAttempt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtLastAttempt.BackColor = SystemColors.Control;
            txtLastAttempt.BorderStyle = BorderStyle.None;
            txtLastAttempt.Font = new Font("Meiryo", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastAttempt.ForeColor = Color.Blue;
            txtLastAttempt.Location = new Point(21, 222);
            txtLastAttempt.Margin = new Padding(2);
            txtLastAttempt.Name = "txtLastAttempt";
            txtLastAttempt.Size = new Size(489, 24);
            txtLastAttempt.TabIndex = 8;
            txtLastAttempt.Text = "Wrong";
            // 
            // txtAdditional
            // 
            txtAdditional.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtAdditional.BackColor = SystemColors.Control;
            txtAdditional.BorderStyle = BorderStyle.None;
            txtAdditional.Font = new Font("Meiryo", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdditional.ForeColor = Color.Green;
            txtAdditional.Location = new Point(19, 309);
            txtAdditional.Margin = new Padding(2);
            txtAdditional.Multiline = true;
            txtAdditional.Name = "txtAdditional";
            txtAdditional.Size = new Size(489, 51);
            txtAdditional.TabIndex = 9;
            txtAdditional.Text = "Additional";
            // 
            // txtLastQuery
            // 
            txtLastQuery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtLastQuery.BackColor = SystemColors.Control;
            txtLastQuery.BorderStyle = BorderStyle.None;
            txtLastQuery.Font = new Font("Meiryo", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtLastQuery.ForeColor = SystemColors.WindowText;
            txtLastQuery.Location = new Point(140, 192);
            txtLastQuery.Margin = new Padding(2);
            txtLastQuery.Name = "txtLastQuery";
            txtLastQuery.Size = new Size(368, 24);
            txtLastQuery.TabIndex = 10;
            txtLastQuery.Text = "Wrong";
            // 
            // JFQuestionaireForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 403);
            Controls.Add(txtLastQuery);
            Controls.Add(txtAdditional);
            Controls.Add(txtLastAttempt);
            Controls.Add(txtLastAnswer);
            Controls.Add(lblLastAns);
            Controls.Add(groupBox2);
            Controls.Add(groupBoxQuestion);
            Controls.Add(btnAbandon);
            Controls.Add(btnFinish);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MinimumSize = new Size(539, 442);
            Name = "JFQuestionaireForm";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.Manual;
            Text = "Japanese Flash Cards - Questionaire";
            FormClosed += JFQuestionaireForm_FormClosed;
            groupBoxQuestion.ResumeLayout(false);
            groupBoxQuestion.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnAbandon;
        private System.Windows.Forms.GroupBox groupBoxQuestion;
        private System.Windows.Forms.Label lblQuestionQuery;
        private System.Windows.Forms.Label lblQuestionPrompt;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatusResultTotal;
        private System.Windows.Forms.Label lblStatusResultAttempted;
        private System.Windows.Forms.Label lblStatusResultScore;
        private System.Windows.Forms.Label lblStatusResultWrong;
        private System.Windows.Forms.Label lblStatusResultRight;
        private System.Windows.Forms.Label lblStatusTotal;
        private System.Windows.Forms.Label lblStatusCurrent;
        private System.Windows.Forms.Label lblStatusScore;
        private System.Windows.Forms.Label lblStatusWrong;
        private System.Windows.Forms.Label lblStatusRight;
        private System.Windows.Forms.Label lblLastAns;
        private System.Windows.Forms.TextBox txtLastAnswer;
        private System.Windows.Forms.TextBox txtLastAttempt;
        private System.Windows.Forms.TextBox txtAdditional;
        private System.Windows.Forms.TextBox txtLastQuery;
        private Label lblQuestionTitle;
    }
}