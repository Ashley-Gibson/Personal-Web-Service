using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Web;

namespace PersonalWebsiteDashboard
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WebServiceManager
    { 
        #region Members

        private static readonly DatabaseManager dbManager = new DatabaseManager();
        private static readonly string connectionString = dbManager.GetDatabaseConnectionString();

        public class DataObject
        {
            public string Name { get; set; }
        }

        #endregion

        #region Methods

        // GET
        [WebGet(UriTemplate = "/GetPersonalDatabaseTestData")]
        public string GetTestData()
        {
            return dbManager.GetTestData();
        }

        // GET
        [WebGet(UriTemplate = "/GetBlog")]
        public string Blog_GetRequest(string URL, string blogName)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };

            // Add an Accept header for rss+xml format - unnecessary but could be useful in future for accepting different response formats
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/rss+xml"));

            HttpResponseMessage response;

            // Error Handling
            try
            {
                // List data response
                response = client.GetAsync("").Result;
            }
            catch (Exception err)
            {
                return err.Message;
            }

            // Determine Blog to Parse
            switch(blogName)
            {
                case "VisualStudio":
                    return XMLParser.ParseVisualStudioBlogResponse(response);
                case "GoogleDevelopers":
                    return XMLParser.ParseGoogleDevsBlogResponse(response);
            }

            return null;
        }
        

        #endregion

        #region TutorialMembers

        private static List<string> list = new List<string>(new string[] { "Arrays", "Queues", "Stacks" });

        #endregion

        #region TutorialMethods

        // GET
        [WebGet(UriTemplate="/Tutorial")]
        public string GetAllTutorials()
        {
            int count = list.Count;
            String TutorialList = "";
            for (int i = 0; i < count; i++)
                TutorialList = TutorialList + list[i] + ",";
            return TutorialList;            
        }

        // GET
        [WebGet(UriTemplate="/Tutorial/{Tutorialid}")]
        public string GetTutorialByID(String Tutorialid)
        {
            int pid;
            Int32.TryParse(Tutorialid, out pid);
            return list[pid];
        }

        // POST
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate ="/Tutorial", ResponseFormat = WebMessageFormat.Json, BodyStyle =WebMessageBodyStyle.Wrapped)]
        public void AddTutorial(String str)
        {
            list.Add(str);
        }

        // DELETE
        [WebInvoke(Method = "DELETE", RequestFormat =WebMessageFormat.Json, UriTemplate ="/Tutorial/{Tutorialid}", ResponseFormat =WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        public void DeleteTutorial(String Tutorialid)
        {
            int pid;
            Int32.TryParse(Tutorialid, out pid);
            list.RemoveAt(pid);
        }

        [OperationContract]
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }

        #endregion
    }
}