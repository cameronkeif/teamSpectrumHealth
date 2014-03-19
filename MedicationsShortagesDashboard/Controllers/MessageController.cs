//-----------------------------------------------------------------------
// <copyright file="MessageController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Web.Http;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;

    public class MessageController : ApiController
    {
        /// <summary>
        /// Performs the actual querying of the message database.
        /// </summary>
        private MessageRepository messageRepository;

        /// <summary>
        /// Performs the actual querying of the drug entry database.
        /// </summary>
        private DrugEntryRepository drugEntryRepository;

        /// <summary>
        /// Performs the actual querying of the login database.
        /// </summary>
        private LoginRepository loginRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageController"/> class
        /// </summary>
        public MessageController()
        {
            this.messageRepository = new MessageRepository();
            this.drugEntryRepository = new DrugEntryRepository();
            this.loginRepository = new LoginRepository();
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
        /// <param name="id">Unique ID of a specific message</param>
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
                throw new System.Exception("Message exists in table MESSAGE with same ID");
            }
            // Manually check if necessary foreign keys exist in DB
            // DRUGS.NDC, USER.USERNAME
            else
            {
                if (this.drugEntryRepository.GetDrug(message.NDC) == null)
                {
                    throw new System.Exception("Drug " + message.NDC + " does not exist in database");
                }
                else if (this.loginRepository.GetLogin(message.User) == null)
                {
                    throw new System.Exception("User " + message.User + " does not exist in database");
                }
                else
                {
                    Message newMessage = new Message();

                    DateTime dt = DateTime.Now;

                    // Trim off the milliseconds.
                    newMessage.Date = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0);
                    newMessage.NDC = message.NDC;
                    newMessage.Text = message.Text;
                    newMessage.User = message.User;

                    this.messageRepository.AddMessage(newMessage);
                }
            }
        }

        public void GetMessageInfo(string NDC, string Text)
        {
            System.Diagnostics.Debug.WriteLine(NDC + " - " + Text);
        }
    }
}
