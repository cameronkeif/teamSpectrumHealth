﻿//-----------------------------------------------------------------------
// <copyright file="DrugEntryDBContext.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System.Data.Entity;

    /// <summary>
    /// DB Context for drug entries
    /// </summary>
    public class DrugEntryDBContext : DbContext
    {
        /// <summary>
        /// Collection of all entities in the DB context
        /// </summary>
        private DbSet<DrugEntry> drugEntries;

        /// <summary>
        /// Gets or sets pending drugs
        /// </summary>
        public DbSet<DrugEntry> DrugEntries
        {
            get
            {
                return this.drugEntries;
            }

            set
            {
                this.drugEntries = value;
            }
        }
    }
}