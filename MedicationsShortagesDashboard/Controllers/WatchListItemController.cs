//-----------------------------------------------------------------------
// <copyright file="WatchListItemController.cs" company="Spectrum Health">
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
    /// Performs RESTFUL requests to WatchListItemRepository
    /// </summary>
    public class WatchListItemController : ApiController
    {
        /// <summary>
        /// Performs the actual querying of the database.
        /// </summary>
        private WatchListItemRepository watchListItemRepository = new WatchListItemRepository();

        /// <summary>
        /// HTTP Get with one parameter in the query string
        /// </summary>
        /// <param name="username">Username for this user</param>
        /// <returns>Handles an HTTP GET with one parameter. Returns all watch list items matching that username</returns>
        public WatchListItem[] Get(string username)
        {
            return this.watchListItemRepository.GetWatchListItems(username);
        }

        /// <summary>
        /// HTTP Post
        /// </summary>
        /// <param name="parameters">Watch list parameters</param>
        public void Post([FromBody] string parameters)
        {
            // Note, handle this properly using routing after ALPHA.
            try
            {
                string[] split_parameters = parameters.Split('&');

                WatchListItem watchListItem = new WatchListItem(split_parameters[0], split_parameters[1]);
                this.watchListItemRepository.AddWatchListItem(watchListItem);
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// HTTP Delete
        /// </summary>
        /// <param name="username">username of the user</param>
        /// <param name="ndc">national drug code</param>
        public void Delete(string username, string ndc)
        {
            this.watchListItemRepository.DeleteWatchListItem(username, ndc);
        }
    }
}
