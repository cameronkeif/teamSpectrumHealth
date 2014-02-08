//-----------------------------------------------------------------------
// <copyright file="PendingShortageDBContext.cs" company="Spectrum Health">
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
    public class PendingShortageDBContext : DbContext
    {
        /// <summary>
        /// Collection of all entities in the DB context
        /// </summary>
        private DbSet<PendingShortage> pendingShortages;

        /// <summary>
        /// Gets or sets pendingShortages
        /// </summary>
        [ExcludeFromCodeCoverage]
        public DbSet<PendingShortage> PendingShortages
        {
            get
            {
                return this.pendingShortages;
            }

            set
            {
                this.pendingShortages = value;
            }
        }
    }
}