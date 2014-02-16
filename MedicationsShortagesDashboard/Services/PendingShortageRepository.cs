//-----------------------------------------------------------------------
// <copyright file="PendingShortageRepository.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using MedicationsShortagesDashboard.Models;

    /// <summary>
    /// Used to select entries in the PENDING_SHORTAGES table
    /// </summary>
    public class PendingShortageRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private PendingShortageDBContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingShortageRepository"/> class
        /// </summary>
        public PendingShortageRepository()
        {
            this.db = new PendingShortageDBContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingShortageRepository"/> class
        /// </summary>
        /// <param name="context">A database context to interface with</param>
        public PendingShortageRepository(PendingShortageDBContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Gets every entry in PENDING_SHORTAGES
        /// </summary>
        /// <returns>An array containing all of the entries in PENDING_SHORTAGES</returns>
        public virtual PendingShortage[] GetAllPendingShortages()
        {
            List<PendingShortage> pendingShortages = new List<PendingShortage>();

            foreach (PendingShortage pendingShortage in this.db.PendingShortages.ToList())
            {
                pendingShortages.Add(pendingShortage);
            }

            return pendingShortages.ToArray();
        }
    }
}