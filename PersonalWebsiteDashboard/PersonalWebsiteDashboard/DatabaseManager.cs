using System;
using System.Configuration;
using System.Data.SqlClient;

namespace PersonalWebsiteDashboard
{
    public class DatabaseManager
    {
        #region Members

        private static readonly string _databaseConnectionString = "Data Source=184.168.47.21;Initial Catalog=WebServiceData;Persist Security Info=True;User ID=AGibson;Password=JG|=?:LWq=zyW@M|Z^Zs.G#5iPHM!~#,";//ConfigurationManager.ConnectionStrings["WebServiceDataConnectionString"].ConnectionString != null ? "" : "";

        private string outputString = "";
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

        public string GetTestData(string tableName)
        {
            SqlConnection sqlConnection = new SqlConnection(_databaseConnectionString);

            try
            {
                string sqlCommandText = "SELECT * FROM " + tableName;
                            
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int i = 0;
                while(i < sqlDataReader.FieldCount - 1)
                {
                    outputString += sqlDataReader.GetValue(i);
                    i++;
                }

                sqlConnection.Close();

                return outputString.Replace(" ", String.Empty);           
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