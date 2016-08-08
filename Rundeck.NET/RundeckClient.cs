using RestSharp;
using RundeckNET.APIObjects;
using RundeckNET.Config;
using System;
using System.Collections.Generic;
namespace RundeckNET
{
    public sealed class RundeckClient
    {
        private string endpoint = "";
        private string authtoken;
        public string AuthToken
        {
            get { return "?authtoken=" + authtoken; }
            set { authtoken = value; }
        }
        public RundeckClient(string Endpoint, string AuthToken)
        {
            endpoint = Endpoint;
            authtoken = AuthToken;
            Ping();

        }
        /// <summary>
        /// Create Rundeck client using app.config for endpoing settings
        /// </summary>
        public RundeckClient()
        {
            if (!String.IsNullOrEmpty(APISettings.Settings.Endpoint))
                endpoint = APISettings.Settings.Endpoint;
            if ((APISettings.Settings.Port.ToString() != ""))
                endpoint += ":" + APISettings.Settings.Port;
            if (!String.IsNullOrEmpty(APISettings.Settings.AuthToken))
                AuthToken = authtoken = APISettings.Settings.AuthToken;

            Ping();
        }
        public RundeckClient Authenticate(string APIToken)
        {

            return this;
        }

        /// <summary>
        /// Check if rundeck api service is correct
        /// </summary>
        public void Ping()
        {
            var client = new RestClient(endpoint);
            var req = new RestRequest("system/info" + AuthToken, Method.GET);
            IRestResponse res = client.Execute(req);

            //if (res.StatusCode != System.Net.HttpStatusCode.OK)
            //    throw new RundeckNETException();

        }


        public SystemInfoRoot GetSystemInfo()
        {
            return GetRequest<SystemInfoRoot>("system/info");
        }


        public List<Project> GetProjects()
        {
            return GetRequest<List<Project>>("projects");

        }




        internal T GetRequest<T>(string resource) where T : new()
        {
            return Response<T>(resource, Method.GET);
        }
        internal T PostRequest<T>(string resource) where T : new()
        {
            return Response<T>(resource, Method.POST);
        }
        private T Response<T>(string resource, Method method) where T : new()
        {
            var client = new RestClient(endpoint);
            var req = new RestRequest("/api/17/" + resource + AuthToken, method);
            req.RequestFormat = DataFormat.Json;
            return client.Execute<T>(req).Data;
        }



    }
}
