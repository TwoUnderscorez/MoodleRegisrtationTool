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

        public async Task<IList<IDictionary<string, object>>> UploadUsers(IList<IDictionary<string, object>> Users)
        {
            /* Decide which protocol function to use from the moodle api and
            * execute the function with the function parameters.
            */
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                { "users", Users }
            };
            /* Parse moodle's json response into a nice dictionary to update the GUI with. */
            return JsonConvert.DeserializeObject<IList<IDictionary<string, object>>>
                (await POST(Server, "core_user_create_users", new Dictionary<string, object> {
                { "users", Users } }));
        }

        public async Task<List<Dictionary<string, object>>> CreateCohort(IDictionary<string, object> CohortData)
        {
            /* Put the cohort data into a list (bacause that's how the API works) */
            List<Dictionary<string, object>> Cohorts = new List<Dictionary<string, object>>(1)
            {
                [0] = (Dictionary<string, object>)CohortData
            };
            /* Parse moodle's xml response into a nice dictionary to update the GUI with. */
            return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>
                (await POST(Server, "core_cohort_create_cohorts", Cohorts));
        }

        public async Task<Dictionary<string, string>> AddMembersToCohort(IDictionary<string, string> Server, IDictionary<string, IDictionary<string, string>> Params)
        {
            /* Decide which protocol function to use from the moodle api and
            * execute the function with the function parameters.
            */
            string result = await GET(moodle.rest_protocol(Server, Params, "core_cohort_add_cohort_members", "members"));
            /* Parse moodle's xml response into a nice dictionary to update the GUI with. */
            return null;
        }

        public async Task<Dictionary<string, object>> GetUserProfile(int UserID)
        {
            /* Decide which protocol function to use from the moodle api and
            * execute the function with the function parameters.
            */
            /* Parse moodle's json response into a nice dictionary to update the GUI with. */
            return JsonConvert.DeserializeObject<Dictionary<string, object>>
                (await POST(Server, "core_user_view_user_profile", new Dictionary<string, object> {
                { "userid", UserID }}));
        }

        async public Task<string> GET(string uri)
        { 
            string myContent;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(new Uri(uri)))
                {
                    response.Headers.Add("Accept", "application/json");
                    using (HttpContent content = response.Content)
                    {
                        myContent = await content.ReadAsStringAsync();
                    }
                }
            }
            return myContent;
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
