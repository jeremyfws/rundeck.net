using System.Collections.Generic;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace RundeckNET.APIObjects
{
    
    public class Project
    {
        public string url { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public List<Job> GetJobs()
        {
            var c = new RundeckClient();
            return c.GetRequest<List<Job>>($"project/{name}/jobs");
        }
       
    }
}
