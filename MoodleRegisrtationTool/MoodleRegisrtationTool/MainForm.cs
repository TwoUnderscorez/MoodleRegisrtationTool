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
        string status;
        public MainForm(IDictionary<string, string> Server)
        {
            InitializeComponent();
            moodleAPI = new MoodleAPI(Server);
        }

        /* If status contains somthing, display it in the title bar */
        public override string ToString()
        {
            return $"{base.Text}{((string.IsNullOrEmpty(status)) ? $" - {status}" : "")}";
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
            Enabled = false;
            /* Remove not selected users from the panel */
            for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
                if (!(flowLayoutPanel.Controls[i] as CSVPerson).Checked)
                {
                    flowLayoutPanel.Controls.Remove(flowLayoutPanel.Controls[i]);
                    i--;
                }
            /* Upload users */
            IDictionary<string, object> student;
            int count = 0;
            foreach (CSVPerson CSVstudent in flowLayoutPanel.Controls)
            {
                count++;
                toolStripStatusLabel.Text = $"Uploading {count}/{flowLayoutPanel.Controls.Count} users...";
                toolStripProgressBar.Value = (int)(((float)count / flowLayoutPanel.Controls.Count)*100);
                /* Create the data */
                student = new Dictionary<string, object>(5)
                {
                    { "firstname", CSVstudent.FirstName },
                    { "lastname", CSVstudent.LastName },
                    { "email", CSVstudent.Email },
                    { "username", CSVstudent.UserName },
                    { "createpassword", 1 }
                };
                /* try to uplaod the user */
                try
                {
                    var data = await moodleAPI.UploadUsers(student);
                    /* If successful, display user's ID */
                    CSVstudent.ID = int.Parse(data[0]["id"].ToString()); 
                }
                catch (Exception)
                {
                    /* If not successful, indicate in the GUI */
                    CSVstudent.CheckState = CheckState.Indeterminate;
                    CSVstudent.ID = -1;
                }
            }
            count = 0;
            if(uploadToCohorts_chkbox.Checked)
            {
                /* Create the cohort */
                toolStripStatusLabel.Text = $"Creating cohort named {cohortName_txt.Text}";
                toolStripProgressBar.Value = 50;
                try
                {
                    await moodleAPI.CreateCohort(cohortName_txt.Text);
                }
                catch (Exception)
                {
                    toolStripStatusLabel.Text = $"Ready";
                    toolStripProgressBar.Value = 0;
                    MessageBox.Show("Could not create cohort", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Enabled = true;
                    return;
                }
                /* Add the users to the cohort */
                foreach (CSVPerson item in flowLayoutPanel.Controls.OfType<CSVPerson>())
                {
                    toolStripStatusLabel.Text = $"Adding to cohort {++count}/{flowLayoutPanel.Controls.Count}...";
                    toolStripProgressBar.Value = (int)(((float)count / flowLayoutPanel.Controls.Count) * 100);
                    try
                    {
                        if (item.ID.HasValue && item.ID.Value < 1) throw new Exception("Tried to add a non existing user to a cohort");
                        await moodleAPI.AddMemberToCohort(cohortName_txt.Text, item.ID.Value);
                        item.Cohort = cohortName_txt.Text;
                    }
                    catch (Exception)
                    {
                        item.Cohort = "ERR";
                        item.CheckState = CheckState.Indeterminate;
                    }
                }
            }
            toolStripStatusLabel.Text = $"Done!";
            toolStripProgressBar.Value = 100;
            await Task.Delay(1000);
            toolStripStatusLabel.Text = $"Ready";
            toolStripProgressBar.Value = 0;
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
                        person.ID = int.Parse(item["id"].ToString());
                        return true;
                    }
                }
                return false;
            });
        }
    }
}
