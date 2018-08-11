namespace MoodleRegisrtationTool
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.protocol_combobox = new MetroFramework.Controls.MetroComboBox();
            this.token_txt = new MetroFramework.Controls.MetroTextBox();
            this.moodleuri_txt = new MetroFramework.Controls.MetroTextBox();
            this.login_btn = new MetroFramework.Controls.MetroButton();
            this.moodleuri_chkbos = new System.Windows.Forms.CheckBox();
            this.protocol_chkbox = new System.Windows.Forms.CheckBox();
            this.token_chkbox = new System.Windows.Forms.CheckBox();
            this.remember_lbl = new MetroFramework.Controls.MetroLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showHelp_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 67);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(110, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Moodle URI: ";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(23, 98);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(84, 25);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Protocol: ";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(23, 131);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(64, 25);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Token: ";
            // 
            // protocol_combobox
            // 
            this.protocol_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.protocol_combobox.Enabled = false;
            this.protocol_combobox.ItemHeight = 23;
            this.protocol_combobox.Items.AddRange(new object[] {
            "rest",
            "xmlrpc"});
            this.protocol_combobox.Location = new System.Drawing.Point(140, 98);
            this.protocol_combobox.Name = "protocol_combobox";
            this.protocol_combobox.Size = new System.Drawing.Size(476, 29);
            this.protocol_combobox.TabIndex = 3;
            // 
            // token_txt
            // 
            this.token_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.token_txt.Location = new System.Drawing.Point(140, 133);
            this.token_txt.Name = "token_txt";
            this.token_txt.Size = new System.Drawing.Size(476, 23);
            this.token_txt.TabIndex = 4;
            // 
            // moodleuri_txt
            // 
            this.moodleuri_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.moodleuri_txt.Location = new System.Drawing.Point(140, 69);
            this.moodleuri_txt.Name = "moodleuri_txt";
            this.moodleuri_txt.Size = new System.Drawing.Size(476, 23);
            this.moodleuri_txt.TabIndex = 5;
            // 
            // login_btn
            // 
            this.login_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.login_btn.Location = new System.Drawing.Point(23, 162);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(619, 23);
            this.login_btn.TabIndex = 6;
            this.login_btn.Text = "Login";
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // moodleuri_chkbos
            // 
            this.moodleuri_chkbos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.moodleuri_chkbos.AutoSize = true;
            this.moodleuri_chkbos.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moodleuri_chkbos.Location = new System.Drawing.Point(627, 73);
            this.moodleuri_chkbos.Name = "moodleuri_chkbos";
            this.moodleuri_chkbos.Size = new System.Drawing.Size(15, 14);
            this.moodleuri_chkbos.TabIndex = 7;
            this.moodleuri_chkbos.UseVisualStyleBackColor = true;
            // 
            // protocol_chkbox
            // 
            this.protocol_chkbox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.protocol_chkbox.AutoSize = true;
            this.protocol_chkbox.Checked = true;
            this.protocol_chkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.protocol_chkbox.Enabled = false;
            this.protocol_chkbox.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.protocol_chkbox.Location = new System.Drawing.Point(627, 102);
            this.protocol_chkbox.Name = "protocol_chkbox";
            this.protocol_chkbox.Size = new System.Drawing.Size(15, 14);
            this.protocol_chkbox.TabIndex = 8;
            this.protocol_chkbox.UseVisualStyleBackColor = true;
            // 
            // token_chkbox
            // 
            this.token_chkbox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.token_chkbox.AutoSize = true;
            this.token_chkbox.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.token_chkbox.Location = new System.Drawing.Point(627, 134);
            this.token_chkbox.Name = "token_chkbox";
            this.token_chkbox.Size = new System.Drawing.Size(15, 14);
            this.token_chkbox.TabIndex = 9;
            this.token_chkbox.UseVisualStyleBackColor = true;
            // 
            // remember_lbl
            // 
            this.remember_lbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.remember_lbl.AutoSize = true;
            this.remember_lbl.Location = new System.Drawing.Point(570, 47);
            this.remember_lbl.Name = "remember_lbl";
            this.remember_lbl.Size = new System.Drawing.Size(79, 19);
            this.remember_lbl.TabIndex = 10;
            this.remember_lbl.Text = "Remember:";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHelp_toolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(234, 26);
            // 
            // showHelp_toolStripMenuItem
            // 
            this.showHelp_toolStripMenuItem.AccessibleDescription = "dc";
            this.showHelp_toolStripMenuItem.Name = "showHelp_toolStripMenuItem";
            this.showHelp_toolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.showHelp_toolStripMenuItem.Text = "Show Help Button on Title Bar";
            this.showHelp_toolStripMenuItem.Click += new System.EventHandler(this.showHelp_toolStripMenuItem_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 197);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.remember_lbl);
            this.Controls.Add(this.token_chkbox);
            this.Controls.Add(this.protocol_chkbox);
            this.Controls.Add(this.moodleuri_chkbos);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.moodleuri_txt);
            this.Controls.Add(this.token_txt);
            this.Controls.Add(this.protocol_combobox);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginFormcs_Load);
            this.TextChanged += new System.EventHandler(this.LoginForm_TextChanged);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox protocol_combobox;
        private MetroFramework.Controls.MetroTextBox token_txt;
        private MetroFramework.Controls.MetroTextBox moodleuri_txt;
        private MetroFramework.Controls.MetroButton login_btn;
        private System.Windows.Forms.CheckBox moodleuri_chkbos;
        private System.Windows.Forms.CheckBox protocol_chkbox;
        private System.Windows.Forms.CheckBox token_chkbox;
        private MetroFramework.Controls.MetroLabel remember_lbl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showHelp_toolStripMenuItem;
    }
}