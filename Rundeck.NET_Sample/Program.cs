using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundeckNET;
using RundeckNET.APIObjects;
namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new RundeckClient();
            client.Ping();
            SystemInfoRoot info = client.GetSystemInfo();
            Console.WriteLine("Rundeck Version: " + info.system.rundeck.version);
            Console.WriteLine("Rundeck API Version: " +info.system.rundeck.apiversion);
            

            foreach (var proj in client.GetProjects())
            {
                Console.WriteLine(proj.name.ToUpper());
                var jj = proj.GetJobs();
                foreach(var j in jj)
                {
                    Console.WriteLine("\t" + j.name);
                }
            }
            client.GetProjects().Find(s=>s.name=="Data")
                .GetJobs().Find(s=>s.name=="Ambassador").Execute();


            //Console.WriteLine(info)
            Console.Read();

        }
    }
}
