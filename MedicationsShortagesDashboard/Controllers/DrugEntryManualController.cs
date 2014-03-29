//-----------------------------------------------------------------------
// <copyright file="DrugEntryManualController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Web.Http;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;

    /// <summary>
    /// Provides a Restful interaction between the application and the
    /// DRUGS table in the database.
    /// </summary>
    public class DrugEntryManualController : ApiController
    {
        /// <summary>
        /// Performs the actual querying of the database.
        /// </summary>
        private DrugEntryRepository drugEntryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugEntryManualController"/> class
        /// </summary>
        public DrugEntryManualController()
        {
            this.drugEntryRepository = new DrugEntryRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugEntryManualController"/> class
        /// </summary>
        /// <param name="drugEntryRepository">The database interaction layer</param>
        public DrugEntryManualController(DrugEntryRepository drugEntryRepository)
        {
            this.drugEntryRepository = drugEntryRepository;
        }

        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <returns>All of the entries in the DRUGS table.</returns>
        public DrugEntry[] Get()
        {
            return this.drugEntryRepository.GetAllDrugEntries();
        }

        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <param name="ndc">The National Drug Code of the entry</param>
        /// <returns>Drug in DRUG table with matching NDC</returns>
        public DrugEntry Get(string ndc)
        {
            return this.drugEntryRepository.GetDrug(ndc);
        }

        /// <summary>
        /// HTTP Post
        /// </summary>
        /// <param name="drugEntry">DrugEntry constructed from the HTML form
        /// to add to the database</param>
        public void Post([FromBody] DrugEntry drugEntry)
        {
            DrugEntry existingDrug = this.drugEntryRepository.GetDrug(drugEntry.NDC);
            if (existingDrug != null)
            {
                existingDrug.Dosage = drugEntry.Dosage;
                existingDrug.Brand = drugEntry.Brand;
                existingDrug.Generic = drugEntry.Generic;
                existingDrug.CurrentStatus = drugEntry.CurrentStatus;

                this.drugEntryRepository.UpdateDrug(existingDrug);
            }
            else
            {
                this.drugEntryRepository.AddDrugEntry(drugEntry);
            }
        }
    }
}