//-----------------------------------------------------------------------
// <copyright file="MessageRepository.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Services
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using MedicationsShortagesDashboard.Models;

    public class MessageRepository
    {
        /// <summary>
        /// Database context
        /// </summary>
        private MessageDBContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageRepository" /> class
        /// </summary>
        public MessageRepository()
        {
            this.db = new MessageDBContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageRepository" /> class
        /// </summary>
        /// <param name="context">A database context</param>
        public MessageRepository(MessageDBContext context)
        {
            this.db = context;
        }

        /// <summary>
        /// Gets every entry in MESSAGE
        /// </summary>
        /// <returns>An array containing all of the entries in MESSAGE</returns>
        public virtual Message[] GetAllMessages()
        {
            List<Message> messages = new List<Message>();

            foreach (Message message in this.db.Messages.ToList())
            {
                messages.Add(message);
            }

            return messages.ToArray();
        }

        /// <summary>
        /// Gets the message from the database with matching ID
        /// </summary>
        /// <param name="id">The ID of the message we're looking for.</param>
        /// <returns>The message which has id as it's ID.</returns>
        public Message GetMessage(int id)
        {
            return this.db.Messages.Find(id);
        }

        /// <summary>
        /// Add a message to the database
        /// </summary>
        /// <param name="message">The message to add to the database.</param>
        public void AddMessage(Message message)
        {
            this.db.Messages.Add(message);
            this.db.SaveChanges();
        }
    }
}