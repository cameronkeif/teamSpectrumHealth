//-----------------------------------------------------------------------
// <copyright file="WatchListItemController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
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
    }
}
