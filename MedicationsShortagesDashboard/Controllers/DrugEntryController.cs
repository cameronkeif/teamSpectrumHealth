﻿//-----------------------------------------------------------------------
// <copyright file="DrugEntryController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
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
        /// Accepts file from file browser
        /// </summary>
        /// <returns>Task Response message, either OK or an error</returns>
        public async Task<HttpResponseMessage> PostFormData()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new System.Exception("Unsupported file type for input .CSV file!");
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (MultipartFileData file in provider.FileData)
                {
                    List<DrugEntry> drugs;
                    CSVParser parser = new CSVParser();
                    drugs = parser.ParseCSV(file.LocalFileName);

                    foreach (DrugEntry d in drugs)
                    {
                        DrugEntry existingDrug = this.drugEntryRepository.GetDrug(d.NDC);
                        if (existingDrug != null)
                        {
                            existingDrug.Dosage = d.Dosage;
                            existingDrug.Brand = d.Brand;
                            existingDrug.Generic = d.Generic;
                            existingDrug.Description = d.Description;

                            this.drugEntryRepository.UpdateDrug(existingDrug);
                        }
                        else
                        {
                            this.drugEntryRepository.AddDrugEntry(d);
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
        /// HTTP Get
        /// </summary>
        /// <param name="ndc">The National Drug Code of the entry</param>
        /// <returns>All of the entries in the DRUGS table.</returns>
        public DrugEntry Get(string ndc)
        {
            return this.drugEntryRepository.GetDrug(ndc);
        }
    }
}
