//-----------------------------------------------------------------------
// <copyright file="RssFeedParser.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------
namespace MedicationsShortagesDashboard.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Xml;
    using MedicationsShortagesDashboard.Models;

    /// <summary>
    /// RSS feed parsing class
    /// </summary>
    public class RssFeedParser
    {
        /// <summary>
        /// Parses the ASHP RSS feed
        /// </summary>
        /// <param name="reader">The XML reader containing the XML to parse.</param>
        /// <returns>A list of Shortages generated from the feed</returns>
        public static List<PendingShortage> ParseAshpFeed(XmlReader reader)
        {
            List<PendingShortage> shortages = new List<PendingShortage>();
            string drugName = string.Empty; // Used to keep track of the drug name for the entry being parsed

            // Each drug shortage is listed under the <item> tag.
            // Move to first <item>
            reader.ReadToFollowing("item");
            while (reader.Read())
            {
                if (reader.NodeType.Equals(XmlNodeType.Element))
                {
                    // Name of the drug
                    if (reader.Name.Equals("title"))
                    {
                        // Need to hang on to this, don't have URL yet...
                        drugName = reader.ReadElementContentAsString();
                    }

                    // Source URL of the drug shortage.
                    if (reader.Name.Equals("link"))
                    {
                        shortages.Add(new PendingShortage(drugName, reader.ReadElementContentAsString()));
                    }                                       
                }
            }

            return shortages;        
        }    
    }
}