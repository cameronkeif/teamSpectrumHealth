//-----------------------------------------------------------------------
// <copyright file="MessageController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Web.Http;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;

    public class MessageController : ApiController
    {
        /// <summary>
        /// Performs the actual querying of the database.
        /// </summary>
        private MessageRepository messageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageController"/> class
        /// </summary>
        public MessageController()
        {
            this.messageRepository = new MessageRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageController"/> class
        /// </summary>
        /// <param name="messageRepository">The database interaction layer</param>
        public MessageController(MessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <returns>All of the entries in the MESSAGE table.</returns>
        public Message[] Get()
        {
            return this.messageRepository.GetAllMessages();
        }

        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <param name="ndc">Unique ID of a specific message</param>
        /// <returns>All of the entries in the MESSAGE table.</returns>
        public Message Get(int id)
        {
            return this.messageRepository.GetMessage(id);
        }

        /// <summary>
        /// HTTP Post
        /// </summary>
        /// <param name="drugEntry">Message created from HTML form
        /// to add to the database</param>
        public void Post([FromBody] Message message)
        {
            ModelState.Clear();
            Message existingMessage = this.messageRepository.GetMessage(message.ID);
            if (existingMessage != null)
            {
                // Probably just throw error
            }
            else if (message == null)
            {
                System.Diagnostics.Debug.WriteLine("MESSAGE IS NULL, IDIOT");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("MESSAGE POSTING: " + message.Text);
                //this.messageRepository.AddMessage(message);
            }
        }
    }
}
