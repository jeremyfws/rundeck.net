using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RundeckNET.APIObjects;

// ReSharper disable InconsistentNaming

namespace RundeckNET
{
    public class ExecutionResponse
    {
        public Paging paging { get; set; }
        public List<Execution> executions { get; set; } 
    }

    public class Paging
    {
        public int count { get; set; }
        public int total { get; set; }
        public int offset { get; set; }
        public int max { get; set; }
    }

    public class Execution
    {
        public string id { get; set; }
        public string href { get; set; }
        public string permalink { get; set; }
        public ExecutionStatus status { get; set; }
        public string project { get; set; }
        public string user { get; set; }
        public string serverUUID { get; set; }
        [JsonProperty("date-started")]
        public ExecutionTime dateStarted { get; set; }
        [JsonProperty("date-ended")]
        public ExecutionTime dateEnded { get; set; }
        public Job job { get; set; }
        public string description { get; set; }
        public string argstring { get; set; }
        public List<string> successfulNodes { get; set; } 

    }

    public class ExecutionTime
    {
        public long unixtime { get; set; }
        public DateTime date { get; set; }
    }

    public enum ExecutionStatus
    {
        running, succeeded, failed, aborted
    }
}
