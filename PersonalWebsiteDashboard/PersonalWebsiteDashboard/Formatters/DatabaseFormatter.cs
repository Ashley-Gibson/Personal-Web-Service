using System.Collections.Generic;
using System.Linq;

namespace PersonalWebsiteDashboard
{
    public class DatabaseFormatter
    {
        public static List<string> FormatCertificationData(List<string> rawData)
        {
            List<string> html = new List<string>();                        

            html.Add("<b>Description:</b> " + (!string.IsNullOrEmpty(rawData[0].Split(',')[0]) ? rawData[0].Split(',')[1] : "N/A")  + "<br /><b>Expiry Date:</b> " + (!string.IsNullOrEmpty(rawData[0].Split(',')[2]) ? rawData[0].Split(',')[2] : "N/A"));
            
            return html;
        }    
    }
}