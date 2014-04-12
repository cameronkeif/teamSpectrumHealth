//-----------------------------------------------------------------------
// <copyright file="CSVParser.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------
namespace MedicationsShortagesDashboard.Utilities
{
    using System;
    using System.Collections.Generic;
    using MedicationsShortagesDashboard.Models;

    /// <summary>
    /// CSV Parsing class, reads/parses/writes in constructor
    /// </summary>
    public class CSVParser
    {
        /// <summary>
        /// Array holding extracted drugs
        /// </summary>
        private List<DrugEntry> drugs;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVParser"/> class
        /// </summary>
        public CSVParser()
        {
        }

        /// <summary>
        /// Gets or sets the drug list
        /// </summary>
        public List<DrugEntry> Drugs
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
        public List<DrugEntry> ParseCSV(string path)
        {
            bool firstLineSkipped = false;
            string line;
            this.drugs = new List<DrugEntry>();
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (firstLineSkipped)
                {
                    line = line.Replace("\"", "");
                    string[] words = line.Split('\t');
                    DrugEntry newDrug = new DrugEntry(words[1], words[16] + words[17], words[42], words[43], words[34], "good", DateTime.Now, null);
                    this.drugs.Add(newDrug);
                }
                else
                {
                    firstLineSkipped = true;
                }
            }

            return this.drugs;
        }
    }
}