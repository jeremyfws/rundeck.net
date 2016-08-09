using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

            // see all projects in current installation
            foreach (var proj in client.GetProjects())
            {
                Console.WriteLine(proj.name.ToUpper());
                var jj = proj.GetJobs();
                foreach (var j in jj)
                {
                    Console.WriteLine("\t" + j.name);
                }
            }

            //client.GetProjects().Find(s=>s.name=="Data")
            //    .GetJobs().Find(s=>s.name=="Ambassador").Execute();

            var shovel = client.GetProjects().Find(s => s.name == "Feeds")
                .GetJobs().Find(s => s.name == "Bronto Email Shovel");

            var executions = shovel.GetExecutions();

            foreach (var execution in executions)
            {
                Console.WriteLine("Execution found!");
                Console.WriteLine(execution.id);
                Console.WriteLine($"{execution.dateStarted.date.Date}, {execution.dateStarted.date.TimeOfDay}");
                Console.WriteLine();
            }

            //Console.WriteLine(info)
            Console.Read();

        }
    }
}
