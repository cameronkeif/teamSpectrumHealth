//-----------------------------------------------------------------------
// <copyright file="DrugVisit.cs" company="Spectrum Health">
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
    /// Class used to define a message/post
    /// </summary>
    [Table("DRUG_VISIT")]
    public class DrugVisit
    {
        /// <summary>
        /// Unique ID of message
        /// </summary>
        private int id;

        /// <summary>
        /// User who posted message
        /// Foreign key to USER's Username
        /// </summary>
        private string username;

        /// <summary>
        /// National Drug Code
        /// Foreign key to DRUGS' NDC
        /// </summary>
        private string ndc;

        /// <summary>
        /// Time posted
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Gets or sets ID
        /// </summary>
        [Key]
        [Column("ID")]
        public int ID
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
        /// Gets or sets username of poster
        /// </summary>
        [Column("USERNAME")]
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
            }
        }

        /// <summary>
        /// Gets or sets NDC
        /// </summary>
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
        /// Gets or sets posted date of message
        /// </summary>
        [Column("DATE")]
        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
            }
        }
    }
}