//-----------------------------------------------------------------------
// <copyright file="WatchListItem.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Association between user and drug which indicates the user has added the drug to their watch list
    /// </summary>   
    [Table("WATCHLIST_ITEM")]
    public class WatchListItem
    {
        /// <summary>
        /// Username of the user who added this drug to their watch list.
        /// </summary>
        private string username;

        /// <summary>
        /// National Drug Code of the drug which is being added to the watch list.
        /// </summary>
        private string ndc;

        /// <summary>
        /// Gets or sets username
        /// </summary>
        [Key]
        [Column("USERNAME", Order = 0)]
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
        /// Gets or sets the National Drug Code.
        /// </summary>
        [Key]
        [Column("NDC", Order = 1)]
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
    }
}