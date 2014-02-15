//-----------------------------------------------------------------------
// <copyright file="CSVParser.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using FileHelpers;
    using MedicationsShortagesDashboard.Models;

    /// <summary>
    /// CSV Parsing class, reads/parses/writes in constructor
    /// </summary>
    public class CSVParser
    {
        /// <summary>
        /// Engine used to parse CSV file
        /// </summary>
        private FileHelperEngine engine;

        /// <summary>
        /// Array holding extracted drugs
        /// </summary>
        private DrugEntry[] drugs;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVParser"/> class
        /// </summary>
        /// <returns>nothing</returns>
        public CSVParser()
        {
            this.engine = new FileHelperEngine(typeof(DrugEntry));
            this.drugs = this.engine.ReadFile(HttpContext.Current.Server.MapPath("/Data") + "/TestCSV.csv") as DrugEntry[];
            this.engine.WriteFile("OutCSV.txt", this.drugs);
        }

        /// <summary>
        /// Gets or sets the drug list
        /// </summary>
        public DrugEntry[] Drugs
        {
            get
            {
                return this.drugs;
            }

            set
            {
                this.drugs = value;
            }
        }
    }
}