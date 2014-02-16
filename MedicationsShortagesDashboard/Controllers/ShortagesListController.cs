//-----------------------------------------------------------------------
// <copyright file="ShortagesListController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;
    using MedicationsShortagesDashboard.Services;

    /// <summary>
    /// Controller for displaying all pending shortages
    /// </summary>
    public class ShortagesListController : Controller
    {        
        /// <summary>
        /// Creates an index page
        /// </summary>
        /// <returns>The page as a view</returns>
        public ActionResult Index()
        {
            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["PageTitle"] = "All Shortages";
            return this.View();
        }

        /// <summary>
        /// Creates the create shortage page
        /// </summary>
        /// <returns>The page as a view</returns>
        public ActionResult Create()
        {
            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["PageTitle"] = "Create Shortage";
            return this.View();
        }
    }
}
