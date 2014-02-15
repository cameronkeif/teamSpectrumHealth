//-----------------------------------------------------------------------
// <copyright file="BaseController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
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
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload] == null || Request.Files[upload].ContentLength <= 0) continue;
                string path = AppDomain.CurrentDomain.BaseDirectory + "uploads\\";
                string filename = Path.GetFileName(Request.Files[upload].FileName);
                Request.Files[upload].SaveAs(Path.Combine(path, filename));
                System.Diagnostics.Debug.WriteLine("OH HEY LOOK: " + Path.Combine(path, filename));
            }
        
            this.ViewData["Username"] = Authentication.Username;
            return this.View();
        }
    }
}
