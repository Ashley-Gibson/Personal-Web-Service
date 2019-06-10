using System.Collections.Generic;
using System.Linq;

namespace PersonalWebsiteDashboard
{
    public class DatabaseFormatter
    {
        public static string FormatCoursesAndCerts(string rawData)
        {
            string html = "";

            List<string> stringList = rawData.Split(',').ToList();

            html += "<b>Course Name: " + stringList[0] + "</b> <br />Description: " + stringList[1] + " <br />Expiry Date: " + stringList[2];

            return html;
        }    
    }
}