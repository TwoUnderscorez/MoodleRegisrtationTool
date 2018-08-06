using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleRegisrtationTool
{
    class MoodleAPI
    {
        #region Private Variables
        ScriptRuntime python;
        dynamic moodle;
        dynamic mdl;
        #endregion

        #region Constructor
        public MoodleAPI()
        {
            python = Python.CreateRuntime();
            moodle = python.ImportModule("moodle.moodle");
            mdl = moodle.MDL();
        }
        #endregion

        #region Methods

        public async Task<IDictionary<string,string>> UploadUsers(IDictionary<string, string> Server, IList<IDictionary<string, string>> Users)
        {
            string result = await Task.Run(() =>
            {
                /* Decide which protocol function to use from the moodle api and
                 * execute the function with the function parameters.
                 */
                dynamic ProtocolFunction = (Server["protocol"] == "rest") ? mdl.rest_protocol : mdl.xmlrpc_protocol;
                return (string)ProtocolFunction(Server, Users, "core_user_create_users", "users");
            });
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
            string result = await Task.Run(() =>
            {
                /* Decide which protocol function to use from the moodle api and
                 * execute the function with the function parameters.
                 */
                dynamic ProtocolFunction = (Server["protocol"] == "rest") ? mdl.rest_protocol : mdl.xmlrpc_protocol;
                return (string)ProtocolFunction(Server, Cohorts, "core_cohort_create_cohorts", "users");
            });
            /* Parse moodle's xml response into a nice dictionary to update the GUI with. */
            return null;
        }

        public async Task<Dictionary<string, string>> AddMembersToCohort(IDictionary<string, string> Server, IDictionary<string, IDictionary<string, string>> Params)
        {
            string result = await Task.Run(() =>
            {
                /* Decide which protocol function to use from the moodle api and
                 * execute the function with the function parameters.
                 */
                dynamic ProtocolFunction = (Server["protocol"] == "rest") ? mdl.rest_protocol : mdl.xmlrpc_protocol;
                return (string)ProtocolFunction(Server, Params, "core_cohort_add_cohort_members", "members");
            });
            /* Parse moodle's xml response into a nice dictionary to update the GUI with. */
            return null;
        }

        #endregion
    }
}
