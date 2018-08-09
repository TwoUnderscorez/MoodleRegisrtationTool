using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoodleRegisrtationTool
{
    class MoodleAPI
    {
        #region Private Variables
        ScriptRuntime python;
        dynamic moodle;
        #endregion

        #region Constructor
        public MoodleAPI()
        {
            python = Python.CreateRuntime();
            moodle = python.ImportModule("moodle");
        }
        #endregion

        #region Methods

        public Dictionary<string, string> getDictionaryFromXML(string xmlString)
        {
            XDocument doc = XDocument.Parse(xmlString);
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

            foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
            {
                int keyInt = 0;
                string keyName = element.Name.LocalName;

                while (dataDictionary.ContainsKey(keyName))
                {
                    keyName = element.Name.LocalName + "_" + keyInt++;
                }

                dataDictionary.Add(keyName, element.Value);
            }
            return dataDictionary;
        }

        public async Task<IDictionary<string,string>> UploadUsers(IDictionary<string, string> Server, IList<IDictionary<string, string>> Users)
        {
            string result = await Task.Run(() =>
            {
                /* Decide which protocol function to use from the moodle api and
                 * execute the function with the function parameters.
                 */
                dynamic ProtocolFunction = (Server["protocol"] == "rest") ? moodle.rest_protocol : moodle.xmlrpc_protocol;
                return (string)ProtocolFunction(Server, Users, "core_user_create_users", "users");
            });
            /* Parse moodle's xml response into a nice dictionary to update the GUI with. */
            return getDictionaryFromXML(result); 
        }

        public async Task<Dictionary<string, string>> CreateCohort(IDictionary<string, string> Server, IDictionary<string, object> CohortData)
        {
            /* Put the cohort data into a list (bacause that's how the API works) */
            List<Dictionary<string, object>> Cohorts = new List<Dictionary<string, object>>(1)
            {
                [0] = (Dictionary<string, object>)CohortData
            };
            string result = await Task.Run(() =>
            {
                /* Decide which protocol function to use from the moodle api and
                 * execute the function with the function parameters.
                 */
                dynamic ProtocolFunction = (Server["protocol"] == "rest") ? moodle.rest_protocol : moodle.xmlrpc_protocol;
                return (string)ProtocolFunction(Server, Cohorts, "core_cohort_create_cohorts", "cohorts");
            });
            /* Parse moodle's xml response into a nice dictionary to update the GUI with. */
            return getDictionaryFromXML(result);
        }

        public async Task<Dictionary<string, string>> AddMembersToCohort(IDictionary<string, string> Server, IDictionary<string, IDictionary<string, string>> Params)
        {
            string result = await Task.Run(() =>
            {
                /* Decide which protocol function to use from the moodle api and
                 * execute the function with the function parameters.
                 */
                dynamic ProtocolFunction = (Server["protocol"] == "rest") ? moodle.rest_protocol : moodle.xmlrpc_protocol;
                return GET(ProtocolFunction(Server, Params, "core_cohort_add_cohort_members", "members"));
            });
            /* Parse moodle's xml response into a nice dictionary to update the GUI with. */
            return getDictionaryFromXML(result);
        }

        public async Task<Dictionary<string, object>> GetUserProfile(IDictionary<string, string> Server, int UserID)
        {
            string result = await Task.Run(() =>
            {
                /* Decide which protocol function to use from the moodle api and
                 * execute the function with the function parameters.
                 */
                dynamic ProtocolFunction = (Server["protocol"] == "rest") ? moodle.rest_protocol : moodle.xmlrpc_protocol;
                return GET((string)ProtocolFunction(Server, UserID, "core_user_view_user_profile", "userid"));
            });
            /* Parse moodle's xml response into a nice dictionary to update the GUI with. */
            XDocument doc = XDocument.Parse(result);
            Dictionary<string, object> dataDictionary = new Dictionary<string, object>();

            foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
            {
                int keyInt = 0;
                string keyName = element.Name.LocalName;

                while (dataDictionary.ContainsKey(keyName))
                {
                    keyName = element.Name.LocalName + "_" + keyInt++;
                }

                dataDictionary.Add(keyName, element.Value);
            }
            return dataDictionary;
        }

        async public Task<string> GET(string uri)
        { 
            string myContent;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    using (HttpContent content = response.Content)
                    {
                        myContent = await content.ReadAsStringAsync();
                    }
                }
            }
            return myContent;
        }

        #endregion
    }
}
