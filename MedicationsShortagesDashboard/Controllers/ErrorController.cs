//-----------------------------------------------------------------------
// <copyright file="ErrorController.cs" company="Spectrum Health">
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
    /// Class controlling the Error page
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Creates an index page
        /// </summary>
        /// <returns>The page as a view</returns>
        public ActionResult Index()
        {
            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["Type"] = Authentication.Type;
            this.ViewData["PageTitle"] = "Error";
            return this.View();
        }
    }
}
