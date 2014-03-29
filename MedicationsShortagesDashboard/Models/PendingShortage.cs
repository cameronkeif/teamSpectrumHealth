//-----------------------------------------------------------------------
// <copyright file="PendingShortage.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class for a pending shortage that needed admin approval
    /// </summary>
    [Table("PENDING_SHORTAGES")]
    public class PendingShortage
    {
        /// <summary>
        /// Name of the drug.
        /// </summary>
        private string drugName;

        /// <summary>
        /// URL that the drug originated from
        /// </summary>
        private int id;

        /// <summary>
        /// Timestamp when the drug was published to the feed
        /// </summary>
        private DateTime uploadTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingShortage"/> 
        /// class.
        /// </summary>
        /// <param name="name">Name of the drug</param>
        /// <param name="id">Source id of the drug</param>
        public PendingShortage(string name, int id)
        {
            this.drugName = name;
            this.id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingShortage"/>
        /// class without parameters
        /// </summary>
        public PendingShortage()
        {
            this.drugName = string.Empty;
            this.id = -1;
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
        /// Gets or sets the source URL
        /// </summary>
        [Column("UPLOAD_TIME")]
        public DateTime UploadTime
        {
            get
            {
                return this.uploadTime;
            }

            set
            {
                this.uploadTime = value;
            }
        }

        /// <summary>
        /// Checks if two pending shortages are equal. Mostly used for unit testing.
        /// </summary>
        /// <param name="s">The other pending shortage we're checking equivalence against.</param>
        /// <returns>boolean indicating if the two pending shortages are equal.</returns>
        public bool Equals(PendingShortage s)
        {
            return this.drugName.Equals(s.DrugName) & this.id == s.Id;
        }
    }
}