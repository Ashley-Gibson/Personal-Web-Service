using System.Collections.Generic;

namespace PersonalWebService
{
    public class ResponseFormatter
    {
        public static string FormatVisualStudioBlogResponse(List<XMLParser.Item> parsedResponse)
        {
            string html = "";

            foreach (var item in parsedResponse)
            {
                // Format Parsed XML - Per Blog Post
                html += "<h4>" + "<a href=\"" + item.link + "\" target=\"_blank\">" + item.title + "</a></h4>"
                    + "Published:<b> " + item.pubDate + "</b><br />"
                    + "Author:<b> " + item.creator + "</b>" + "<br />"
                    + "Category:<b> " + item.category + "</b><br /><br />"
                    + item.description + "<br />";                    
            }

            return html;
        }
    }
}