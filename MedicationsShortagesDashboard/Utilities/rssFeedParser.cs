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
        /// <param name="url">The URL of the feed</param>
        /// <param name="status">The status condition for the entries in this feed.</param>
        /// <returns>A list of Shortages generated from the feed</returns>
        public static List<Shortage> ParseAshpFeed(string url, StatusCondition status)
        {
            XmlReader reader = XmlReader.Create(url); // Creates an XML reader from the given ASHP URL
            List<Shortage> shortages = new List<Shortage>();
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
                        drugName = reader.ReadElementContentAsString().Replace("Shortage Bulletin", string.Empty);
                    }

                    // Source URL of the drug shortage.
                    if (reader.Name.Equals("link"))
                    {
                        shortages.Add(new Shortage(drugName, status, reader.ReadElementContentAsString()));
                    }                                       
                }
            }

            return shortages;        
        }    
    }
}