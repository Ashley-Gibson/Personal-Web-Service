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

        public string GetPersonalDashboardCoursesData()
        {
            SqlConnection sqlConnection = new SqlConnection(_databaseConnectionString);

            try
            {
                string sqlCommandText = "SELECT * FROM CoursesAndCerts";

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                string courseName = "";
                DateTime expiryDate = DateTime.Now;
                string courseDescription = "";

                int i = 0;

                while (sqlDataReader.Read())
                {
                    courseName = sqlDataReader.GetString(0);
                    expiryDate = sqlDataReader.GetDateTime(1);
                    courseDescription = sqlDataReader.GetString(2);

                    outputString += courseName + "," + courseDescription + "," + expiryDate.ToShortDateString();

                    i++;
                }

                sqlConnection.Close();

                return outputString;
            }
            catch (Exception err)
            {
                sqlConnection.Close();

                return "SQL Error: " + err.Message;
            }
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