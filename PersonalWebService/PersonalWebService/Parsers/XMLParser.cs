using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml;

namespace PersonalWebService
{
    public class XMLParser
    {
        public struct VSBlog_Item
        {
            public string title;
            public string link;
            public string pubDate;
            public string creator;
            public string category;
            public string description;
            public string encodedContent;

            public string other;    // For picking out Elements I have missed through parsing
        }

        public static string ParseVisualStudioBlogResponse(HttpResponseMessage response)
        {
            // Reading XML
            XmlDocument xml = new XmlDocument();
            string parsedResponse = "";

            List<VSBlog_Item> itemList = new List<VSBlog_Item>();

            if (response.IsSuccessStatusCode)
            {
                // If successful response then parse XML
                xml.LoadXml(response.Content.ReadAsStringAsync().Result);

                // Extract XML Element Types
                XmlNodeList items = xml.SelectNodes("/rss/channel/item");             
                
                // Load data into XML items first
                foreach (XmlNode item in items)
                {
                    VSBlog_Item temp = new VSBlog_Item();

                    foreach (XmlElement element in item)
                    {
                        // Determine XML Element Type
                        switch (element.Name)
                        {
                            case "title":
                                temp.title = element.InnerText;
                                break;
                            case "link":
                                temp.link = element.InnerText;
                                break;
                            case "pubDate":
                                temp.pubDate = ConvertToShortDate(element.InnerText);
                                break;
                            case "dc:creator":
                                temp.creator = element.InnerText;
                                break;
                            case "category":
                                temp.category = element.InnerText;
                                break;
                            case "description":
                                temp.description = element.InnerText;
                                break;
                            case "content:encoded":
                                temp.encodedContent = element.InnerText;
                                break;
                            default:
                                temp.other += (";" + element.Name);
                                break;
                        }                        
                    }

                    itemList.Add(temp);
                }
            }
            else
            {
                // If unsuccessful response then output the Error
                parsedResponse = "Error: {0} ({1})" + (int)response.StatusCode + response.ReasonPhrase;
            }

            return ResponseFormatter.VSBlog_FormatResponse(itemList);
        }

        // Change Short Date functionality here
        private static string ConvertToShortDate(string longDate)
        {
            DateTime convertedDate = Convert.ToDateTime(longDate);

            string shortDate = convertedDate.ToShortDateString() + " " + convertedDate.ToShortTimeString();

            return shortDate;
        }
    }
}