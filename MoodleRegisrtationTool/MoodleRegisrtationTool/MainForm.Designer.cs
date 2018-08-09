namespace MoodleRegisrtationTool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.cohortName_txt = new MetroFramework.Controls.MetroTextBox();
            this.uploadToCohorts_chkbox = new MetroFramework.Controls.MetroCheckBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.browse_btn = new MetroFramework.Controls.MetroButton();
            this.path_txt = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(760, 370);
            this.metroTabControl1.TabIndex = 0;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.AutoScroll = true;
            this.metroTabPage1.Controls.Add(this.cohortName_txt);
            this.metroTabPage1.Controls.Add(this.uploadToCohorts_chkbox);
            this.metroTabPage1.Controls.Add(this.metroButton2);
            this.metroTabPage1.Controls.Add(this.flowLayoutPanel);
            this.metroTabPage1.Controls.Add(this.browse_btn);
            this.metroTabPage1.Controls.Add(this.path_txt);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.HorizontalScrollbar = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(752, 331);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Upload Users";
            this.metroTabPage1.VerticalScrollbar = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // cohortName_txt
            // 
            this.cohortName_txt.Location = new System.Drawing.Point(203, 274);
            this.cohortName_txt.Name = "cohortName_txt";
            this.cohortName_txt.Size = new System.Drawing.Size(221, 23);
            this.cohortName_txt.TabIndex = 8;
            // 
            // uploadToCohorts_chkbox
            // 
            this.uploadToCohorts_chkbox.AutoSize = true;
            this.uploadToCohorts_chkbox.Location = new System.Drawing.Point(3, 276);
            this.uploadToCohorts_chkbox.Name = "uploadToCohorts_chkbox";
            this.uploadToCohorts_chkbox.Size = new System.Drawing.Size(194, 15);
            this.uploadToCohorts_chkbox.TabIndex = 7;
            this.uploadToCohorts_chkbox.Text = "Add students to a ohort named: ";
            this.uploadToCohorts_chkbox.UseVisualStyleBackColor = true;
            this.uploadToCohorts_chkbox.CheckedChanged += new System.EventHandler(this.uploadToCohorts_chkbox_CheckedChanged);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(648, 274);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(101, 23);
            this.metroButton2.TabIndex = 6;
            this.metroButton2.Text = "Upload selected";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 31);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(746, 237);
            this.flowLayoutPanel.TabIndex = 5;
            // 
            // browse_btn
            // 
            this.browse_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browse_btn.Location = new System.Drawing.Point(678, 3);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(75, 23);
            this.browse_btn.TabIndex = 4;
            this.browse_btn.Text = "Browse";
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // path_txt
            // 
            this.path_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.path_txt.Location = new System.Drawing.Point(74, 3);
            this.path_txt.Name = "path_txt";
            this.path_txt.ReadOnly = true;
            this.path_txt.Size = new System.Drawing.Size(598, 23);
            this.path_txt.TabIndex = 3;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(4, 5);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(64, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "CSV File: ";
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.textBox2);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(752, 331);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "License";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(752, 331);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.textBox1);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(752, 331);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Third Party Notices";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(752, 331);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Moodle Registration Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.TextBox textBox2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private System.Windows.Forms.TextBox textBox1;
        private MetroFramework.Controls.MetroButton browse_btn;
        private MetroFramework.Controls.MetroTextBox path_txt;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroTextBox cohortName_txt;
        private MetroFramework.Controls.MetroCheckBox uploadToCohorts_chkbox;
    }
}