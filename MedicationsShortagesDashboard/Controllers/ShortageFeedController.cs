using MedicationsShortagesDashboard.Models;
using MedicationsShortagesDashboard.Utilities;
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
            List<Shortage> shortages = rssFeedParser.parseAshpFeed("http://www.ashp.org/rss/shortages/#current", StatusCondition.WARNING); // Parse the shortage feed
            foreach(Shortage shortage in shortages) {
                returnStr += "<tr><td>" + shortage.drugName + "</td><td>" + shortage.status.ToString() + "</td><td>" + shortage.sourceURL + "</td></tr>";
            }

            returnStr += "</table><br><br><u>SEVERE</u><br><table border=\"1\">";

            shortages = rssFeedParser.parseAshpFeed("http://www.ashp.org/rss/notavailable/#notavailable", StatusCondition.SEVERE); // Parse the shortage feed
            foreach(Shortage shortage in shortages) {
                returnStr += "<tr><td>" + shortage.drugName + "</td><td>" + shortage.status.ToString() + "</td><td>" + shortage.sourceURL + "</td></tr>";
            }
            returnStr += "</table>";
            return returnStr;
        }
    }
}
