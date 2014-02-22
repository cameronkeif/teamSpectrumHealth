//-----------------------------------------------------------------------
// <copyright file="ShortageController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Http;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;

    /// <summary>
    /// Provides a Restful interaction between the application and the
    /// SHORTAGES table in the database.
    /// </summary>
    public class ShortageController : ApiController
    {
        /// <summary>
        /// Performs the actual querying of the shortage table in the database
        /// </summary>
        private ShortageRepository shortageRepository;

        /// <summary>
        /// Performs the actual querying of the drug entry table in the database.
        /// </summary>
        private DrugEntryRepository drugEntryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortageController"/> class
        /// </summary>
        [ExcludeFromCodeCoverage]
        public ShortageController()
        {
            this.drugEntryRepository = new DrugEntryRepository();
            this.shortageRepository = new ShortageRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortageController"/> class
        /// </summary>
        /// <param name="shortageRepository">The database interaction layer</param>
        /// <param name="drugEntryRepository">The database interaction layer (for drugs)</param>
        public ShortageController(ShortageRepository shortageRepository, DrugEntryRepository drugEntryRepository)
        {
            this.drugEntryRepository = drugEntryRepository;
            this.shortageRepository = shortageRepository;
        }

        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <returns>All of the entries in the SHORTAGE table.</returns>
        public Shortage[] Get()
        {
            return this.shortageRepository.GetAllShortages();
        }

        /// <summary>
        /// HTTP Get with one parameter in the query string
        /// </summary>
        /// <param name="id">National Drug Code</param>
        /// <returns>The most recently posted shortage with a matching national drug code.</returns>
        public Shortage[] Get(string id)
        {
            return this.shortageRepository.GetShortage(id);
        }

        /// <summary>
        /// HTTP Post
        /// </summary>
        /// <param name="shortage">Shortage constructed from the HTML form
        /// to add to the database</param>
        public void Post([FromBody] Shortage shortage)
        {
            Shortage existingShortage = this.shortageRepository.GetShortage(shortage.Id);
            if (existingShortage != null)
            {
                existingShortage.Ndc = shortage.Ndc;
                existingShortage.Status = shortage.Status;

                this.shortageRepository.UpdateShortage(existingShortage);
            }
            else
            {
                DateTime dt = DateTime.Now;

                // Trim off the milliseconds.
                shortage.DateTime = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0);
                this.shortageRepository.AddShortage(shortage);
            }

            this.drugEntryRepository.UpdateDrugEntryStatus(shortage.Ndc, shortage.Status);
        }

        /// <summary>
        /// HTTP Delete
        /// </summary>
        /// <param name="id">id of the shortage to delete.</param>
        public void Delete(int id)
        {
            this.shortageRepository.DeleteShortage(id);
        }
    }
}
