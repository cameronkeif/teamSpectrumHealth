//-----------------------------------------------------------------------
// <copyright file="IgnoredPendingShortageController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.Web.Http;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;

    /// <summary>
    /// Performs REST interactions with the database for ignored pending shortages
    /// </summary>
    public class IgnoredPendingShortageController : ApiController
    {
        /// <summary>
        /// Performs the actual querying of the database.
        /// </summary>
        private IgnoredPendingShortageRepository ignoredPendingShortageRepository = new IgnoredPendingShortageRepository();

        /// <summary>
        /// HTTP Get with one parameter in the query string
        /// </summary>
        /// <param name="id">Username for this user</param>
        /// <returns>Handles an HTTP GET with one parameter. Returns all watch list items matching that username</returns>
        public IgnoredPendingShortage[] Get(string id)
        {
            return this.ignoredPendingShortageRepository.GetIgnoredPendingShortages(id);
        }

        /// <summary>
        /// HTTP Post
        /// </summary>
        /// <param name="ignored">The IgnoredPendingShortage to enter into the database.</param>
        public void Post([FromBody] IgnoredPendingShortage ignored)
        {
            try
            {
                this.ignoredPendingShortageRepository.AddIgnoredPendingShortage(ignored);
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// HTTP Delete
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="id"> id of the drug (found at the end of the ASHP URL</param>
        public void Delete(string username, int id)
        {
            try
            {
                this.ignoredPendingShortageRepository.RemoveIgnoredPendingShortage(username, id);
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
