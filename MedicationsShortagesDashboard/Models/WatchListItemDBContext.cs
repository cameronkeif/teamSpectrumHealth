//-----------------------------------------------------------------------
// <copyright file="WatchListItemDBContext.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Performs database interactions with WATCHLIST_ITEM table.
    /// </summary>
    public class WatchListItemDBContext : DbContext
    {        
        /// <summary>
        /// Collection of all entities in the DB context
        /// </summary>
        private DbSet<WatchListItem> items;

        /// <summary>
        /// Gets or sets pendingShortages
        /// </summary>
        public DbSet<WatchListItem> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
            }
        }
    }
}