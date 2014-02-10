//-----------------------------------------------------------------------
// <copyright file="ShortageDBContext.cs" company="Spectrum Health">
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
    public class ShortageDBContext : DbContext
    {
        /// <summary>
        /// Collection of all entities in the DB context
        /// </summary>
        private DbSet<Shortage> shortages;

        /// <summary>
        /// Gets or sets pendingShortages
        /// </summary>
        [ExcludeFromCodeCoverage]
        public DbSet<Shortage> Shortages
        {
            get
            {
                return this.shortages;
            }

            set
            {
                this.shortages = value;
            }
        }
    }
}