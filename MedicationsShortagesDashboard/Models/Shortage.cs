//-----------------------------------------------------------------------
// <copyright file="Shortage.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class representing a drug shortage.
    /// </summary>
    [Table("SHORTAGE")]
    public class Shortage
    {
        /// <summary>
        /// ID of the shortage
        /// </summary>
        private int id;

        /// <summary>
        /// ID of the drug which is referenced in this shortage
        /// </summary>
        private string ndc;

        /// <summary>
        /// Timestamp of when the shortage was posted
        /// </summary>
        private DateTime dateTime;

        /// <summary>
        /// Status of the shortage as assigned by pharmacist admin (good, warning, severe)
        /// </summary>
        private string status;

        /// <summary>
        /// Gets or sets id
        /// </summary>
        [Key]
        [Column("ID")]
        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets drugId
        /// </summary>
        [Column("NDC")]
        public string Ndc
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
        /// Gets or sets dateTime
        /// </summary>
        [Column("DATETIME")]
        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }

            set
            {
                this.dateTime = value;
            }
        }

        /// <summary>
        /// Gets or sets status
        /// </summary>
        [Column("STATUS")]
        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }
    }
}