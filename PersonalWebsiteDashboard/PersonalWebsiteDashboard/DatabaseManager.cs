using System;
using System.Configuration;
using System.Data.SqlClient;

namespace PersonalWebsiteDashboard
{
    public class DatabaseManager
    {
        #region Members

        private static readonly string _databaseConnectionString = "Data Source=184.168.47.21;Initial Catalog=WebServiceData;Persist Security Info=True;User ID=AGibson;Password=JG|=?:LWq=zyW@M|Z^Zs.G#5iPHM!~#,";//ConfigurationManager.ConnectionStrings["WebServiceDataConnectionString"].ConnectionString != null ? "" : "";

        private string testOutputString = "";
        private const string outputStringValidator = "hello";

        #endregion

        #region Methods

        public string GetDatabaseConnectionString()
        {
            return "";
        }
        
        public bool TestConnectionString()
        {
            SqlConnection sqlConnection = new SqlConnection(_databaseConnectionString);

            try
            {
                sqlConnection.Open();
                sqlConnection.Close();

                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine("SQL Error: " + err.InnerException);

                sqlConnection.Close();

                return false;
            }
        }

        public string GetTestData()
        {
            SqlConnection sqlConnection = new SqlConnection(_databaseConnectionString);

            try
            {
                string sqlCommandText = "SELECT * FROM CoursesAndCerts";
                            
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int i = 0;
                while(sqlDataReader.Read())
                {
                    testOutputString = testOutputString + sqlDataReader.GetValue(i);
                    i++;
                }

                sqlConnection.Close();

                return testOutputString.Replace(" ", String.Empty);           
            }
            catch(Exception err)
            {
                sqlConnection.Close();

                return "SQL Error: " + err.Message;                
            }            
        }

        #endregion
    }
}