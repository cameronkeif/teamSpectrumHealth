//-----------------------------------------------------------------------
// <copyright file="ShortageRepository.cs" company="Spectrum Health">
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
    /// Used to interact with entries in the PENDING_SHORTAGES table
    /// </summary>
    public class ShortageRepository
    {
        /// <summary>
        /// Database context for shortages
        /// </summary>
        private ShortageDBContext shortageDB;

        /// <summary>
        /// Database context for drugs
        /// </summary>
        private DrugEntryRepository drugRepository = new DrugEntryRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortageRepository"/> class.
        /// </summary>
        public ShortageRepository()
        {
            this.shortageDB = new ShortageDBContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortageRepository"/> class.
        /// </summary>
        /// <param name="context">Database context</param>
        public ShortageRepository(ShortageDBContext context)
        {
            this.shortageDB = context;
        }

        /// <summary>
        /// Gets every entry in SHORTAGE
        /// </summary>
        /// <returns>An array containing all of the entries in PENDING_SHORTAGES.</returns>
        public virtual Shortage[] GetAllShortages()
        {
            List<Shortage> shortages = new List<Shortage>();

            foreach (Shortage shortage in this.shortageDB.Shortages.ToList())
            {
                shortages.Add(shortage);
            }

            return shortages.ToArray();
        }

        /// <summary>
        /// Gets the most recently posted shortage for a given National Drug Code from the database
        /// </summary>
        /// <param name="ndc">National Drug Code</param>
        /// <returns>The shortage that was most recently posted, with a matching national drug code</returns>
        public Shortage[] GetShortage(string ndc)
        {
            try
            {
                return this.shortageDB.Shortages.OrderByDescending(shortage => shortage.DateTime).Where(shortage => shortage.Ndc == ndc).ToArray();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Add a shortage to the database
        /// </summary>
        /// <param name="shortage">The shortage to add to the database.</param>
        public void AddShortage(Shortage shortage)
        {
            this.shortageDB.Shortages.Add(shortage);
            this.shortageDB.SaveChanges();
        }

        /// <summary>
        /// Delete a shortage from the database.
        /// </summary>
        /// <param name="id">Id of the shortage to remove.</param>
        public void DeleteShortage(int id)
        {
            var shortage = this.shortageDB.Shortages.First(i => i.Id == id);
            try
            {
                this.shortageDB.Shortages.Remove(shortage);
                this.shortageDB.SaveChanges();
            }
            catch (InvalidOperationException)
            {    
                return;
            }

            try
            {
                Shortage latestEntry = this.shortageDB.Shortages.First(i => i.Ndc == shortage.Ndc);
                this.drugRepository.UpdateDrugEntryStatus(latestEntry.Ndc, latestEntry.Status);
            }
            catch (InvalidOperationException)
            {
                 this.drugRepository.UpdateDrugEntryStatus(shortage.Ndc, "good");   
            }
        }

        /// <summary>
        /// Gets the shortage from the database with a matching ID.
        /// </summary>
        /// <param name="id">The ID of the shortage we're looking for.</param>
        /// <returns>The shortage which has id as it's ID.</returns>
        public Shortage GetShortage(int id)
        {
            return this.shortageDB.Shortages.Find(id);
        }
        
        /// <summary>
        /// Updates am existing shortage
        /// </summary>
        /// <param name="shortage">The shortage to modify.</param>
        public void UpdateShortage(Shortage shortage)
        {
            this.shortageDB.Entry(shortage).State = EntityState.Modified;
            this.shortageDB.SaveChanges();
        }
    } 
}