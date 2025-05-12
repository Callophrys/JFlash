namespace jflash
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
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnAbandon = new System.Windows.Forms.Button();
            this.grpbxQuestion = new System.Windows.Forms.GroupBox();
            this.lblQuestionQuery = new System.Windows.Forms.Label();
            this.lblQuestionPrompt = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatusResultTotal = new System.Windows.Forms.Label();
            this.lblStatusResultAttempted = new System.Windows.Forms.Label();
            this.lblStatusResultScore = new System.Windows.Forms.Label();
            this.lblStatusResultWrong = new System.Windows.Forms.Label();
            this.lblStatusResultRight = new System.Windows.Forms.Label();
            this.lblStatusTotal = new System.Windows.Forms.Label();
            this.lblStatusCurrent = new System.Windows.Forms.Label();
            this.lblStatusScore = new System.Windows.Forms.Label();
            this.lblStatusWrong = new System.Windows.Forms.Label();
            this.lblStatusRight = new System.Windows.Forms.Label();
            this.lblLastAns = new System.Windows.Forms.Label();
            this.txtLastAnswer = new System.Windows.Forms.TextBox();
            this.txtLastAttempt = new System.Windows.Forms.TextBox();
            this.txtAdditional = new System.Windows.Forms.TextBox();
            this.txtLastQuery = new System.Windows.Forms.TextBox();
            this.grpbxQuestion.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(133, 314);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(2);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(81, 24);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "&Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnAbandon
            // 
            this.btnAbandon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAbandon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbandon.Location = new System.Drawing.Point(233, 314);
            this.btnAbandon.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbandon.Name = "btnAbandon";
            this.btnAbandon.Size = new System.Drawing.Size(81, 24);
            this.btnAbandon.TabIndex = 2;
            this.btnAbandon.Text = "A&bandon";
            this.btnAbandon.UseVisualStyleBackColor = true;
            this.btnAbandon.Click += new System.EventHandler(this.btnAbandon_Click);
            // 
            // grpbxQuestion
            // 
            this.grpbxQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbxQuestion.Controls.Add(this.lblQuestionQuery);
            this.grpbxQuestion.Controls.Add(this.lblQuestionPrompt);
            this.grpbxQuestion.Controls.Add(this.txtAnswer);
            this.grpbxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxQuestion.Location = new System.Drawing.Point(7, 6);
            this.grpbxQuestion.Margin = new System.Windows.Forms.Padding(2);
            this.grpbxQuestion.Name = "grpbxQuestion";
            this.grpbxQuestion.Padding = new System.Windows.Forms.Padding(2);
            this.grpbxQuestion.Size = new System.Drawing.Size(300, 156);
            this.grpbxQuestion.TabIndex = 0;
            this.grpbxQuestion.TabStop = false;
            this.grpbxQuestion.Text = "Question";
            // 
            // lblQuestionQuery
            // 
            this.lblQuestionQuery.AutoSize = true;
            this.lblQuestionQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionQuery.Location = new System.Drawing.Point(9, 45);
            this.lblQuestionQuery.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuestionQuery.Name = "lblQuestionQuery";
            this.lblQuestionQuery.Size = new System.Drawing.Size(35, 13);
            this.lblQuestionQuery.TabIndex = 2;
            this.lblQuestionQuery.Text = "Query";
            // 
            // lblQuestionPrompt
            // 
            this.lblQuestionPrompt.AutoSize = true;
            this.lblQuestionPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionPrompt.Location = new System.Drawing.Point(9, 23);
            this.lblQuestionPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuestionPrompt.Name = "lblQuestionPrompt";
            this.lblQuestionPrompt.Size = new System.Drawing.Size(40, 13);
            this.lblQuestionPrompt.TabIndex = 1;
            this.lblQuestionPrompt.Text = "Prompt";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(6, 127);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(2);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(288, 20);
            this.txtAnswer.TabIndex = 1;
            this.txtAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnswer_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblStatusResultTotal);
            this.groupBox2.Controls.Add(this.lblStatusResultAttempted);
            this.groupBox2.Controls.Add(this.lblStatusResultScore);
            this.groupBox2.Controls.Add(this.lblStatusResultWrong);
            this.groupBox2.Controls.Add(this.lblStatusResultRight);
            this.groupBox2.Controls.Add(this.lblStatusTotal);
            this.groupBox2.Controls.Add(this.lblStatusCurrent);
            this.groupBox2.Controls.Add(this.lblStatusScore);
            this.groupBox2.Controls.Add(this.lblStatusWrong);
            this.groupBox2.Controls.Add(this.lblStatusRight);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(314, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(123, 156);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // lblStatusResultTotal
            // 
            this.lblStatusResultTotal.AutoSize = true;
            this.lblStatusResultTotal.Location = new System.Drawing.Point(88, 115);
            this.lblStatusResultTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusResultTotal.Name = "lblStatusResultTotal";
            this.lblStatusResultTotal.Size = new System.Drawing.Size(13, 13);
            this.lblStatusResultTotal.TabIndex = 9;
            this.lblStatusResultTotal.Text = "0";
            this.lblStatusResultTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatusResultAttempted
            // 
            this.lblStatusResultAttempted.AutoSize = true;
            this.lblStatusResultAttempted.Location = new System.Drawing.Point(88, 91);
            this.lblStatusResultAttempted.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusResultAttempted.Name = "lblStatusResultAttempted";
            this.lblStatusResultAttempted.Size = new System.Drawing.Size(13, 13);
            this.lblStatusResultAttempted.TabIndex = 8;
            this.lblStatusResultAttempted.Text = "0";
            this.lblStatusResultAttempted.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatusResultScore
            // 
            this.lblStatusResultScore.AutoSize = true;
            this.lblStatusResultScore.Location = new System.Drawing.Point(88, 68);
            this.lblStatusResultScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusResultScore.Name = "lblStatusResultScore";
            this.lblStatusResultScore.Size = new System.Drawing.Size(13, 13);
            this.lblStatusResultScore.TabIndex = 7;
            this.lblStatusResultScore.Text = "0";
            this.lblStatusResultScore.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatusResultWrong
            // 
            this.lblStatusResultWrong.AutoSize = true;
            this.lblStatusResultWrong.Location = new System.Drawing.Point(88, 45);
            this.lblStatusResultWrong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusResultWrong.Name = "lblStatusResultWrong";
            this.lblStatusResultWrong.Size = new System.Drawing.Size(13, 13);
            this.lblStatusResultWrong.TabIndex = 6;
            this.lblStatusResultWrong.Text = "0";
            this.lblStatusResultWrong.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatusResultRight
            // 
            this.lblStatusResultRight.AutoSize = true;
            this.lblStatusResultRight.Location = new System.Drawing.Point(88, 24);
            this.lblStatusResultRight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusResultRight.Name = "lblStatusResultRight";
            this.lblStatusResultRight.Size = new System.Drawing.Size(13, 13);
            this.lblStatusResultRight.TabIndex = 5;
            this.lblStatusResultRight.Text = "0";
            this.lblStatusResultRight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStatusTotal
            // 
            this.lblStatusTotal.AutoSize = true;
            this.lblStatusTotal.Location = new System.Drawing.Point(10, 114);
            this.lblStatusTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusTotal.Name = "lblStatusTotal";
            this.lblStatusTotal.Size = new System.Drawing.Size(34, 13);
            this.lblStatusTotal.TabIndex = 4;
            this.lblStatusTotal.Text = "Total:";
            // 
            // lblStatusCurrent
            // 
            this.lblStatusCurrent.AutoSize = true;
            this.lblStatusCurrent.Location = new System.Drawing.Point(10, 90);
            this.lblStatusCurrent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusCurrent.Name = "lblStatusCurrent";
            this.lblStatusCurrent.Size = new System.Drawing.Size(44, 13);
            this.lblStatusCurrent.TabIndex = 3;
            this.lblStatusCurrent.Text = "Current:";
            // 
            // lblStatusScore
            // 
            this.lblStatusScore.AutoSize = true;
            this.lblStatusScore.Location = new System.Drawing.Point(10, 67);
            this.lblStatusScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusScore.Name = "lblStatusScore";
            this.lblStatusScore.Size = new System.Drawing.Size(38, 13);
            this.lblStatusScore.TabIndex = 2;
            this.lblStatusScore.Text = "Score:";
            // 
            // lblStatusWrong
            // 
            this.lblStatusWrong.AutoSize = true;
            this.lblStatusWrong.Location = new System.Drawing.Point(10, 44);
            this.lblStatusWrong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusWrong.Name = "lblStatusWrong";
            this.lblStatusWrong.Size = new System.Drawing.Size(42, 13);
            this.lblStatusWrong.TabIndex = 1;
            this.lblStatusWrong.Text = "Wrong:";
            // 
            // lblStatusRight
            // 
            this.lblStatusRight.AutoSize = true;
            this.lblStatusRight.Location = new System.Drawing.Point(10, 24);
            this.lblStatusRight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusRight.Name = "lblStatusRight";
            this.lblStatusRight.Size = new System.Drawing.Size(35, 13);
            this.lblStatusRight.TabIndex = 0;
            this.lblStatusRight.Text = "Right:";
            // 
            // lblLastAns
            // 
            this.lblLastAns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLastAns.AutoSize = true;
            this.lblLastAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastAns.Location = new System.Drawing.Point(4, 165);
            this.lblLastAns.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastAns.Name = "lblLastAns";
            this.lblLastAns.Size = new System.Drawing.Size(112, 20);
            this.lblLastAns.TabIndex = 6;
            this.lblLastAns.Text = "Last Question:";
            // 
            // txtLastAnswer
            // 
            this.txtLastAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLastAnswer.BackColor = System.Drawing.SystemColors.Control;
            this.txtLastAnswer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastAnswer.ForeColor = System.Drawing.Color.Firebrick;
            this.txtLastAnswer.Location = new System.Drawing.Point(18, 219);
            this.txtLastAnswer.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastAnswer.Multiline = true;
            this.txtLastAnswer.Name = "txtLastAnswer";
            this.txtLastAnswer.Size = new System.Drawing.Size(419, 40);
            this.txtLastAnswer.TabIndex = 7;
            this.txtLastAnswer.Text = "Corrected\r\nor other answers";
            // 
            // txtLastAttempt
            // 
            this.txtLastAttempt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLastAttempt.BackColor = System.Drawing.SystemColors.Control;
            this.txtLastAttempt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastAttempt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastAttempt.ForeColor = System.Drawing.Color.Blue;
            this.txtLastAttempt.Location = new System.Drawing.Point(18, 192);
            this.txtLastAttempt.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastAttempt.Name = "txtLastAttempt";
            this.txtLastAttempt.Size = new System.Drawing.Size(419, 19);
            this.txtLastAttempt.TabIndex = 8;
            this.txtLastAttempt.Text = "Wrong";
            // 
            // txtAdditional
            // 
            this.txtAdditional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAdditional.BackColor = System.Drawing.SystemColors.Control;
            this.txtAdditional.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdditional.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditional.ForeColor = System.Drawing.Color.Green;
            this.txtAdditional.Location = new System.Drawing.Point(16, 266);
            this.txtAdditional.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdditional.Multiline = true;
            this.txtAdditional.Name = "txtAdditional";
            this.txtAdditional.Size = new System.Drawing.Size(419, 40);
            this.txtAdditional.TabIndex = 9;
            this.txtAdditional.Text = "Additional";
            // 
            // txtLastQuery
            // 
            this.txtLastQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLastQuery.BackColor = System.Drawing.SystemColors.Control;
            this.txtLastQuery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastQuery.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLastQuery.Location = new System.Drawing.Point(120, 166);
            this.txtLastQuery.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastQuery.Name = "txtLastQuery";
            this.txtLastQuery.Size = new System.Drawing.Size(315, 19);
            this.txtLastQuery.TabIndex = 10;
            this.txtLastQuery.Text = "Wrong";
            // 
            // JFQuestionaireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 349);
            this.Controls.Add(this.txtLastQuery);
            this.Controls.Add(this.txtAdditional);
            this.Controls.Add(this.txtLastAttempt);
            this.Controls.Add(this.txtLastAnswer);
            this.Controls.Add(this.lblLastAns);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpbxQuestion);
            this.Controls.Add(this.btnAbandon);
            this.Controls.Add(this.btnFinish);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(464, 388);
            this.Name = "JFQuestionaireForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Japanese Flash Cards - Questionaire";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JFQuestionaireForm_FormClosed);
            this.grpbxQuestion.ResumeLayout(false);
            this.grpbxQuestion.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnAbandon;
        private System.Windows.Forms.GroupBox grpbxQuestion;
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
    }
}