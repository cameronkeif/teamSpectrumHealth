//-----------------------------------------------------------------------
// <copyright file="DrugEntriesListController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

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
            return View();
        }
    }
}