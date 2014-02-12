//-----------------------------------------------------------------------
// <copyright file="ShortagesListController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;

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
            return this.View();
        }

        /// <summary>
        /// Get Create page
        /// </summary>
        /// <returns>Create page view</returns>
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Get Delete page
        /// </summary>
        /// <returns>Delete page view</returns>
        public ActionResult Delete()
        {
            return this.View();
        }
    }
}
