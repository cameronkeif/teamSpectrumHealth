//-----------------------------------------------------------------------
// <copyright file="IgnoredPendingShortageDBContext.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System.Data.Entity;

    /// <summary>
    /// Performs database interactions with IGNORED_PENDING_SHORTAGES table.
    /// </summary>
    public class IgnoredPendingShortageDBContext : DbContext
    {
        /// <summary>
        /// Collection of all entities in the DB context
        /// </summary>
        private DbSet<IgnoredPendingShortage> ignoredPendingShortages;

        /// <summary>
        /// Gets or sets items
        /// </summary>
        public DbSet<IgnoredPendingShortage> IgnoredPendingShortages
        {
            get
            {
                return this.ignoredPendingShortages;
            }

            set
            {
                this.ignoredPendingShortages = value;
            }
        }
    }
}