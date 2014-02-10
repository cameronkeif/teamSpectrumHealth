//-----------------------------------------------------------------------
// <copyright file="PendingShortagesListController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using MedicationsShortagesDashboard.Models;

    /// <summary>
    /// Controller for displaying login screen
    /// </summary>
    public class LoginController : Controller
    {

        /// <summary>
        /// Get index page
        /// </summary>
        /// <returns>Index page view</returns>
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.User user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.Username, user.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                }
            }
            return View(user);
        }
    }
}
