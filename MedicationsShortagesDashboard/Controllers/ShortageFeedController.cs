//-----------------------------------------------------------------------
// <copyright file="ShortageFeedController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------
namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Utilities;

    /// <summary>
    /// Temporary controller used to display the results of the XML parsing.
    /// </summary>
    public class ShortageFeedController : Controller
    {
        /// <summary>
        ///     Default page
        /// </summary>
        /// <returns>HTML string</returns>
        public string Index()
        {
            XmlReader reader = XmlReader.Create("http://www.ashp.org/rss/shortages/#current");
            List<Shortage> shortages = RssFeedParser.ParseAshpFeed(reader); // Parse the shortage feed
            foreach (Shortage shortage in shortages) 
            {
                returnStr += "<tr><td>" + shortage.drugName + "</td><td>" + shortage.status.ToString() + "</td><td>" + shortage.sourceURL + "</td></tr>";
            }

            returnStr += "</table><br><br><u>SEVERE</u><br><table border=\"1\">";

            shortages = RssFeedParser.ParseAshpFeed("http://www.ashp.org/rss/notavailable/#notavailable", StatusCondition.SEVERE); // Parse the shortage feed
            foreach (Shortage shortage in shortages) 
            {
                returnStr += "<tr><td>" + shortage.drugName + "</td><td>" + shortage.status.ToString() + "</td><td>" + shortage.sourceURL + "</td></tr>";
            }

            returnStr += "</table>";
            return returnStr;
        }
    }
}
