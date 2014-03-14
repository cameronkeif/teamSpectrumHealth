//-----------------------------------------------------------------------
// <copyright file="DrugEntry.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------
namespace MedicationsShortagesDashboard.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
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
        /// Current shortage status of this drug
        /// </summary>
        [FieldOptional]
        private string currentStatus;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugEntry"/> class
        /// </summary>
        public DrugEntry()
        {
            this.ndc = string.Empty;
            this.dosage = string.Empty;
            this.brand = string.Empty;
            this.generic = string.Empty;
            this.currentStatus = "good"; // By default, a drug has no shortages associated with it, and thus is considered 'good'
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugEntry"/> class.
        /// </summary>
        /// <param name="ndc">National Drug Code</param>
        /// <param name="dosage">Dosage of the drug</param>
        /// <param name="brand">Brand name</param>
        /// <param name="generic">Generic name</param>
        /// <param name="currentStatus">Current Status of the drug</param>
        public DrugEntry(string ndc, string dosage, string brand, string generic, string currentStatus)
        {
            this.ndc = ndc;
            this.dosage = dosage;
            this.brand = brand;
            this.generic = generic;
            this.currentStatus = currentStatus;
        }

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
        /// Gets or sets current status
        /// </summary>
        [Column("CURRENT_STATUS")]
        public string CurrentStatus
        {
            get
            {
                return this.currentStatus;
            }

            set
            {
                this.currentStatus = value;
            }
        }

        /// <summary>
        /// Returns simple string version of entry
        /// </summary>
        /// <returns>String representation of this drug</returns>
        public override string ToString()
        {
            return this.ndc + " - " + this.dosage + " - " + this.brand + " - " + this.generic + " - " + this.currentStatus;
        }
    }
}