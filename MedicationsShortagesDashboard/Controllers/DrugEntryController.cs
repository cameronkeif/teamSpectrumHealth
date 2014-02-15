//-----------------------------------------------------------------------
// <copyright file="DrugEntryController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Web.Http;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Provides a Restful interaction between the application and the
    /// DRUGS table in the database.
    /// </summary>
    public class DrugEntryController : ApiController
    {
        /// <summary>
        /// Performs the actual querying of the database.
        /// </summary>
        private DrugEntryRepository drugEntryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugEntryController"/> class
        /// </summary>
        [ExcludeFromCodeCoverage]
        public DrugEntryController()
        {
            this.drugEntryRepository = new DrugEntryRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugEntryController"/> class
        /// </summary>
        /// <param name="drugEntryRepository">The database interaction layer</param>
        public DrugEntryController(DrugEntryRepository drugEntryRepository)
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
        /// HTTP Post
        /// </summary>
        /// <param name="shortage">Shortage constructed from the HTML form
        /// to add to the database</param>
        public void Post([FromBody] DrugEntry drugEntry)
        {
            this.drugEntryRepository.addDrugEntry(drugEntry);
        }
    }
}
