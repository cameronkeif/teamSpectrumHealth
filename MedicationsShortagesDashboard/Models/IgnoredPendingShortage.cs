//-----------------------------------------------------------------------
// <copyright file="IgnoredPendingShortage.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Pending shortages from the ASHP feed that a user puts on their
    /// ignore list.
    /// </summary>
    [Table("IGNORED_PENDING_SHORTAGES")]
    public class IgnoredPendingShortage
    {
        /// <summary>
        /// The user's username.
        /// </summary>
        private string username;

        /// <summary>
        /// The source URL of the pending shortage the user is ignoring.
        /// </summary>
        private string sourceUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoredPendingShortage"/> class.
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <param name="sourceUrl">The source URL</param>
        public IgnoredPendingShortage(string username, string sourceUrl)
        {
            this.username = username;
            this.sourceUrl = sourceUrl;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnoredPendingShortage"/> class.
        /// </summary>
        public IgnoredPendingShortage()
        {
            this.username = string.Empty;
            this.sourceUrl = string.Empty;
        }

        /// <summary>
        /// Gets or sets username
        /// </summary>
        [Key]
        [Column("USERNAME", Order = 1)]
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
        /// Gets or sets sourceUrl
        /// </summary>
        [Key]
        [Column("SOURCE_URL", Order = 0)]
        public string SourceUrl
        {
            get
            {
                return this.sourceUrl;
            }

            set
            {
                this.sourceUrl = value;
            }
        }
    }
}