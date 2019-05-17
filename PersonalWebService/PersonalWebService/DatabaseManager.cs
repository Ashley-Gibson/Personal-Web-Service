using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonalWebService
{
    public class DatabaseManager
    {
        #region Members

        private readonly string _databaseConnectionString = ConfigurationManager.ConnectionStrings["WebServiceDataConnectionString"].ConnectionString;

        private string testOutputString = "";
        private const string outputStringValidator = "hello";

        #endregion

        #region Methods

        public string GetDatabaseConnectionString()
        {
            return _databaseConnectionString;
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
                string sqlCommandText = "SELECT * FROM TestTable";
                            
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