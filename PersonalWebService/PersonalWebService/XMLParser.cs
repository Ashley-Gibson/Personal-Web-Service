using System.Collections.Generic;
using System.Net.Http;
using System.Xml;

namespace PersonalWebService
{
    public class XMLParser
    {
        public struct Item
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

            List<Item> itemList = new List<Item>();

            if (response.IsSuccessStatusCode)
            {
                // If successful response then parse XML
                xml.LoadXml(response.Content.ReadAsStringAsync().Result);

                // Extract XML Element Types
                XmlNodeList items = xml.SelectNodes("/rss/channel/item");

                /*
                
                /rss/channel/item/title
                /rss/channel/item/link
                /rss/channel/item/comments
                /rss/channel/item/pubDate
                /rss/channel/item/dc:creator
                /rss/channel/item/category
                /rss/channel/item/description
                /rss/channel/item/content:encoded

                */               
                
                // Load data into XML items first
                foreach (XmlNode item in items)
                {
                    Item temp = new Item();

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
                                temp.pubDate = element.InnerText;
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

            return ResponseFormatter.FormatVisualStudioBlogResponse(itemList);
        }
    }
}