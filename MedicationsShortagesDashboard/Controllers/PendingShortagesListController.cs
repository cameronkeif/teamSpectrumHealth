//-----------------------------------------------------------------------
// <copyright file="PendingShortagesListController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Controller for displaying all pending shortages
    /// </summary>
    public class PendingShortagesListController : Controller
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
