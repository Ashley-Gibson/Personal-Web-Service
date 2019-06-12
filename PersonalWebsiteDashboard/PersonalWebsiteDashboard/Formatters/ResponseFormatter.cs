using System;
using System.Collections.Generic;

namespace PersonalWebsiteDashboard
{
    public class ResponseFormatter
    {
        public static string GDBlog_FormatResponse(List<XMLParser.GDBlog_Item> parsedResponse)
        {
            string html = "";

            foreach (var item in parsedResponse)
            {
                // Format Parsed XML - Per Blog Post
                html += "<h4>" + "<a href=\"" + item.link + "\" target=\"_blank\">" + item.title + "</a></h4>"
                    + "Published:<b> " + item.published + "</b><br />"
                    + "Author: <b> " + item.author + "</b>" + "<br />";
            }

            return html;
        }

        internal static string KBlog_FormatResponse(List<XMLParser.KBlog_Item> parsedResponse)
        {
            string html = "";

            foreach (var item in parsedResponse)
            {
                // Format Parsed XML - Per Blog Post
                html += "<h4>" + "<a href=\"" + item.link + "\" target=\"_blank\">" + item.title + "</a></h4>"
                    + "Published:<b> " + item.pubDate + "</b><br />"
                    + "Description: <b> " + item.description + "</b>" + "<br />";
            }

            return html;
        }

        public static string TWPEBlog_FormatResponse(List<XMLParser.TWPEBlog_Item> parsedResponse)
        {
            string html = "";

            foreach (var item in parsedResponse)
            {
                // Format Parsed XML - Per Blog Post
                html += "<h4>" + "<a href=\"" + item.link + "\" target=\"_blank\">" + item.title + "</a></h4>"
                    + "Published:<b> " + item.pubDate + "</b><br />"
                    + "Categories: ";

                if (item.category != null)
                {
                    var categories = item.category.Split(';');
                    int i = 0;

                    foreach (var category in categories)
                    {
                        if (i > 0)
                            html += ",";
                        html += " <b>" + categories[i] + "</b>";
                        i++;
                    }
                }

                html += item.description + "<br />";
            }

            return html;
        }

        public static string VSBlog_FormatResponse(List<XMLParser.VSBlog_Item> parsedResponse)
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