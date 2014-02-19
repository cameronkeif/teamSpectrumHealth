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
    using System.Data;

    /// <summary>
    /// Used to select entries in the DRUGS table
    /// </summary>
    public class DrugEntryRepository
    {
        /// <summary>
        /// Database context
        /// </summary>
        private DrugEntryDBContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugEntryRepository" /> class
        /// </summary>
        public DrugEntryRepository()
        {
            this.db = new DrugEntryDBContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugEntryRepository" /> class
        /// </summary>
        /// <param name="context">A database context</param>
        public DrugEntryRepository(DrugEntryDBContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Gets every entry in DRUGS
        /// </summary>
        /// <returns>An array containing all of the entries in DRUGS</returns>
        public virtual DrugEntry[] GetAllDrugEntries()
        {
            List<DrugEntry> drugEntries = new List<DrugEntry>();

            foreach (DrugEntry drugEntry in this.db.DrugEntries.ToList())
            {
                drugEntries.Add(drugEntry);
                System.Diagnostics.Debug.WriteLine("DRUG: " + drugEntry.NDC);
            }

            return drugEntries.ToArray();
        }

        /// <summary>
        /// Gets the shortage from the database with a matching ID.
        /// </summary>
        /// <param name="ndc">The ID of the shortage we're looking for.</param>
        /// <returns>The shortage which has id as it's ID.</returns>
        public DrugEntry GetDrug(string ndc)
        {
            return this.db.DrugEntries.Find(ndc);
        }

        /// <summary>
        /// Add a drug entry to the database
        /// </summary>
        /// <param name="drugEntry">The drug entry to add to the database.</param>
        public void AddDrugEntry(DrugEntry drugEntry)
        {
            this.db.DrugEntries.Add(drugEntry);
            this.db.SaveChanges();
        }

        public void UpdateDrugEntryStatus(string ndc, string status)
        {
            DrugEntry d = this.db.DrugEntries.Find(ndc);
            if (d != null)
            {
                d.CurrentStatus = status;
                this.db.Entry(d).State = EntityState.Modified;
                this.db.SaveChanges();
            }
        }
    }
}