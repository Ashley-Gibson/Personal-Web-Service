using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PersonalWebService
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class HelloWorldWebService
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
        [WebGet(UriTemplate = "/GetTestData")]
        public String GetTestData()
        {
            return dbManager.GetTestData();
        }

        // GET
        [WebGet(UriTemplate = "/VisualStudioBlog")]
        public String GetVisualStudioBlogFeed()
        {
            const string URL = "https://devblogs.microsoft.com/visualstudio/feed/";
            string urlParameters = "";

            HttpClient client = new HttpClient();            
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/rss+xml"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body
                var dataObjects = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    Console.WriteLine("{0}", d);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return "";
        }

        #endregion

        #region TutorialMembers

        private static List<string> list = new List<string>(new String[] { "Arrays", "Queues", "Stacks" });

        #endregion

        #region TutorialMethods

        // GET
        [WebGet(UriTemplate="/Tutorial")]
        public String GetAllTutorials()
        {
            int count = list.Count;
            String TutorialList = "";
            for (int i = 0; i < count; i++)
                TutorialList = TutorialList + list[i] + ",";
            return TutorialList;            
        }

        // GET
        [WebGet(UriTemplate="/Tutorial/{Tutorialid}")]
        public String GetTutorialByID(String Tutorialid)
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