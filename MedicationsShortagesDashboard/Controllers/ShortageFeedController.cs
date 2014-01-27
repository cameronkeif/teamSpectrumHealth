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
            List<string> things = new List<String>();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        //writer.WriteStartElement(reader.Name);
                        break;
                    case XmlNodeType.Text:
                        //writer.WriteString(reader.Value);
                        things.Add(reader.Value);
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

            foreach(String thing in things) {
                returnStr = returnStr + "<br>" + thing;
            }
            return returnStr;
        }

    }
}
