using System;

using System.Data.SqlClient;

namespace PersonalWebsiteDashboard
{
    public class DatabaseManager
    {
        #region Members

        private readonly string _databaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebServiceDataConnectionString"].ConnectionString;

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
            SqlConnection sqlConnection = new SqlConnection("");

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
            SqlConnection sqlConnection = new SqlConnection("");

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