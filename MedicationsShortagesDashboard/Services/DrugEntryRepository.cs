//-----------------------------------------------------------------------
// <copyright file="DrugEntryRepository.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using MedicationsShortagesDashboard.Models;

    /// <summary>
    /// Used to select entries in the DRUGS table
    /// </summary>
    public class DrugEntryRepository
    {
        private DrugEntryDBContext db;

        public DrugEntryRepository()
        {
            this.db = new DrugEntryDBContext();
        }

        public DrugEntryRepository(DrugEntryDBContext dbContext)
        {
            this.db = dbContext;
        }

        /// <summary>
        /// Gets every entry in DRUGS
        /// </summary>
        /// <returns>An array containing all of the entries in DRUGS</returns>
        public virtual DrugEntry[] GetAllDrugEntries()
        {
            List<DrugEntry> drugEntries = new List<DrugEntry>();

            foreach (DrugEntry drugEntry in db.PendingDrugs.ToList())
            {
                drugEntries.Add(drugEntry);
            }

            return drugEntries.ToArray();
        }
    }
}