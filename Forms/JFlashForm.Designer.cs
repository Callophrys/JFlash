namespace JFlash.Forms
{
    partial class JFlashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JFlashForm));
            label1 = new Label();
            pnlQuestionFiles = new Panel();
            groupBox2 = new GroupBox();
            nsQuestionLimit = new NumericUpDown();
            rbLimitQuestions = new RadioButton();
            rbAllQuestions = new RadioButton();
            btnExit = new Button();
            btnGo = new Button();
            chkSelectAll = new CheckBox();
            cmbFrom = new ComboBox();
            cmbTo = new ComboBox();
            lblFrom = new Label();
            lblTo = new Label();
            lblFormats = new Label();
            btnQuestionPath = new Button();
            btnSwapFormats = new Button();
            btnMistakes = new Button();
            nsSubsetSize = new NumericUpDown();
            label2 = new Label();
            chkExpandAll = new CheckBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nsQuestionLimit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nsSubsetSize).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 7);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(146, 18);
            label1.TabIndex = 0;
            label1.Text = "&Available question set(s)";
            // 
            // pnlQuestionFiles
            // 
            pnlQuestionFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlQuestionFiles.Location = new Point(8, 22);
            pnlQuestionFiles.Margin = new Padding(4, 3, 4, 3);
            pnlQuestionFiles.Name = "pnlQuestionFiles";
            pnlQuestionFiles.Size = new Size(330, 287);
            pnlQuestionFiles.TabIndex = 1;
            pnlQuestionFiles.SizeChanged += PnlQuestionFiles_SizeChanged;
            pnlQuestionFiles.ControlAdded += PnlQuestionFiles_ControlAdded;
            pnlQuestionFiles.ControlRemoved += PnlQuestionFiles_ControlRemoved;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(nsQuestionLimit);
            groupBox2.Controls.Add(rbLimitQuestions);
            groupBox2.Controls.Add(rbAllQuestions);
            groupBox2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(12, 397);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(327, 81);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "&Options";
            // 
            // nsQuestionLimit
            // 
            nsQuestionLimit.Location = new Point(233, 45);
            nsQuestionLimit.Margin = new Padding(2);
            nsQuestionLimit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nsQuestionLimit.Name = "nsQuestionLimit";
            nsQuestionLimit.Size = new Size(52, 20);
            nsQuestionLimit.TabIndex = 4;
            nsQuestionLimit.Value = new decimal(new int[] { 4, 0, 0, 0 });
            nsQuestionLimit.ValueChanged += NsQuestionLimit_ValueChanged;
            nsQuestionLimit.Enter += NsQuestionLimit_Enter;
            // 
            // rbLimitQuestions
            // 
            rbLimitQuestions.AutoSize = true;
            rbLimitQuestions.Location = new Point(19, 45);
            rbLimitQuestions.Margin = new Padding(2);
            rbLimitQuestions.Name = "rbLimitQuestions";
            rbLimitQuestions.Size = new Size(208, 17);
            rbLimitQuestions.TabIndex = 3;
            rbLimitQuestions.Text = "Limit to ran&domized questions of count:";
            rbLimitQuestions.UseVisualStyleBackColor = true;
            rbLimitQuestions.CheckedChanged += RbLimitQuestions_CheckedChanged;
            // 
            // rbAllQuestions
            // 
            rbAllQuestions.AutoSize = true;
            rbAllQuestions.Checked = true;
            rbAllQuestions.Location = new Point(19, 20);
            rbAllQuestions.Margin = new Padding(2);
            rbAllQuestions.Name = "rbAllQuestions";
            rbAllQuestions.Size = new Size(186, 17);
            rbAllQuestions.TabIndex = 2;
            rbAllQuestions.TabStop = true;
            rbAllQuestions.Text = "Test &all questions in selected sets:";
            rbAllQuestions.UseVisualStyleBackColor = true;
            rbAllQuestions.CheckedChanged += RbAllQuestions_CheckedChanged;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExit.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(106, 485);
            btnExit.Margin = new Padding(2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(90, 28);
            btnExit.TabIndex = 19;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // btnGo
            // 
            btnGo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGo.Enabled = false;
            btnGo.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGo.Location = new Point(10, 485);
            btnGo.Margin = new Padding(2);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(90, 28);
            btnGo.TabIndex = 18;
            btnGo.Text = "&Go!";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += BtnGo_Click;
            // 
            // chkSelectAll
            // 
            chkSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkSelectAll.AutoSize = true;
            chkSelectAll.Location = new Point(10, 318);
            chkSelectAll.Margin = new Padding(4, 3, 4, 3);
            chkSelectAll.Name = "chkSelectAll";
            chkSelectAll.Size = new Size(123, 19);
            chkSelectAll.TabIndex = 7;
            chkSelectAll.Text = "&Select/Deselect All";
            chkSelectAll.UseVisualStyleBackColor = true;
            // 
            // cmbFrom
            // 
            cmbFrom.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmbFrom.FormattingEnabled = true;
            cmbFrom.Location = new Point(197, 342);
            cmbFrom.Margin = new Padding(4, 3, 4, 3);
            cmbFrom.Name = "cmbFrom";
            cmbFrom.Size = new Size(100, 23);
            cmbFrom.TabIndex = 13;
            cmbFrom.SelectedIndexChanged += CmbFrom_SelectedIndexChanged;
            cmbFrom.KeyDown += CmbFrom_KeyDown;
            // 
            // cmbTo
            // 
            cmbTo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmbTo.FormattingEnabled = true;
            cmbTo.ItemHeight = 15;
            cmbTo.Location = new Point(197, 370);
            cmbTo.Margin = new Padding(4, 3, 4, 3);
            cmbTo.Name = "cmbTo";
            cmbTo.Size = new Size(100, 23);
            cmbTo.TabIndex = 15;
            cmbTo.SelectedIndexChanged += CmbTo_SelectedIndexChanged;
            cmbTo.KeyDown += CmbTo_KeyDown;
            // 
            // lblFrom
            // 
            lblFrom.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(153, 345);
            lblFrom.Margin = new Padding(4, 0, 4, 0);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(38, 15);
            lblFrom.TabIndex = 12;
            lblFrom.Text = "&From:";
            lblFrom.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTo
            // 
            lblTo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTo.AutoSize = true;
            lblTo.Location = new Point(164, 375);
            lblTo.Margin = new Padding(4, 0, 4, 0);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(23, 15);
            lblTo.TabIndex = 14;
            lblTo.Text = "&To:";
            lblTo.TextAlign = ContentAlignment.TopRight;
            // 
            // lblFormats
            // 
            lblFormats.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblFormats.AutoSize = true;
            lblFormats.Location = new Point(206, 318);
            lblFormats.Margin = new Padding(4, 0, 4, 0);
            lblFormats.Name = "lblFormats";
            lblFormats.Size = new Size(101, 15);
            lblFormats.TabIndex = 11;
            lblFormats.Text = "Question Formats";
            lblFormats.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnQuestionPath
            // 
            btnQuestionPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnQuestionPath.Location = new Point(45, 369);
            btnQuestionPath.Margin = new Padding(4, 3, 4, 3);
            btnQuestionPath.Name = "btnQuestionPath";
            btnQuestionPath.Size = new Size(96, 24);
            btnQuestionPath.TabIndex = 10;
            btnQuestionPath.Text = "&Question Files";
            btnQuestionPath.UseVisualStyleBackColor = true;
            btnQuestionPath.Click += BtnQuestionPath_Click;
            // 
            // btnSwapFormats
            // 
            btnSwapFormats.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSwapFormats.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSwapFormats.Location = new Point(301, 354);
            btnSwapFormats.Margin = new Padding(2);
            btnSwapFormats.Name = "btnSwapFormats";
            btnSwapFormats.Size = new Size(30, 28);
            btnSwapFormats.TabIndex = 16;
            btnSwapFormats.Text = "⇅";
            btnSwapFormats.UseVisualStyleBackColor = true;
            btnSwapFormats.Click += BtnSwapFormats_Click;
            // 
            // btnMistakes
            // 
            btnMistakes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnMistakes.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMistakes.Location = new Point(250, 485);
            btnMistakes.Margin = new Padding(2);
            btnMistakes.Name = "btnMistakes";
            btnMistakes.Size = new Size(90, 28);
            btnMistakes.TabIndex = 20;
            btnMistakes.Text = "&Mistakes";
            btnMistakes.UseVisualStyleBackColor = true;
            btnMistakes.Click += BtnMistakes_Click;
            // 
            // nsSubsetSize
            // 
            nsSubsetSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            nsSubsetSize.Location = new Point(87, 342);
            nsSubsetSize.Margin = new Padding(2);
            nsSubsetSize.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nsSubsetSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nsSubsetSize.Name = "nsSubsetSize";
            nsSubsetSize.Size = new Size(52, 23);
            nsSubsetSize.TabIndex = 9;
            nsSubsetSize.Value = new decimal(new int[] { 7, 0, 0, 0 });
            nsSubsetSize.ValueChanged += NsSubsetSize_ValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(15, 345);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 8;
            label2.Text = "Subset Si&ze:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // chkExpandAll
            // 
            chkExpandAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkExpandAll.Appearance = Appearance.Button;
            chkExpandAll.AutoSize = true;
            chkExpandAll.CheckAlign = ContentAlignment.MiddleCenter;
            chkExpandAll.Checked = true;
            chkExpandAll.CheckState = CheckState.Checked;
            chkExpandAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkExpandAll.Location = new Point(311, 1);
            chkExpandAll.Name = "chkExpandAll";
            chkExpandAll.Size = new Size(27, 25);
            chkExpandAll.TabIndex = 21;
            chkExpandAll.Text = "▼";
            chkExpandAll.UseVisualStyleBackColor = false;
            chkExpandAll.CheckedChanged += ChkExpandAll_CheckedChanged;
            // 
            // JFlashForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 519);
            Controls.Add(chkExpandAll);
            Controls.Add(label2);
            Controls.Add(nsSubsetSize);
            Controls.Add(btnMistakes);
            Controls.Add(btnSwapFormats);
            Controls.Add(btnQuestionPath);
            Controls.Add(lblFormats);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Controls.Add(cmbTo);
            Controls.Add(cmbFrom);
            Controls.Add(chkSelectAll);
            Controls.Add(label1);
            Controls.Add(pnlQuestionFiles);
            Controls.Add(groupBox2);
            Controls.Add(btnGo);
            Controls.Add(btnExit);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "JFlashForm";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Japanese Flash Cards - Select Questions";
            FormClosing += JFlashForm_FormClosing;
            Shown += JFlashForm_Shown;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nsQuestionLimit).EndInit();
            ((System.ComponentModel.ISupportInitialize)nsSubsetSize).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbLimitQuestions;
        private System.Windows.Forms.RadioButton rbAllQuestions;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.NumericUpDown nsQuestionLimit;
        private System.Windows.Forms.Panel pnlQuestionFiles;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFormats;
        private System.Windows.Forms.Button btnQuestionPath;
        private Button btnSwapFormats;
        private Button btnMistakes;
        private NumericUpDown nsSubsetSize;
        private Label label2;
        private CheckBox chkExpandAll;
    }
}

