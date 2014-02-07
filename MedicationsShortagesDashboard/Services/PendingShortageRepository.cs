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
        /// Gets every entry in PENDING_SHORTAGES
        /// </summary>
        /// <returns>An array containing all of the entries in PENDING_SHORTAGES</returns>
        public PendingShortage[] GetAllPendingShortages()
        {
            PendingShortageDBContext db = new PendingShortageDBContext();
            List<PendingShortage> pendingShortages = new List<PendingShortage>();

            foreach (PendingShortage pendingShortage in db.PendingShortages.ToList())
            {
                pendingShortages.Add(pendingShortage);
            }

            return pendingShortages.ToArray();
        }
    }
}