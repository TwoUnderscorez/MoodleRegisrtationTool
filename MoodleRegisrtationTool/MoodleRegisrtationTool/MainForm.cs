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
using Csv;

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
            uploadToCohorts_chkbox_CheckedChanged(sender, e);
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
                    List<Dictionary<string, string>> Students = ParseCSVFile(fbd.FileName);

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
        /// <returns>List of dictionaries</returns>
        private List<Dictionary<string, string>> ParseCSVFile(string path)
        {
            List<Dictionary<string, string>> students = new List<Dictionary<string, string>>();
            Dictionary<string, string> student;
            foreach (var line in CsvReader.ReadFromStream(File.OpenRead(path)))
            {
                student = new Dictionary<string, string>(3);
                student.Add("firstname", line["firstname"]);
                student.Add("lastname", line["lastname"]);
                student.Add("email", line["email"]);
                student.Add("username", line["username"]);
                students.Add(student);
            }
            return students;
        }

        private void uploadToCohorts_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            /* Make sure that the cohort name textbpx is disabled 
             * if the 'make a cohort' checkbox is not checked, 
             * also clear the textbox
             */
            cohortName_txt.Enabled = uploadToCohorts_chkbox.Checked;
            if (!uploadToCohorts_chkbox.Checked) cohortName_txt.Text = string.Empty;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void upload_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
