using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Xml;

namespace MoodleRegisrtationTool
{
    class MoodleAPI
    {
        #region Private Variables
        ScriptRuntime python;
        dynamic moodle;
        IDictionary<string, string> Server;
        #endregion

        #region Constructor
        public MoodleAPI(IDictionary<string, string> Server)
        {
            python = Python.CreateRuntime();
            moodle = python.ImportModule("moodle");
            this.Server = Server;
        }
        #endregion

        #region Methods

        public async Task<IList<IDictionary<string, object>>> UploadUsers(IDictionary<string, object> User)
        {
            /* Contruct the data structure required by the moodle API */
            
            Dictionary<string, object> data = new Dictionary<string, object>(2)
            {
                ["users"] = new List<object>()
                {
                    User
                }
            };

            /* Parse moodle's json response into a nice dictionary to update the GUI with. */
            return JsonConvert.DeserializeObject<IList<IDictionary<string, object>>>
                (await POST(Server, "core_user_create_users", data));
        }

        public async Task<List<Dictionary<string, object>>> CreateCohort(string name)
        {
            /* Contruct the data structure required by the moodle API */
            Dictionary<string, object> postData = new Dictionary<string, object>(1)
            {
                ["cohorts"] = new List<object>(1)
                {
                    new Dictionary<string, object>(3)
                    {
                        ["categorytype"] = new Dictionary<string, string>(2)
                        {
                            ["type"] = "system",
                            ["value"] = ""
                        },
                        ["name"] = name,
                        ["idnumber"] = name
                    }
                }
            };
            /* Parse moodle's json response into a nice dictionary to update the GUI with. */
            return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>
                (await POST(Server, "core_cohort_create_cohorts", postData));
        }

        public async Task<Dictionary<string, object>> AddMemberToCohort(string idNumber, int userID)
        {
            IDictionary<string, object> postData = new Dictionary<string, object>(1)
            {
                ["members"] = new List<object>(1)
                {
                    new Dictionary<string, object>(2)
                    {
                        ["cohorttype"] = new Dictionary<string, string>(2)
                        {
                            ["type"] = "idnumber",
                            ["value"] = idNumber
                        },
                        ["usertype"] = new Dictionary<string, object>(2)
                        {
                            ["type"] = "id",
                            ["value"] = userID
                        }
                    }
                }
            };
            /* Parse moodle's json response into a nice dictionary to update the GUI with. */
            return JsonConvert.DeserializeObject<Dictionary<string, object>>
                (await POST(Server, "core_cohort_add_cohort_members", postData));
        }

        public async Task<Dictionary<string, object>> GetUserProfile(int UserID)
        {
            /* Parse moodle's json response into a nice dictionary to update the GUI with. */
            return JsonConvert.DeserializeObject<Dictionary<string, object>>
                (await POST(Server, "core_user_view_user_profile", new Dictionary<string, object> {
                { "userid", UserID }}));
        }

        public async Task<string> POST(IDictionary<string, string> Server, string Function, dynamic Data)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(Data), Encoding.UTF8, "application/json");
            Console.WriteLine(await stringContent.ReadAsStringAsync());
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.PostAsync(
                            $"{Server["uri"]}/webservice/{Server["protocol"]}/server.php?wstoken={Server["token"]}&wsfunction={Function}", stringContent
                            ))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string a = await content.ReadAsStringAsync();
                            Console.WriteLine(a);
                            return a;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}
