using MedicationsShortagesDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace MedicationsShortagesDashboard.Utilities
{
    public class rssFeedParser
    {
        public static List<Shortage> parseAshpFeed(string URL, StatusCondition status)
        {
            XmlReader reader = XmlReader.Create(URL); // Creates an XML reader from the given ASHP URL
            List<Shortage> shortages = new List<Shortage>();
            String drugName = String.Empty; // Used to keep track of the drug name for the entry being parsed

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
                        drugName = reader.ReadElementContentAsString().Replace("Shortage Bulletin", String.Empty);
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