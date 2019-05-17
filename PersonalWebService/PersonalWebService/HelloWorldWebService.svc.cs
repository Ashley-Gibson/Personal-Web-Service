using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace PersonalWebService
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class HelloWorldWebService
    {
        #region Members

        private static readonly DatabaseManager dbManager = new DatabaseManager();
        private static readonly string connectionString = dbManager.GetDatabaseConnectionString();
        
        #endregion

        #region Methods

        // GET
        [WebGet(UriTemplate = "/GetTestData")]
        public String GetTestData()
        {
            return dbManager.GetTestData();
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
