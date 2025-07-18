﻿using JFlash.Components;

namespace JFlash.Forms;

partial class JfMistakes
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
        ListViewGroup listViewGroup1 = new ListViewGroup("Mistakes", HorizontalAlignment.Left);
        ListViewGroup listViewGroup2 = new ListViewGroup("Mistakes", HorizontalAlignment.Left);
        ListViewGroup listViewGroup3 = new ListViewGroup("Mistakes", HorizontalAlignment.Left);
        ListViewGroup listViewGroup4 = new ListViewGroup("Results", HorizontalAlignment.Left);
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JfMistakes));
        groupBox1 = new GroupBox();
        jfListViewMistakes = new JfListView();
        btnClear = new Button();
        btnClose = new Button();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBox1.Controls.Add(jfListViewMistakes);
        groupBox1.Controls.Add(btnClear);
        groupBox1.Location = new Point(11, 8);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(453, 339);
        groupBox1.TabIndex = 2;
        groupBox1.TabStop = false;
        // 
        // jfListViewMistakes
        // 
        jfListViewMistakes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        listViewGroup1.Header = "Mistakes";
        listViewGroup1.Name = "mistakes";
        listViewGroup1.Subtitle = "Kanji to English";
        listViewGroup2.Header = "Mistakes";
        listViewGroup2.Name = "mistakes";
        listViewGroup2.Subtitle = "Kanji to English";
        listViewGroup3.Header = "Mistakes";
        listViewGroup3.Name = "mistakes";
        listViewGroup3.Subtitle = "Kanji to English";
        listViewGroup4.Header = "Results";
        listViewGroup4.Name = "listViewGroup1";
        listViewGroup4.Subtitle = "Kanji to English";
        jfListViewMistakes.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3, listViewGroup4 });
        jfListViewMistakes.Location = new Point(6, 22);
        jfListViewMistakes.Name = "jfListViewMistakes";
        jfListViewMistakes.Size = new Size(441, 274);
        jfListViewMistakes.TabIndex = 0;
        jfListViewMistakes.UseCompatibleStateImageBehavior = false;
        jfListViewMistakes.View = View.Details;
        // 
        // btnClear
        // 
        btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnClear.Location = new Point(357, 302);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(90, 28);
        btnClear.TabIndex = 1;
        btnClear.Text = "C&lear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += BtnClear_Click;
        // 
        // btnClose
        // 
        btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnClose.Location = new Point(12, 353);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(90, 28);
        btnClose.TabIndex = 1;
        btnClose.Text = "&Close";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += BtnClose_Click;
        // 
        // JfMistakes
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(485, 388);
        Controls.Add(btnClose);
        Controls.Add(groupBox1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "JfMistakes";
        SizeGripStyle = SizeGripStyle.Show;
        Text = "JFMistakes";
        FormClosing += JFMistakes_FormClosing;
        VisibleChanged += JfMistakes_VisibleChanged;
        groupBox1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox1;
    private Button btnClose;
    private JfListView jfListViewMistakes;
    private Button btnClear;
}