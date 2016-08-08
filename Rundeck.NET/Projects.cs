using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundeckNET.APIObjects
{
    
    public class Project
    {
        public string url { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public List<Job> GetJobs()
        {
            RundeckClient c = new RundeckClient();
            return c.GetRequest<List<Job>>(string.Format("project/{0}/jobs", name));
        }
       
    }
}
