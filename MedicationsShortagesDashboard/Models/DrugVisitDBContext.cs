//-----------------------------------------------------------------------
// <copyright file="DrugVisitDBContext.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System.Data.Entity;

    /// <summary>
    /// DB Context for drug visits
    /// </summary>
    public class DrugVisitDBContext : DbContext
    {
        /// <summary>
        /// Collection of all entities in the DB context
        /// </summary>
        private DbSet<DrugVisit> drugVisits;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugVisitDBContext"/> class
        /// </summary>
        public DrugVisitDBContext()
        {
            Database.SetInitializer<Models.DrugVisitDBContext>(null);
        }

        /// <summary>
        /// Gets or sets drug visits
        /// </summary>
        public DbSet<DrugVisit> DrugVisits
        {
            get
            {
                return this.drugVisits;
            }

            set
            {
                this.drugVisits = value;
            }
        }
    }
}