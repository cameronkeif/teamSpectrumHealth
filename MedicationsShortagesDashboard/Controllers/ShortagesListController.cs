//-----------------------------------------------------------------------
// <copyright file="ShortagesListController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Web.Mvc;
    using MedicationsShortagesDashboard.Services;
    using MedicationsShortagesDashboard.Models;

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
        /// Get Edit page
        /// </summary>
        /// <param name="id">Id of the shortage being edited</param>
        /// <returns>Edit page view</returns>
        public ActionResult Edit(int id = 0)
        {
            ShortageRepository db = new ShortageRepository();

            Shortage shortage = db.GetShortage(id);
            if (shortage == null)
            {
                return this.HttpNotFound();
            }

            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["PageTitle"] = "Edit Shortage";
            return this.View(shortage);
        }
    }
}
