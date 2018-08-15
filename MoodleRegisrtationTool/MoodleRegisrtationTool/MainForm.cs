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
        /// <returns>[LIST OF DICTIONARIES OR YOU CAN MAKE A CLASS WITH THE APPROPRIATE PROPERTIES] </returns>
        private List<Dictionary<string, string>> ParseCSVFile(string path)
        {
            /* Do your magic here :) */
            throw new NotImplementedException("McYuval!!!");
        }

        private void uploadToCohorts_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            cohortName_txt.Enabled = uploadToCohorts_chkbox.Checked;
            if (!uploadToCohorts_chkbox.Checked) cohortName_txt.Text = string.Empty;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
