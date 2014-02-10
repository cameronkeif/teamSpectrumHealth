//-----------------------------------------------------------------------
// <copyright file="UserDBContext.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// DB Context for Users
    /// </summary>
    public class UserDBContext : DbContext
    {
        /// <summary>
        /// Collection of all entities in the DB context
        /// </summary>
        private DbSet<User> user;

        /// <summary>
        /// Gets or sets user
        /// </summary>
        [ExcludeFromCodeCoverage]
        public DbSet<User> User
        {
            get
            {
                return this.user;
            }

            set
            {
                this.user = value;
            }
        }
    }
}