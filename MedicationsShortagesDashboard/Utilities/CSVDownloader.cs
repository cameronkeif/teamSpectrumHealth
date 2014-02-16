//-----------------------------------------------------------------------
// <copyright file="CSVDownloader.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------
namespace MedicationsShortagesDashboard.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using FileHelpers;
    using MedicationsShortagesDashboard.Models;

    /// <summary>
    /// CSV Downloading class, grabs submitted file and sets to parse
    /// </summary>
    public class CSVDownloader
    {
        public CSVDownloader()
        {
            
        }

        public void DownloadCSV(HttpRequestBase Request)
        {
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload] == null || Request.Files[upload].ContentLength <= 0) continue;
                string path = AppDomain.CurrentDomain.BaseDirectory + "uploads\\";
                string filename = Path.GetFileName(Request.Files[upload].FileName);
                Request.Files[upload].SaveAs(Path.Combine(path, filename));

                CSVParser parser = new CSVParser();
                parser.ParseCSV(Path.Combine(path, filename).ToString());
            }
        }
    }
}