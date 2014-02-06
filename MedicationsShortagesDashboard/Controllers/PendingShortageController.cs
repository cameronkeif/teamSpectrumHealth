//-----------------------------------------------------------------------
// <copyright file="PendingShortageController.cs" company="Spectrum Health">
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
    /// PENDING_SHORTAGES table in the database.
    /// </summary>
    public class PendingShortageController : ApiController
    {
        /// <summary>
        /// Performs the actual querying of the database.
        /// </summary>
        private PendingShortageRepository pendingShortageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingShortageController"/> class
        /// </summary>
        public PendingShortageController()
        {
            this.pendingShortageRepository = new PendingShortageRepository();
        }

        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <returns>All of the entries in the PENDING_SHORTAGES table.</returns>
        public PendingShortage[] Get()
        {
            return this.pendingShortageRepository.GetAllContacts();
        }
    }
}
