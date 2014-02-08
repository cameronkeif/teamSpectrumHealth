//-----------------------------------------------------------------------
// <copyright file="PendingShortage.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Class for a pending shortage that needed admin approval
    /// </summary>
    [Table("PENDING_SHORTAGES")]
    public class PendingShortage
    {
        /// <summary>
        /// Name of the drug.
        /// </summary>
        [Column("DRUG_NAME")]
        private string drugName;

        /// <summary>
        /// URL that the drug originated from
        /// </summary>
        [Column("SOURCE_URL")]
        private string sourceURL;

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingShortage"/> 
        /// class.
        /// </summary>
        /// <param name="name">Name of the drug</param>
        /// <param name="source">Source URL of the drug</param>
        public PendingShortage(string name, string source)
        {
            this.drugName = name;
            this.sourceURL = source;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingShortage"/>
        /// class without parameters
        /// </summary>
        public PendingShortage()
        {
            this.drugName = string.Empty;
            this.sourceURL = string.Empty;
        }

        /// <summary>
        /// Gets or sets the drug's name
        /// </summary>
        [Column("DRUG_NAME")]
        public string DrugName
        {
            get
            {
                return this.drugName;
            }

            set
            {
                this.drugName = value;
            }
        }

        /// <summary>
        /// Gets or sets the source URL
        /// </summary>
        [Key]
        [Column("SOURCE_URL")]
        public string SourceURL
        {
            get
            {
                return this.sourceURL;
            }

            set
            {
                this.sourceURL = value;
            }
        }

        /// <summary>
        /// Checks if two pending shortages are equal. Mostly used for unit testing.
        /// </summary>
        /// <param name="s">The other pending shortage we're checking equivalence against.</param>
        /// <returns>boolean indicating if the two pending shortages are equal.</returns>
        public bool Equals(PendingShortage s)
        {
            return this.drugName.Equals(s.DrugName) & this.sourceURL.Equals(s.SourceURL);
        }
    }
}