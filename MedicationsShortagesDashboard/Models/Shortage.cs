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
        /// The seven day supply of the drug.
        /// </summary>
        private string sevenDaySupply;

        /// <summary>
        /// The expected usage of the drug over the next seven days.
        /// </summary>
        private string sevenDayUsage;

        /// <summary>
        /// Actions to be taken to mitigate the shortage.
        /// </summary>
        private string mitigationActions;

        /// <summary>
        /// The grey market vendor of this drug.
        /// </summary>
        private string greyMarketVendor;

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

        /// <summary>
        /// Gets or sets sevenDaySupply
        /// </summary>
        [Column("SEVEN_DAY_SUPPLY")]
        public string SevenDaySupply
        {
            get
            {
                return this.sevenDaySupply;
            }

            set
            {
                this.sevenDaySupply = value;
            }
        }

        /// <summary>
        /// Gets or sets sevenDayUsage
        /// </summary>
        [Column("SEVEN_DAY_USAGE")]
        public string SevenDayUsage
        {
            get
            {
                return this.sevenDayUsage;
            }

            set
            {
                this.sevenDayUsage = value;
            }
        }

        /// <summary>
        /// Gets or sets mitigationActions
        /// </summary>
        [Column("MITIGATION_ACTIONS")]
        public string MitigationActions
        {
            get
            {
                return this.mitigationActions;
            }

            set
            {
                this.mitigationActions = value;
            }
        }

        /// <summary>
        /// Gets or sets greyMarketVendor
        /// </summary>
        [Column("GREY_MARKET_VENDOR")]
        public string GreyMarketVendor
        {
            get
            {
                return this.greyMarketVendor;
            }

            set
            {
                this.greyMarketVendor = value;
            }
        }
    }
}