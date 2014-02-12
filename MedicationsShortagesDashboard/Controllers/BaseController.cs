//-----------------------------------------------------------------------
// <copyright file="BaseController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using MedicationsShortagesDashboard.Services;

    /// <summary>
    /// Base controller that allows a username to be displayed across pages. All controllers should inherit from this
    /// </summary>
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Get index page
        /// </summary>
        /// <returns>Index page view</returns>
        public ActionResult Index()
        {
            this.ViewData["Username"] = Authentication.Username;
            return this.View();
        }
    }
}
