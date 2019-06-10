using System;
using System.Collections.Generic;
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

        public List<string> GetPersonalDashboardCertificationData()
        {
            SqlConnection sqlConnection = new SqlConnection(_databaseConnectionString);

            List<string> certificationData = new List<string>();

            try
            {
                string sqlCommandText = "SELECT * FROM Certifications";

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                DateTime expiryDate = DateTime.Now;
                string courseDescription = "";

                int i = 0;

                while (sqlDataReader.Read())
                {
                    expiryDate = sqlDataReader.GetDateTime(1);
                    courseDescription = sqlDataReader.GetString(2);

                    certificationData.Add(courseDescription + "," + expiryDate);

                    i++;
                }

                sqlConnection.Close();

                return certificationData;
            }
            catch (Exception err)
            {
                sqlConnection.Close();

                certificationData.Add("SQL Error: " + err.Message);

                return certificationData;
            }
        }

        public List<string> GetPersonalDashboardCertificationDataCourseTitles()
        {
            SqlConnection sqlConnection = new SqlConnection(_databaseConnectionString);

            List<string> certificationTitles = new List<string>();

            try
            {
                string sqlCommandText = "SELECT * FROM Certifications";

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    certificationTitles.Add(sqlDataReader.GetString(0));
                }

                sqlConnection.Close();

                return certificationTitles;
            }
            catch (Exception err)
            {
                sqlConnection.Close();

                certificationTitles.Add("SQL Error: " + err.Message);

                return certificationTitles;
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