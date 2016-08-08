namespace RundeckNET.APIObjects
{


    public class Timestamp
    {
        public long epoch { get; set; }
        public string unit { get; set; }
        public string datetime { get; set; }
    }

    public class Rundeck
    {
        public string version { get; set; }
        public string build { get; set; }
        public string node { get; set; }
        public string @base { get; set; }
        public int apiversion { get; set; }
        public object serverUUID { get; set; }
    }

    public class Executions
    {
        public bool active { get; set; }
        public string executionMode { get; set; }
    }

    public class Os
    {
        public string arch { get; set; }
        public string name { get; set; }
        public string version { get; set; }
    }

    public class Jvm
    {
        public string name { get; set; }
        public string vendor { get; set; }
        public string version { get; set; }
        public string implementationVersion { get; set; }
    }

    public class Since
    {
        public long epoch { get; set; }
        public string unit { get; set; }
        public string datetime { get; set; }
    }

    public class Uptime
    {
        public int duration { get; set; }
        public string unit { get; set; }
        public Since since { get; set; }
    }

    public class LoadAverage
    {
        public string unit { get; set; }
        public double average { get; set; }
    }

    public class Cpu
    {
        public LoadAverage loadAverage { get; set; }
        public int processors { get; set; }
    }

    public class Memory
    {
        public string unit { get; set; }
        public int max { get; set; }
        public int free { get; set; }
        public int total { get; set; }
    }

    public class Scheduler
    {
        public int running { get; set; }
        public int threadPoolSize { get; set; }
    }

    public class Threads
    {
        public int active { get; set; }
    }

    public class Stats
    {
        public Uptime uptime { get; set; }
        public Cpu cpu { get; set; }
        public Memory memory { get; set; }
        public Scheduler scheduler { get; set; }
        public Threads threads { get; set; }
    }

    public class Metrics
    {
        public string href { get; set; }
        public string contentType { get; set; }
    }

    public class ThreadDump
    {
        public string href { get; set; }
        public string contentType { get; set; }
    }

    public class Healthcheck
    {
        public string href { get; set; }
        public string contentType { get; set; }
    }

    public class SystemInfo
    {
        public Timestamp timestamp { get; set; }
        public Rundeck rundeck { get; set; }
        public Executions executions { get; set; }
        public Os os { get; set; }
        public Jvm jvm { get; set; }
        public Stats stats { get; set; }
        public Metrics metrics { get; set; }
        public ThreadDump threadDump { get; set; }
        public Healthcheck healthcheck { get; set; }
    }

    public class SystemInfoRoot
    {
        public SystemInfo system { get; set; }
        public override string ToString()
        {
            return ObjectDumper.Dump(this);
        }
    }

}
