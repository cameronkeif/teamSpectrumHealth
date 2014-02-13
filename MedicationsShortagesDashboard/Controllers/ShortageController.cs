//-----------------------------------------------------------------------
// <copyright file="ShortageController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Http;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;

    /// <summary>
    /// Provides a Restful interaction between the application and the
    /// SHORTAGES table in the database.
    /// </summary>
    public class ShortageController : ApiController
    {
        /// <summary>
        /// Performs the actual querying of the database.
        /// </summary>
        private ShortageRepository shortageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortageController"/> class
        /// </summary>
        [ExcludeFromCodeCoverage]
        public ShortageController()
        {
            this.shortageRepository = new ShortageRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortageController"/> class
        /// </summary>
        /// <param name="shortageRepository">The database interaction layer</param>
        public ShortageController(ShortageRepository shortageRepository)
        {
            this.shortageRepository = shortageRepository;
        }

        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <returns>All of the entries in the SHORTAGE table.</returns>
        public Shortage[] Get()
        {
            return this.shortageRepository.GetAllShortages();
        }

        /// <summary>
        /// HTTP Post
        /// </summary>
        /// <param name="shortage">Shortage constructed from the HTML form
        /// to add to the database</param>
        public void Post([FromBody] Shortage shortage)
        {
            this.shortageRepository.AddShortage(shortage);
        }

        /// <summary>
        /// HTTP Delete
        /// </summary>
        /// <param name="id">id of the shortage to delete.</param>
        public void Delete(int id)
        {
            this.shortageRepository.DeleteShortage(id);
        }

        public void Put(int id, Shortage shortage)
        {
            int i = 0;
            i++;
        }
    }
}
