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
        #endregion

        #region Constructor
        public MoodleAPI()
        {
            python = Python.CreateRuntime();
            moodle = python.ImportModule("moodle");
        }
        #endregion

        #region Methods

        public async Task<IDictionary<string,string>> UploadUsers(IDictionary<string, string> Server, IList<IDictionary<string, string>> Users)
        {
            /* Decide which protocol function to use from the moodle api and
            * execute the function with the function parameters.
            */
            string result = await GET(moodle.rest_protocol(Server, Users, "core_user_create_users", "users"));
            /* Parse moodle's xml response into a nice dictionary to update the GUI with. */
            return null;
        }

        public async Task<Dictionary<string, string>> CreateCohort(IDictionary<string, string> Server, IDictionary<string, object> CohortData)
        {
            /* Put the cohort data into a list (bacause that's how the API works) */
            List<Dictionary<string, object>> Cohorts = new List<Dictionary<string, object>>(1)
            {
                [0] = (Dictionary<string, object>)CohortData
            };
            /* Decide which protocol function to use from the moodle api and
            * execute the function with the function parameters.
            */
            string result = await GET(moodle.rest_protocol(Server, Cohorts, "core_cohort_create_cohorts", "cohorts"));
            /* Parse moodle's xml response into a nice dictionary to update the GUI with. */
            return null;
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

        public void NestedDictIteration(Dictionary<string, object> nestedDict)
        {
            foreach (string key in nestedDict.Keys)
            {
                Console.WriteLine(key);
                object nextLevel = nestedDict[key];
                if (nextLevel == null)
                {
                    continue;
                }
                NestedDictIteration((Dictionary<string, object>)nextLevel);
            }
        }

        public async Task<Dictionary<string, object>> GetUserProfile(IDictionary<string, string> Server, int UserID)
        {
            /* Decide which protocol function to use from the moodle api and
            * execute the function with the function parameters.
            */
            Dictionary<string, object> Content = new Dictionary<string, object>();
            Content.Add("userid", UserID);
            //string result = await POST(Server,"core_user_view_user_profile", Content);
            Dictionary<string, object> Result = await POST(Server, "core_user_view_user_profile", Content);
            return Result;
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

        public async Task<Dictionary<string, object>> POST(IDictionary<string, string> Server, string Function, Dictionary<string, object> Data)
        {
            string myContent;
            
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(
                        $"{Server["uri"]}/webservice/{Server["protocol"]}/server.php?wstoken={Server["token"]}&wsfunction={Function}",
                        new StringContent(JsonConvert.SerializeObject(Data), Encoding.UTF8, "application/json")))
                {
                    using (HttpContent content = response.Content)
                    {
                        myContent = await content.ReadAsStringAsync();
                    }
                }
            }
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(myContent);
        }

        #endregion
    }
}
