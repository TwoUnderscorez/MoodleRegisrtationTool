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
        public LoginForm()
        {
            InitializeComponent();
            protocol_combobox.Text = "rest";
        }

        private void LoginFormcs_Load(object sender, EventArgs e)
        {
            
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
    }
}
