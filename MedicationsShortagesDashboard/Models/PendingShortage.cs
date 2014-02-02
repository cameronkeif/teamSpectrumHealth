//-----------------------------------------------------------------------
// <copyright file="PendingShortage.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Class for a pending shortage that needed admin approval
    /// </summary>
    public class PendingShortage
    {
        /// <summary>
        /// Name of the drug.
        /// </summary>
        private string drugName;

        /// <summary>
        /// URL that the drug originated from
        /// </summary>
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
        /// Gets or sets the drug's name
        /// </summary>
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
    }
}