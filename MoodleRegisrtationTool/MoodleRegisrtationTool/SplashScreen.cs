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

namespace MoodleRegisrtationTool
{
    public partial class SplashScreen : MetroForm
    {
        public string Server;
        public string Protocol;
        public string Token;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private async Task SplashScreen_LoadAsync(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            LoginForm loginForm = new LoginForm(this);
            Hide();
            loginForm.Show();
        }
    }
}
