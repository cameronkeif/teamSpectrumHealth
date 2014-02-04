//-----------------------------------------------------------------------
// <copyright file="ShortageFeedController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------
namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
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
            
            List<PendingShortage> shortages = RssFeedParser.ParseAshpFeed(reader); // Parse the shortage feed
            PendingShortageDBContext db = new PendingShortageDBContext(); // This will be handled restfully later.

            foreach (PendingShortage shortage in shortages)
            {
                if (db.PendingShortages.FirstOrDefault(i => i.SourceURL == shortage.SourceURL) == null)
                {
                    db.PendingShortages.Add(shortage);
                }
            }

            db.SaveChanges();

            return "done";
        }
    }
}
