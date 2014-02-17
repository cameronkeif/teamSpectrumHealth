//-----------------------------------------------------------------------
// <copyright file="DrugEntry.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using FileHelpers;

    /// <summary>
    /// Class used to define a CSV entry
    /// </summary>
    [DelimitedRecord(",")]
    [Table("DRUGS")]
    public class DrugEntry
    {
        /// <summary>
        /// National Drug Code
        /// </summary>
        private string ndc;

        /// <summary>
        /// Drug Dosage
        /// </summary>
        private string dosage;

        /// <summary>
        /// Brand name
        /// </summary>
        private string brand;

        /// <summary>
        /// Generic name
        /// </summary>
        private string generic;

        /// <summary>
        /// Gets or sets the NDC
        /// </summary>
        [Key]
        [Column("NDC")]
        public string NDC
        {
            get
            {
                return this.ndc;
            }

            set
            {
                this.ndc = value;
            }
        }

        /// <summary>
        /// Gets or sets the dosage
        /// </summary>
        [Column("DOSAGE")]
        public string Dosage
        {
            get
            {
                return this.dosage;
            }

            set
            {
                this.dosage = value;
            }
        }

        /// <summary>
        /// Gets or sets the brand name
        /// </summary>
        [Column("BRAND_NAME")]
        public string Brand
        {
            get
            {
                return this.brand;
            }

            set
            {
                this.brand = value;
            }
        }

        /// <summary>
        /// Gets or sets the generic name
        /// </summary>
        [Column("GENERIC_NAME")]
        public string Generic
        {
            get
            {
                return this.generic;
            }

            set
            {
                this.generic = value;
            }
        }

        /// <summary>
        /// Returns simple string version of entry
        /// </summary>
        public string toString()
        {
            return this.ndc + " - " + this.dosage + " - " + this.brand + " - " + this.generic;
        }
    }
}