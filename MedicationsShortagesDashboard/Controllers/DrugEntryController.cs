//-----------------------------------------------------------------------
// <copyright file="DrugEntryController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using System.Threading.Tasks;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;
    using MedicationsShortagesDashboard.Utilities;

    /// <summary>
    /// Provides a Restful interaction between the application and the
    /// DRUGS table in the database.
    /// </summary>
    public class DrugEntryController : ApiController
    {
        /// <summary>
        /// Performs the actual querying of the database.
        /// </summary>
        private DrugEntryRepository drugEntryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugEntryController"/> class
        /// </summary>
        [ExcludeFromCodeCoverage]
        public DrugEntryController()
        {
            this.drugEntryRepository = new DrugEntryRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugEntryController"/> class
        /// </summary>
        /// <param name="drugEntryRepository">The database interaction layer</param>
        public DrugEntryController(DrugEntryRepository drugEntryRepository)
        {
            this.drugEntryRepository = drugEntryRepository;
        }

        /// <summary>
        /// Accepts data from input form in DrugEntriesList View to be parsed/input
        /// </summary>
        /// <returns>Task Response message, either OK or an error</returns
        public async Task<HttpResponseMessage> PostFormData()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                System.Diagnostics.Debug.WriteLine("UNSUPPORTED MEDIA I DONT KNOW");
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (MultipartFileData file in provider.FileData)
                {
                    DrugEntry[] drugs;
                    CSVParser parser = new CSVParser();
                    drugs = parser.ParseCSV(file.LocalFileName);

                    foreach (DrugEntry d in drugs)
                    {
                        DrugEntry existingDrugEntry = this.drugEntryRepository.GetDrugEntry(d.NDC);

                        if (existingDrugEntry != null)
                        {
                            existingDrugEntry.Dosage = d.Dosage;
                            existingDrugEntry.Brand = d.Brand;
                            existingDrugEntry.Generic = d.Generic;

                            this.drugEntryRepository.UpdateDrugEntry(existingDrugEntry);
                        }
                        else
                        {
                            this.drugEntryRepository.addDrugEntry(d);
                        }
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// HTTP Get
        /// </summary>
        /// <returns>All of the entries in the DRUGS table.</returns>
        public DrugEntry[] Get()
        {
            return this.drugEntryRepository.GetAllDrugEntries();
        }

        /// <summary>
        /// HTTP Post
        /// </summary>
        /// <param name="shortage">Shortage constructed from the HTML form
        /* to add to the database</param>
        public void Post([FromBody] DrugEntry drugEntry)
        {
            this.drugEntryRepository.addDrugEntry(drugEntry);
        }*/
    }
}
