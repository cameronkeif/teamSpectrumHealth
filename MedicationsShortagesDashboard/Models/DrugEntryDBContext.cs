//-----------------------------------------------------------------------
// <copyright file="DrugEntryDBContext.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// DB Context for Pending Shortages
    /// </summary>
    public class DrugEntryDBContext : DbContext
    {
        /// <summary>
        /// Collection of all entities in the DB context
        /// </summary>
        private DbSet<DrugEntry> pendingDrugs;

        /// <summary>
        /// Gets or sets pending drugs
        /// </summary>
        [ExcludeFromCodeCoverage]
        public DbSet<DrugEntry> PendingDrugs
        {
            get
            {
                return this.pendingDrugs;
            }

            set
            {
                this.pendingDrugs = value;
            }
        }
    }
}