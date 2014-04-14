//-----------------------------------------------------------------------
// <copyright file="ShortagesListController.cs" company="Spectrum Health">
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
            if (Authentication.Type != "pharmadmin")
            {
                Response.Redirect("~/Error");
            }

            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["Type"] = Authentication.Type;
            this.ViewData["PageTitle"] = "All Shortages";
            return this.View();
        }

        /// <summary>
        /// Get Create page
        /// </summary>
        /// <returns>Create page view</returns>
        /// <param name="id">NDC of the drug we are creating a shortage for</param>
        public ActionResult Create(string id = "")
        {
            DrugEntryRepository db = new DrugEntryRepository();

            DrugEntry drug = db.GetDrug(id);

            if (Authentication.Type != "pharmadmin" || drug == null)
            {
                Response.Redirect("~/Error");
            }

            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["Type"] = Authentication.Type;
            this.ViewData["PageTitle"] = "Create Shortage";
            return this.View(drug);
        }

        /// <summary>
        /// Get Edit page
        /// </summary>
        /// <param name="id">Id of the shortage being edited</param>
        /// <returns>Edit page view</returns>
        public ActionResult Edit(int id = 0)
        {
            if (Authentication.Type != "pharmadmin")
            {
                Response.Redirect("~/Error");
            }

            ShortageRepository db = new ShortageRepository();
            DrugEntryRepository drugDb = new DrugEntryRepository();

            Shortage shortage = db.GetShortage(id);
            
            if (shortage == null)
            {
                return this.HttpNotFound();
            }

            DrugEntry drugEntry = drugDb.GetDrug(shortage.Ndc);

            if (drugEntry == null)
            {
                return this.HttpNotFound();
            }

            var tuple = new Tuple<Shortage, DrugEntry>(shortage, drugEntry);

            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["Type"] = Authentication.Type;
            this.ViewData["PageTitle"] = "Edit Shortage";
            return this.View(tuple);
        }

        /// <summary>
        /// Get Details page
        /// </summary>
        /// <param name="id">Id of the shortage being examined</param>
        /// <returns>Edit page view</returns>
        public ActionResult Details(int id = 0)
        {
            ShortageRepository db = new ShortageRepository();

            Shortage shortage = db.GetShortage(id);
            if (shortage == null)
            {
                return this.HttpNotFound();
            }

            this.ViewData["Username"] = Authentication.Username;
            this.ViewData["Type"] = Authentication.Type;
            this.ViewData["PageTitle"] = "Shortage Details";
            return this.View(shortage);
        }
    }
}
