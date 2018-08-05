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
        ScriptRuntime python;
        dynamic moodle;
        dynamic mdl;
        public MoodleAPI()
        {
            python = Python.CreateRuntime();
            moodle = python.ImportModule("moodle.moodle");
            mdl = moodle.MDL();
        }
    }
}
