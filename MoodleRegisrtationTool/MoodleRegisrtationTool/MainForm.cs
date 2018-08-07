using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace MoodleRegisrtationTool
{
    public partial class MainForm : MetroForm
    {
        Dictionary<string, string> Server;
        public MainForm(IDictionary<string, string> Server)
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                fbd.Multiselect = false;
                fbd.ValidateNames = true;
                fbd.Filter = "CSV files (*.csv)|*.csv";
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    path_txt.Text = fbd.FileName;
                    List<Dictionary<string, string>> Students = new List<Dictionary<string, string>>();
                    Students.Add(new Dictionary<string, string>(4)
                    {
                        ["firstname"] = "Lev",
                        ["lastname"] = "Gorts",
                        ["username"] = "levg",
                        ["email"] = "leogorts@gmail.com"
                    });
                    Students.Add(new Dictionary<string, string>(4)
                    {
                        ["firstname"] = "Ron",
                        ["lastname"] = "Yutkin",
                        ["username"] = "rony",
                        ["email"] = "ron.yutkin@gmail.com"
                    });
                    Students.Add(new Dictionary<string, string>(4)
                    {
                        ["firstname"] = "Yuval",
                        ["lastname"] = "Stein",
                        ["username"] = "yuvals",
                        ["email"] = "yuvalsteinb@gmail.com"
                    });

                    CSVPerson csvPerson;
                    flowLayoutPanel.Controls.Clear();
                    foreach (Dictionary<string,string> item in Students)
                    {
                        csvPerson = new CSVPerson(item);
                        flowLayoutPanel.Controls.Add(csvPerson);
                        csvPerson.Checked = true;
                    }
                }
            }
        }

        /// <summary>
        /// Opens the CSV file directed by the file dialog and parses it.
        /// </summary>
        /// <param name="path">The path of the CSV file</param>
        /// <returns>[LIST OF DICTIONARIES OR YOU CAN MAKE A CLASS WITH THE APPROPRIATE PROPERTIES] </returns>
        private List<object> ParseCSVFile(string path)
        {
            /* Do your magic here :) */
            return null;
        }
    }
}
