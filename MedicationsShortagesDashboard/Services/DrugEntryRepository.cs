//-----------------------------------------------------------------------
// <copyright file="DrugEntryRepository.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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

            foreach (DrugEntry drugEntry in db.DrugEntries.ToList())
            {
                drugEntries.Add(drugEntry);
                System.Diagnostics.Debug.WriteLine("DRUG: " + drugEntry.NDC);
            }

            return drugEntries.ToArray();
        }

        /// <summary>
        /// Add a drug entry to the database
        /// </summary>
        /// <param name="drugEntry">The drug entry to add to the database.</param>
        public void addDrugEntry(DrugEntry drugEntry)
        {
            this.db.DrugEntries.Add(drugEntry);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Gets the drug entry from the database with a matching ID.
        /// </summary>
        /// <param name="id">The ID of the drug entry we're looking for.</param>
        /// <returns>The drug entry which has id as it's ID.</returns>
        public DrugEntry GetDrugEntry(string ndc)
        {
            return this.db.DrugEntries.Find(ndc);
        }

        /// <summary>
        /// Updates an existing drug entry
        /// </summary>
        /// <param name="shortage">The drug entry to modify.</param>
        public void UpdateDrugEntry(DrugEntry drugEntry)
        {
            this.db.Entry(drugEntry).State = EntityState.Modified;
            this.db.SaveChanges();
        }
    }
}