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
        /// Database context
        /// </summary>
        private ShortageDBContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortageRepository"/> class.
        /// </summary>
        public ShortageRepository()
        {
            this.db = new ShortageDBContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortageRepository"/> class.
        /// </summary>
        /// <param name="context">Database context</param>
        public ShortageRepository(ShortageDBContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Gets every entry in SHORTAGE
        /// </summary>
        /// <returns>An array containing all of the entries in PENDING_SHORTAGES.</returns>
        public virtual Shortage[] GetAllShortages()
        {
            List<Shortage> shortages = new List<Shortage>();

            foreach (Shortage shortage in this.db.Shortages.ToList())
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
        public Shortage GetShortage(string ndc)
        {
            return this.db.Shortages.OrderByDescending(shortage => shortage.DateTime).First(shortage => shortage.Ndc == ndc);
        }

        /// <summary>
        /// Add a shortage to the database
        /// </summary>
        /// <param name="shortage">The shortage to add to the database.</param>
        public void AddShortage(Shortage shortage)
        {
            this.db.Shortages.Add(shortage);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Delete a shortage from the database.
        /// </summary>
        /// <param name="id">Id of the shortage to remove.</param>
        public void DeleteShortage(int id)
        {
            try
            {
                var shortage = this.db.Shortages.First(i => i.Id == id);
                this.db.Shortages.Remove(shortage);
                this.db.SaveChanges();
            }
            catch (InvalidOperationException)
            {                
            }
        }

        /// <summary>
        /// Gets the shortage from the database with a matching ID.
        /// </summary>
        /// <param name="id">The ID of the shortage we're looking for.</param>
        /// <returns>The shortage which has id as it's ID.</returns>
        public Shortage GetShortage(int id)
        {
            return this.db.Shortages.Find(id);
        }
        
        /// <summary>
        /// Updates am existing shortage
        /// </summary>
        /// <param name="shortage">The shortage to modify.</param>
        public void UpdateShortage(Shortage shortage)
        {
            this.db.Entry(shortage).State = EntityState.Modified;
            this.db.SaveChanges();
        }
    } 
}