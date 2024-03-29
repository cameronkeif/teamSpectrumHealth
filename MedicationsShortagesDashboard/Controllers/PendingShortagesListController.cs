﻿//-----------------------------------------------------------------------
// <copyright file="PendingShortagesListController.cs" company="Spectrum Health">
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
    public class PendingShortagesListController : Controller
    {
        /// <summary>
        /// Creates an index page
        /// </summary>
        /// <returns>The page as a view</returns>
        public ActionResult Index()
        {
            if (Authentication.Type != "pharmadmin")
            {
                Response.Redirect("~/Error");
            }

            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["Type"] = Authentication.Type;
            this.ViewData["PageTitle"] = "Manage Feeds";
            return this.View();
        }

        /// <summary>
        /// Creates page listing all ignored pending shortages
        /// </summary>
        /// <returns>The page as a view</returns>
        public ActionResult Ignored()
        {
            if (Authentication.Type != "pharmadmin")
            {
                Response.Redirect("~");
            }

            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["Type"] = Authentication.Type;
            this.ViewData["PageTitle"] = "Ignored Pending Shortages";
            return this.View();
        }
    }
}
