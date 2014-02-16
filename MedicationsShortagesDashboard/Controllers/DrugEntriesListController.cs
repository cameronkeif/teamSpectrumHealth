//-----------------------------------------------------------------------
// <copyright file="DrugEntriesListController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using MedicationsShortagesDashboard.Utilities;

    /// <summary>
    /// Controller for displaying all drug entries
    /// </summary>
    public class DrugEntriesListController : Controller
    {
        /// <summary>
        /// Get index page
        /// </summary>
        /// <returns>Index page view</returns>
        public ActionResult Index()
        {
            if (Request.Files.Count > 0)
            {
                CSVDownloader downloader = new CSVDownloader();
                downloader.DownloadCSV(Request);
            }

            return View();
        }
    }
}