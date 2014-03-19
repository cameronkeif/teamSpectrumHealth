//-----------------------------------------------------------------------
// <copyright file="DrugEntriesListController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Web.Mvc;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;

    /// <summary>
    /// Controller for displaying all drug entries
    /// </summary>
    public class DrugEntriesListController : Controller
    {
        /// <summary>
        /// Get index page
        /// </summary>
        /// <returns>Index page view</returns>
        public ActionResult Index()
        {
            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["PageTitle"] = "Current Shortages";
            return this.View();
        }

        /// <summary>
        /// Get Upload page
        /// </summary>
        /// <returns>Upload page view</returns>
        public ActionResult Upload()
        {
            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["PageTitle"] = "Upload Formulary";
            return this.View();
        }

        /// <summary>
        /// Returns the drug detail view page
        /// </summary>
        /// <param name="id">The NDC of the drug</param>
        /// <returns>The drug detail view page for a drug where NDC == id</returns>
        public ActionResult Details(string id = "")
        {
            DrugEntryDBContext db = new DrugEntryDBContext();
            DrugEntry drug = db.DrugEntries.Find(id);
            Message message = new Message();

            if (drug == null)
            {
                return this.HttpNotFound();
            }

            var tuple = new Tuple<DrugEntry, Message>(drug, message);

            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["PageTitle"] = "Medication Details";
            return this.View(tuple);
        }
    }
}