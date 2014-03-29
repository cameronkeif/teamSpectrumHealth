//-----------------------------------------------------------------------
// <copyright file="DrugVisitController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Web.Http;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;

    /// <summary>
    /// API Controller for DrugVisit
    /// </summary>
    public class DrugVisitController : ApiController
    {
        /// <summary>
        /// Performs the actual querying of the drug visit database.
        /// </summary>
        private DrugVisitRepository drugVisitRepository;

        /// <summary>
        /// Performs the actual querying of the drug entry database.
        /// </summary>
        private DrugEntryRepository drugEntryRepository;

        /// <summary>
        /// Performs the actual querying of the login database.
        /// </summary>
        private LoginRepository loginRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugVisitController"/> class
        /// </summary>
        public DrugVisitController()
        {
            this.drugVisitRepository = new DrugVisitRepository();
            this.drugEntryRepository = new DrugEntryRepository();
            this.loginRepository = new LoginRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugVisitController"/> class
        /// </summary>
        /// <param name="drugVisitRepository">The database interaction layer</param>
        public DrugVisitController(DrugVisitRepository drugVisitRepository)
        {
            this.drugVisitRepository = drugVisitRepository;
        }

        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <returns>All of the entries in the DRUG_VISIT table.</returns>
        public DrugVisit[] Get()
        {
            return this.drugVisitRepository.GetAllDrugVisits();
        }

        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <param name="id">Username of the user</param>
        /// <returns>Drug Visit with matching ID, if any</returns>
        public DrugVisit[] Get(string id)
        {
            return this.drugVisitRepository.GetDrugVisit(id);
        }

        /// <summary>
        /// HTTP Post
        /// </summary>
        /// <param name="drugVisit">Drug Visit created from HTML form
        /// to add to the database</param>
        public void Post([FromBody] DrugVisit drugVisit)
        {
            System.Diagnostics.Debug.WriteLine(drugVisit.Username + " - " + drugVisit.NDC);

            DrugVisit previousVisit = null;
            foreach (DrugVisit dv in this.drugVisitRepository.GetAllDrugVisits())
            {
                if (dv.NDC == drugVisit.NDC && dv.Username == drugVisit.Username)
                {
                    previousVisit = dv;
                }
            }

            if (previousVisit != null)
            {
                DrugVisit updatedVisit = previousVisit;
                updatedVisit.Date = DateTime.Now;
                this.drugVisitRepository.UpdateDrug(updatedVisit);
            }
            else
            {
                DrugVisit firstVisit = new DrugVisit();
                firstVisit.Username = drugVisit.Username;
                firstVisit.NDC = drugVisit.NDC;
                firstVisit.Date = DateTime.Now;
                this.drugVisitRepository.AddDrugVisit(firstVisit);
            }
        }
    }
}