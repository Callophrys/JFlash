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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblAttempted = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblWrong = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLastAns = new System.Windows.Forms.Label();
            this.txtLastResponseB = new System.Windows.Forms.TextBox();
            this.txtLastResponseA = new System.Windows.Forms.TextBox();
            this.grpbxQuestion.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(358, 144);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(81, 24);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "&Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnAbandon
            // 
            this.btnAbandon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbandon.Location = new System.Drawing.Point(358, 181);
            this.btnAbandon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAbandon.Name = "btnAbandon";
            this.btnAbandon.Size = new System.Drawing.Size(81, 24);
            this.btnAbandon.TabIndex = 2;
            this.btnAbandon.Text = "A&bandon";
            this.btnAbandon.UseVisualStyleBackColor = true;
            this.btnAbandon.Click += new System.EventHandler(this.btnAbandon_Click);
            // 
            // grpbxQuestion
            // 
            this.grpbxQuestion.Controls.Add(this.lblQuestion);
            this.grpbxQuestion.Controls.Add(this.lblPrompt);
            this.grpbxQuestion.Controls.Add(this.txtAnswer);
            this.grpbxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxQuestion.Location = new System.Drawing.Point(7, 6);
            this.grpbxQuestion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpbxQuestion.Name = "grpbxQuestion";
            this.grpbxQuestion.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpbxQuestion.Size = new System.Drawing.Size(300, 129);
            this.grpbxQuestion.TabIndex = 0;
            this.grpbxQuestion.TabStop = false;
            this.grpbxQuestion.Text = "Question";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(9, 43);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(35, 13);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "label1";
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.Location = new System.Drawing.Point(9, 23);
            this.lblPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(35, 13);
            this.lblPrompt.TabIndex = 1;
            this.lblPrompt.Text = "label1";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(6, 102);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(288, 20);
            this.txtAnswer.TabIndex = 1;
            this.txtAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnswer_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.lblAttempted);
            this.groupBox2.Controls.Add(this.lblScore);
            this.groupBox2.Controls.Add(this.lblWrong);
            this.groupBox2.Controls.Add(this.lblRight);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(314, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(129, 129);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(88, 107);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAttempted
            // 
            this.lblAttempted.AutoSize = true;
            this.lblAttempted.Location = new System.Drawing.Point(88, 85);
            this.lblAttempted.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAttempted.Name = "lblAttempted";
            this.lblAttempted.Size = new System.Drawing.Size(13, 13);
            this.lblAttempted.TabIndex = 8;
            this.lblAttempted.Text = "0";
            this.lblAttempted.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(88, 64);
            this.lblScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(13, 13);
            this.lblScore.TabIndex = 7;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblWrong
            // 
            this.lblWrong.AutoSize = true;
            this.lblWrong.Location = new System.Drawing.Point(88, 43);
            this.lblWrong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWrong.Name = "lblWrong";
            this.lblWrong.Size = new System.Drawing.Size(13, 13);
            this.lblWrong.TabIndex = 6;
            this.lblWrong.Text = "0";
            this.lblWrong.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(88, 24);
            this.lblRight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(13, 13);
            this.lblRight.TabIndex = 5;
            this.lblRight.Text = "0";
            this.lblRight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Current:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Score:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wrong:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Right:";
            // 
            // lblLastAns
            // 
            this.lblLastAns.AutoSize = true;
            this.lblLastAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastAns.Location = new System.Drawing.Point(4, 144);
            this.lblLastAns.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastAns.Name = "lblLastAns";
            this.lblLastAns.Size = new System.Drawing.Size(45, 13);
            this.lblLastAns.TabIndex = 6;
            this.lblLastAns.Text = "LastAns";
            // 
            // txtLastResponseB
            // 
            this.txtLastResponseB.BackColor = System.Drawing.SystemColors.Control;
            this.txtLastResponseB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastResponseB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastResponseB.ForeColor = System.Drawing.Color.Red;
            this.txtLastResponseB.Location = new System.Drawing.Point(18, 181);
            this.txtLastResponseB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLastResponseB.Multiline = true;
            this.txtLastResponseB.Name = "txtLastResponseB";
            this.txtLastResponseB.Size = new System.Drawing.Size(331, 30);
            this.txtLastResponseB.TabIndex = 7;
            this.txtLastResponseB.Text = "Corrected\r\nor other correct";
            // 
            // txtLastResponseA
            // 
            this.txtLastResponseA.BackColor = System.Drawing.SystemColors.Control;
            this.txtLastResponseA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastResponseA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastResponseA.ForeColor = System.Drawing.Color.Blue;
            this.txtLastResponseA.Location = new System.Drawing.Point(18, 164);
            this.txtLastResponseA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLastResponseA.Name = "txtLastResponseA";
            this.txtLastResponseA.Size = new System.Drawing.Size(331, 13);
            this.txtLastResponseA.TabIndex = 8;
            this.txtLastResponseA.Text = "Wrong";
            // 
            // JFQuestionaireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 217);
            this.Controls.Add(this.txtLastResponseA);
            this.Controls.Add(this.txtLastResponseB);
            this.Controls.Add(this.lblLastAns);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpbxQuestion);
            this.Controls.Add(this.btnAbandon);
            this.Controls.Add(this.btnFinish);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "JFQuestionaireForm";
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
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblAttempted;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblWrong;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLastAns;
        private System.Windows.Forms.TextBox txtLastResponseB;
        private System.Windows.Forms.TextBox txtLastResponseA;
    }
}