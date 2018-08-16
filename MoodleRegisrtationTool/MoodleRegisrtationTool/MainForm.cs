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
        MoodleAPI moodleAPI;
        public MainForm(IDictionary<string, string> Server)
        {
            InitializeComponent();
            moodleAPI = new MoodleAPI(Server);
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
                student = new Dictionary<string, string>(4)
                {
                    { "firstname", line["firstname"] },
                    { "lastname", line["lastname"] },
                    { "email", line["email"] },
                    { "username", line["username"] }
                };
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

        private async void upload_btn_ClickAsync(object sender, EventArgs e)
        {
            for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
                if (!(flowLayoutPanel.Controls[i] as CSVPerson).Checked)
                {
                    flowLayoutPanel.Controls.Remove(flowLayoutPanel.Controls[i]);
                    i--;
                }

            IList<IDictionary<string, object>> students = new List<IDictionary<string, object>>();
            IDictionary<string, object> student;
            foreach (CSVPerson CSVstudent in flowLayoutPanel.Controls)
            {
                student = new Dictionary<string, object>(5)
                {
                    { "firstname", CSVstudent.FirstName },
                    { "lastname", CSVstudent.LastName },
                    { "email", CSVstudent.Email },
                    { "username", CSVstudent.UserName },
                    { "createpassword", 1 }
                };
                students.Add(student);
            }
            Enabled = false;
            var data = await moodleAPI.UploadUsers(students);
            foreach (CSVPerson person in flowLayoutPanel.Controls.OfType<CSVPerson>())
                if (!(await SearchUploadedUsers(person, data)))
                    person.CheckState = CheckState.Indeterminate;
            Enabled = true;
        }

        private async Task<bool> SearchUploadedUsers(CSVPerson person, IList<IDictionary<string, object>> data)
        {
            return await Task.Run(() =>
            {
                foreach (var item in data)
                {
                    if (person.UserName == item["username"].ToString())
                    {
                        return true;
                    }
                }
                return false;
            });
        }
    }
}
