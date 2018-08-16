using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace MoodleRegisrtationTool
{
    class CSVPerson : MetroCheckBox
    {
        string firstName;
        string lastName;
        string userName;
        string email;
        public CSVPerson(string firstName, string lastName, string userName, string email) : base()
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.email = email;
            Size = new System.Drawing.Size(200, 15);
            ToolTipSetup();
        }

        public CSVPerson(Dictionary<string, string> CSVkeyValuePairs) : base()
        {
            firstName = CSVkeyValuePairs["firstname"];
            lastName = CSVkeyValuePairs["lastname"];
            userName = CSVkeyValuePairs["username"];
            email = CSVkeyValuePairs["email"];
            Size = new System.Drawing.Size(200, 15);
            ToolTipSetup();
        }

        public override string Text { get => ToString(); set => base.Text = value; }

        public override string ToString()
        {
            return $"{firstName} {lastName} [{userName}]";
        }

        private void ToolTipSetup()
        {
            ToolTip myToolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 100,
                ReshowDelay = 500,
                ShowAlways = true
            };

            // Set up the ToolTip text to show the email.
            myToolTip.SetToolTip(this, email);
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
        }
    }
}
