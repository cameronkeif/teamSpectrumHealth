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
        /// Get index page
        /// </summary>
        /// <returns>Index page view</returns>
        public ActionResult Index()
        {
            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["PageTitle"] = "All Shortages";
            return this.View();
        }

        /// <summary>
        /// Get Create page
        /// </summary>
        /// <returns>Create page view</returns>
        public ActionResult Create()
        {
            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["PageTitle"] = "Create Shortage";
            return this.View();
        }

        /// <summary>
        /// Get Delete page
        /// </summary>
        /// <returns>Delete page view</returns>
        public ActionResult Delete()
        {
            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["PageTitle"] = "Delete Shortage";
            return this.View();
        }

        /// <summary>
        /// Get Edit page
        /// </summary>
        /// <returns>Edit page view</returns>
        public ActionResult Edit()
        {
            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["PageTitle"] = "Edit Shortage";
            return this.View();
        }
    }
}
