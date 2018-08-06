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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.protocol_combobox = new MetroFramework.Controls.MetroComboBox();
            this.token_txt = new MetroFramework.Controls.MetroTextBox();
            this.moodleuri_txt = new MetroFramework.Controls.MetroTextBox();
            this.login_btn = new MetroFramework.Controls.MetroButton();
            this.moodleuri_chkbos = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showHelp_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(110, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Moodle URI: ";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(23, 91);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(84, 25);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Protocol: ";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(23, 124);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(64, 25);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Token: ";
            // 
            // protocol_combobox
            // 
            this.protocol_combobox.ItemHeight = 23;
            this.protocol_combobox.Items.AddRange(new object[] {
            "rest",
            "xmlrpc"});
            this.protocol_combobox.Location = new System.Drawing.Point(140, 91);
            this.protocol_combobox.Name = "protocol_combobox";
            this.protocol_combobox.Size = new System.Drawing.Size(282, 29);
            this.protocol_combobox.TabIndex = 3;
            // 
            // token_txt
            // 
            this.token_txt.Location = new System.Drawing.Point(140, 126);
            this.token_txt.Name = "token_txt";
            this.token_txt.Size = new System.Drawing.Size(282, 23);
            this.token_txt.TabIndex = 4;
            // 
            // moodleuri_txt
            // 
            this.moodleuri_txt.Location = new System.Drawing.Point(140, 62);
            this.moodleuri_txt.Name = "moodleuri_txt";
            this.moodleuri_txt.Size = new System.Drawing.Size(282, 23);
            this.moodleuri_txt.TabIndex = 5;
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(23, 155);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(425, 23);
            this.login_btn.TabIndex = 6;
            this.login_btn.Text = "Login";
            // 
            // moodleuri_chkbos
            // 
            this.moodleuri_chkbos.AutoSize = true;
            this.moodleuri_chkbos.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moodleuri_chkbos.Location = new System.Drawing.Point(433, 68);
            this.moodleuri_chkbos.Name = "moodleuri_chkbos";
            this.moodleuri_chkbos.Size = new System.Drawing.Size(15, 14);
            this.moodleuri_chkbos.TabIndex = 7;
            this.moodleuri_chkbos.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(433, 97);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(433, 129);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(376, 40);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(79, 19);
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "Remember:";
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
            this.ClientSize = new System.Drawing.Size(460, 197);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.moodleuri_chkbos);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.moodleuri_txt);
            this.Controls.Add(this.token_txt);
            this.Controls.Add(this.protocol_combobox);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginFormcs_Load);
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showHelp_toolStripMenuItem;
    }
}