using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace MoodleRegisrtationTool
{
    public partial class LoginForm : MetroForm
    {
        SplashScreen SplashScreen;
        public LoginForm(SplashScreen splashScreen)
        {
            InitializeComponent();
            protocol_combobox.Text = "rest";
            SplashScreen = splashScreen;
        }

        private void LoginFormcs_Load(object sender, EventArgs e)
        {
            moodleuri_txt.Text = Properties.Settings.Default.ServerURI;
            protocol_combobox.Text = Properties.Settings.Default.ServerProtocol;
            token_txt.Text = Properties.Settings.Default.ServerToken;
            if (Properties.Settings.Default.ServerURI.Length > 1)
                moodleuri_chkbos.Checked = true;
            if (Properties.Settings.Default.ServerProtocol.Length > 1)
                protocol_chkbox.Checked = true;
            if (Properties.Settings.Default.ServerToken.Length > 1)
                token_chkbox.Checked = true;
        }

        private void showHelp_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(showHelp_toolStripMenuItem.Checked)
            {
                FormBorderStyle = FormBorderStyle.None;
                showHelp_toolStripMenuItem.Checked = false;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.FixedDialog;
                showHelp_toolStripMenuItem.Checked = true;
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            saveSettings();

            SplashScreen.Server.Clear();
            SplashScreen.Server.Add("protocol", protocol_combobox.Text);
            SplashScreen.Server.Add("uri", moodleuri_txt.Text);
            SplashScreen.Server.Add("token", token_txt.Text);

            Visible = false;
        }

        private void saveSettings()
        {
            if (moodleuri_chkbos.Checked)
                Properties.Settings.Default.ServerURI = moodleuri_txt.Text;
            else
                Properties.Settings.Default.ServerURI = string.Empty;
            if (protocol_chkbox.Checked)
                Properties.Settings.Default.ServerProtocol = protocol_chkbox.Text;
            else
                Properties.Settings.Default.ServerProtocol = string.Empty;
            if (token_chkbox.Checked)
                Properties.Settings.Default.ServerToken = token_txt.Text;
            else
                Properties.Settings.Default.ServerToken = string.Empty;
            Properties.Settings.Default.Save();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                Environment.Exit(0);
        }
    }
}
