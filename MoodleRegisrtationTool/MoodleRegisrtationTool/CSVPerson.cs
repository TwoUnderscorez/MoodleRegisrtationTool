using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Controls;

namespace MoodleRegisrtationTool
{
    class CSVPerson : MetroCheckBox
    {
        string firstName;
        string lastName;
        string userName;
        public CSVPerson(string firstName, string lastName, string userName) : base()
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            Size = new System.Drawing.Size(200, 15);
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} [{userName}]";
        }

        public override string Text { get => ToString(); set => base.Text = value; }
    }
}
