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
                // Format Parsed XML
                html += item.title + "\n" 
                    + item.link + "\n"
                    + item.pubDate + "\n"
                    + item.creator + "\n"
                    + item.category + "\n"
                    + item.description + "\n"
                    + item.encodedContent + "\n"
                    + item.other + "\n\n\n";           
            }

            return html;
        }
    }
}