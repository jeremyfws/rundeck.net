using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundeckNET.APIObjects
{
    public class JobList
    {
        public List<Job> Jobs { get; set; }
    }
    public class Job
    {
        public string id { get; set; }
        public string name { get; set; }
        public object group { get; set; }
        public string project { get; set; }
        public string description { get; set; }
        public string href { get; set; }
        public string permalink { get; set; }
        public bool scheduled { get; set; }
        public bool scheduleEnabled { get; set; }
        public bool enabled { get; set; }
        public void Execute()
        {
            ///api/1/job/[ID]/run
            var c = new RundeckClient();
            c.PostRequest<object>("job/" + this.id+"/run");
        }
    }
}
