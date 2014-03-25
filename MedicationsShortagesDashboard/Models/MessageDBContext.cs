//-----------------------------------------------------------------------
// <copyright file="MessageDBContext.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Models
{
    using System.Data.Entity;

    /// <summary>
    /// DB Context for messages
    /// </summary>
    public class MessageDBContext : DbContext
    {
        /// <summary>
        /// Collection of all entities in the DB context
        /// </summary>
        private DbSet<Message> messages;

        public MessageDBContext()
        {
            Database.SetInitializer<Models.MessageDBContext>(null);
        }

        /// <summary>
        /// Gets or sets messages
        /// </summary>
        public DbSet<Message> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }
    }
}