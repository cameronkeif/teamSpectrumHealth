//-----------------------------------------------------------------------
// <copyright file="LoginDBContext.cs" company="Spectrum Health">
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
    public class LoginDBContext : DbContext
    {
        /// <summary>
        /// Collection of all entities in the DB context
        /// </summary>
        private DbSet<Login> logins;

        /// <summary>
        /// Gets or sets Logins
        /// </summary>
        public DbSet<Login> Logins
        {
            get
            {
                return this.logins;
            }

            set
            {
                this.logins = value;
            }
        }
    }
}