//-----------------------------------------------------------------------
// <copyright file="LoginController.cs" company="Spectrum Health">
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
    /// Class controlling the login page
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// Creates an index page
        /// </summary>
        /// <returns>The page as a view</returns>
        public ActionResult Index()
        {
            if (Authentication.Authenticated)
            {
                Response.Redirect("~/Error");
            }

            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["Type"] = Authentication.Type;
            this.ViewData["PageTitle"] = "Login";
            return this.View();
        }
    }
}
