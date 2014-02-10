//-----------------------------------------------------------------------
// <copyright file="ShortageRepository.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Services
{
    using System.Collections.Generic;
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
        /// Gets every entry in PENDING_SHORTAGES
        /// </summary>
        /// <returns>An array containing all of the entries in PENDING_SHORTAGES</returns>
        public virtual Shortage[] GetAllShortages()
        {
            List<Shortage> shortages = new List<Shortage>();

            foreach (Shortage shortage in this.db.Shortages.ToList())
            {
                shortages.Add(shortage);
            }

            return shortages.ToArray();
        }
    } 
}