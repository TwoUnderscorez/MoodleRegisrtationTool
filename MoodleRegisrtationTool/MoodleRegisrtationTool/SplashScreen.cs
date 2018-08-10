﻿using System;
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
        public Dictionary<string, string> Server;

        public SplashScreen()
        {
            InitializeComponent();
            Server = new Dictionary<string, string>(3);
        }

        private async void SplashScreen_LoadAsync(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            LoginForm loginForm = new LoginForm(this);
            Hide();
            loginForm.Show();
            loginForm.VisibleChanged += LoginForm_VisibleChanged;
        }

        private async void LoginForm_VisibleChanged(object sender, EventArgs e)
        {
            if(!((LoginForm)sender).Visible)
            {
                Show();
                /* Asynchronously initialize the Moodle API */
                MoodleAPI moodleAPI = await Task.Run(() =>
                {
                    return new MoodleAPI();
                });
                /* Asynchronously verify the server information */
                Dictionary<string, object> Response = await moodleAPI.GetUserProfile(Server, 0);
                if (Response.Keys.Contains("status") && (int)Response["status"] == 1)
                {
                    /* If all is good, continie to the MainForm */
                    MainForm mainForm = new MainForm(Server);
                    Hide();
                    ((LoginForm)sender).Close();
                    mainForm.Show();
                    return;
                }
                else if (Response.Keys.Contains("ERRORCODE") && Response.Keys.Contains("MESSAGE"))
                {
                    /* Display error message */
                    ((LoginForm)sender).Text = $"Login - {(string)Response["MESSAGE"]}";
                }
                else
                {
                    /* Display error message */
                    ((LoginForm)sender).Text = "Login - Unknown error";
                }
                /* If the login failed, prompt user to try again */
                await Task.Delay(1000);
                Hide();
                ((LoginForm)sender).Style = MetroFramework.MetroColorStyle.Red;
                ((LoginForm)sender).Visible = true;
            }
        }
    }
}
