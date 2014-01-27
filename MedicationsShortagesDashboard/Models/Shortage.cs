using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MedicationsShortagesDashboard.Models
{
    /* Good means no shortage
     * Warning means below normal supply
     * Severe means there is no supply available
     */

    public enum StatusCondition { GOOD, WARNING, SEVERE }
    public class Shortage
    {
        public string drugName { get; set; }
        public StatusCondition status { get; set; }
        public string sourceURL { get; set; }

        public Shortage(string name, StatusCondition stat, string source) {
            drugName = name;
            status = stat;
            sourceURL = source;
        }
    }

    public class ShortageDbContext : DbContext
    {
        public DbSet<Shortage> Shortages { get; set; }
    }
}