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
            this.btnFinish.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(478, 177);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(108, 30);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "&Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnAbandon
            // 
            this.btnAbandon.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbandon.Location = new System.Drawing.Point(478, 223);
            this.btnAbandon.Name = "btnAbandon";
            this.btnAbandon.Size = new System.Drawing.Size(108, 30);
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
            this.grpbxQuestion.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxQuestion.Location = new System.Drawing.Point(9, 8);
            this.grpbxQuestion.Name = "grpbxQuestion";
            this.grpbxQuestion.Size = new System.Drawing.Size(400, 159);
            this.grpbxQuestion.TabIndex = 0;
            this.grpbxQuestion.TabStop = false;
            this.grpbxQuestion.Text = "Question";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(12, 53);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(46, 16);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "label1";
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.Location = new System.Drawing.Point(12, 28);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(46, 16);
            this.lblPrompt.TabIndex = 1;
            this.lblPrompt.Text = "label1";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(8, 126);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(383, 22);
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
            this.groupBox2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(419, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 159);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(118, 132);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(16, 16);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAttempted
            // 
            this.lblAttempted.AutoSize = true;
            this.lblAttempted.Location = new System.Drawing.Point(118, 105);
            this.lblAttempted.Name = "lblAttempted";
            this.lblAttempted.Size = new System.Drawing.Size(16, 16);
            this.lblAttempted.TabIndex = 8;
            this.lblAttempted.Text = "0";
            this.lblAttempted.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(118, 79);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(16, 16);
            this.lblScore.TabIndex = 7;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblWrong
            // 
            this.lblWrong.AutoSize = true;
            this.lblWrong.Location = new System.Drawing.Point(118, 53);
            this.lblWrong.Name = "lblWrong";
            this.lblWrong.Size = new System.Drawing.Size(16, 16);
            this.lblWrong.TabIndex = 6;
            this.lblWrong.Text = "0";
            this.lblWrong.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(118, 29);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(16, 16);
            this.lblRight.TabIndex = 5;
            this.lblRight.Text = "0";
            this.lblRight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Current:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Score:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wrong:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Right:";
            // 
            // lblLastAns
            // 
            this.lblLastAns.AutoSize = true;
            this.lblLastAns.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastAns.Location = new System.Drawing.Point(6, 177);
            this.lblLastAns.Name = "lblLastAns";
            this.lblLastAns.Size = new System.Drawing.Size(59, 16);
            this.lblLastAns.TabIndex = 6;
            this.lblLastAns.Text = "LastAns";
            // 
            // txtLastResponseB
            // 
            this.txtLastResponseB.BackColor = System.Drawing.SystemColors.Control;
            this.txtLastResponseB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastResponseB.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastResponseB.ForeColor = System.Drawing.Color.Red;
            this.txtLastResponseB.Location = new System.Drawing.Point(24, 223);
            this.txtLastResponseB.Multiline = true;
            this.txtLastResponseB.Name = "txtLastResponseB";
            this.txtLastResponseB.Size = new System.Drawing.Size(441, 37);
            this.txtLastResponseB.TabIndex = 7;
            this.txtLastResponseB.Text = "Corrected\r\nor other correct";
            // 
            // txtLastResponseA
            // 
            this.txtLastResponseA.BackColor = System.Drawing.SystemColors.Control;
            this.txtLastResponseA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastResponseA.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastResponseA.ForeColor = System.Drawing.Color.Blue;
            this.txtLastResponseA.Location = new System.Drawing.Point(24, 202);
            this.txtLastResponseA.Name = "txtLastResponseA";
            this.txtLastResponseA.Size = new System.Drawing.Size(441, 15);
            this.txtLastResponseA.TabIndex = 8;
            this.txtLastResponseA.Text = "Wrong";
            // 
            // JFQuestionaireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 267);
            this.Controls.Add(this.txtLastResponseA);
            this.Controls.Add(this.txtLastResponseB);
            this.Controls.Add(this.lblLastAns);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpbxQuestion);
            this.Controls.Add(this.btnAbandon);
            this.Controls.Add(this.btnFinish);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JFQuestionaireForm";
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