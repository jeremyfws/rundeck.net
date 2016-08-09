using Microsoft.VisualStudio.TestTools.UnitTesting;
using RundeckNET;

namespace Rundeck.NET.Tests
{

    /// <summary>
    /// Uses the linked app.config from sample project.
    /// </summary>
    [TestClass]
    public class ExecutionsTests
    {
        [TestMethod]
        public void GetExecutionsForEmailShovelShouldReturnAtLeastFiveExecutions()
        {
            var client = new RundeckClient();

            var shovel = client.GetProjects().Find(p => p.name.ToLower().Equals("feeds"))
                .GetJobs().Find(j => j.name.ToLower().Equals("bronto email shovel"));

            var executions = shovel.GetExecutions();

            Assert.IsTrue(executions.Count >= 5);
        }
    }
}
