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
            return this.View();
        }

        /// <summary>
        /// Get Upload page
        /// </summary>
        /// <returns>Upload page view</returns>
        public ActionResult Upload()
        {
            return this.View();
        }
    }
}