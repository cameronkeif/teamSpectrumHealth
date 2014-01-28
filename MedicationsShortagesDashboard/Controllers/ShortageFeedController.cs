using MedicationsShortagesDashboard.Models;
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
            String returnStr = "<u>WARNING</u><br><table border=\"1\">";
            List<Shortage> shortages = parseAshpFeed("http://www.ashp.org/rss/shortages/#current", StatusCondition.WARNING); // Parse the shortage feed
            foreach(Shortage shortage in shortages) {
                returnStr += "<tr><td>" + shortage.drugName + "</td><td>" + shortage.status.ToString() + "</td><td>" + shortage.sourceURL + "</td></tr>";
            }

            returnStr += "</table><br><br><u>SEVERE</u><br><table border=\"1\">";

            shortages = parseAshpFeed("http://www.ashp.org/rss/notavailable/#notavailable", StatusCondition.SEVERE); // Parse the shortage feed
            foreach(Shortage shortage in shortages) {
                returnStr += "<tr><td>" + shortage.drugName + "</td><td>" + shortage.status.ToString() + "</td><td>" + shortage.sourceURL + "</td></tr>";
            }
            returnStr += "</table>";
            return returnStr;
        }

        private List<Shortage> parseAshpFeed(string URL, StatusCondition status)
        {
            XmlReader reader = XmlReader.Create(URL);
            List<Shortage> shortages = new List<Shortage>();
            String tag = String.Empty, link = String.Empty, drugName = String.Empty;

            //TODO clean up this. I think it can be made better -CK
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        tag = reader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (tag.Equals("category"))
                        {
                            drugName = reader.Value.Replace("Shortage Bulletin", String.Empty);
                        }
                        if (tag.Equals("link"))
                        {
                            // The top of the feed also contains links. Need to ensure these links are actually for drug shortage information
                            if (!String.IsNullOrEmpty(drugName))
                            {
                                shortages.Add(new Shortage(drugName, status, reader.Value));
                            }
                        }
                        break;
                }
            }

            return shortages;
        }
    }
}
