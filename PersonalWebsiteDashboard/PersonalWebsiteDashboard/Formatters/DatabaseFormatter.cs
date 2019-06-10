using System.Collections.Generic;
using System.Linq;

namespace PersonalWebsiteDashboard
{
    public class DatabaseFormatter
    {
        public static List<string> FormatCertificationData(List<string> rawData)
        {
            List<string> html = new List<string>();

            for (int i = 0; i <= rawData.Count - 1; i++)
            {
                html.Add("<b>Description:</b> " + (!string.IsNullOrEmpty(rawData[i].Split('|')[0]) ? rawData[i].Split('|')[0] : "N/A") + "<br /><br /><b>Expiry Date:</b> " + (!string.IsNullOrEmpty(rawData[i].Split('|')[1]) ? rawData[i].Split('|')[1] : "N/A") + "<br /><br />Technologies: " + (!string.IsNullOrEmpty(rawData[i].Split('|')[2]) ? rawData[i].Split('|')[2] : "N/A"));
            }
            
            return html;
        }    
    }
}