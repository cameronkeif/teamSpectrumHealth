using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MedicationsShortagesDashboard.Controllers
{
    public class ShortageFeedController : Controller
    {
        //
        // GET: /ShortageFeed/

        public string Index()
        {
            XmlReader reader = XmlReader.Create("http://www.ashp.org/rss/shortages/#current");
            List<string> rssElements = new List<String>();
            String tag = "";

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        //writer.WriteStartElement(reader.Name);
                        tag = reader.Name;
                        break;
                    case XmlNodeType.Text:
                        //writer.WriteString(reader.Value);
                        rssElements.Add(tag + ": " + reader.Value);
                        break;
                    case XmlNodeType.XmlDeclaration:
                    case XmlNodeType.ProcessingInstruction:
                        //writer.WriteProcessingInstruction(reader.Name, reader.Value);
                        break;
                    case XmlNodeType.Comment:
                        //writer.WriteComment(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        //writer.WriteFullEndElement();
                        break;
                }
            }
            String returnStr = "<u>stuff</u>";

            foreach(String rssElement in rssElements) {
                returnStr = returnStr + "<br>" + rssElement;
            }
            return returnStr;
        }

    }
}
