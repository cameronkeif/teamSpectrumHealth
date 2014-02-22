//-----------------------------------------------------------------------
// <copyright file="CSVParser.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------
namespace MedicationsShortagesDashboard.Utilities
{
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
        public CSVParser()
        {
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

        /// <summary>
        /// Parses a CSV file
        /// </summary>
        /// <param name="path">The path to the .csv file</param>
        /// <returns>Array of drug entries constructed from the csv file.</returns>
        public DrugEntry[] ParseCSV(string path)
        {
            this.engine = new FileHelperEngine(typeof(DrugEntry));
            this.drugs = this.engine.ReadFile(path) as DrugEntry[];

            // this.engine.WriteFile("OutCSV.txt", this.drugs);
            foreach (DrugEntry d in this.drugs)
            {
                System.Diagnostics.Debug.WriteLine(d.ToString());
            }

            return this.drugs;
        }
    }
}