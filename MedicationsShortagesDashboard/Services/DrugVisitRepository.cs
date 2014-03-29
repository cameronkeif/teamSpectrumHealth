//-----------------------------------------------------------------------
// <copyright file="DrugVisitRepository.cs" company="Spectrum Health">
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
    /// Performs database interaction with DRUG_VISIT table
    /// </summary>
    public class DrugVisitRepository
    {
        /// <summary>
        /// Database context
        /// </summary>
        private DrugVisitDBContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugVisitRepository" /> class
        /// </summary>
        public DrugVisitRepository()
        {
            this.db = new DrugVisitDBContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugVisitRepository" /> class
        /// </summary>
        /// <param name="context">A database context</param>
        public DrugVisitRepository(DrugVisitDBContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Gets every entry in DRUG_VISIT
        /// </summary>
        /// <returns>An array containing all of the entries in DRUG_VISIT</returns>
        public virtual DrugVisit[] GetAllDrugVisits()
        {
            List<DrugVisit> drugVisits = new List<DrugVisit>();

            foreach (DrugVisit drugVisit in this.db.DrugVisits.ToList())
            {
                drugVisits.Add(drugVisit);
            }

            return drugVisits.ToArray();
        }

        /// <summary>
        /// Gets the drug visit from the database with matching ID
        /// </summary>
        /// <param name="id">The Username</param>
        /// <returns>The drug visit which has id as it's ID.</returns>
        public DrugVisit[] GetDrugVisit(string id)
        {
            try
            {
                return this.db.DrugVisits.Where(visit => visit.Username == id).ToArray();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Add a message to the database
        /// </summary>
        /// <param name="drugVisit">The drug visit to add to the database.</param>
        public void AddDrugVisit(DrugVisit drugVisit)
        {
            this.db.DrugVisits.Add(drugVisit);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Updates an existing drug visit
        /// </summary>
        /// <param name="drugVisit">The drug visit to modify.</param>
        public void UpdateDrug(DrugVisit drugVisit)
        {
            this.db.Entry(drugVisit).State = EntityState.Modified;
            this.db.SaveChanges();
        }
    }
}