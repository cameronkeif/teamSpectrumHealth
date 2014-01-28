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
            XmlReader reader = XmlReader.Create(URL);
            List<Shortage> shortages = new List<Shortage>();
            String tag = String.Empty, link = String.Empty, drugName = String.Empty;

            //TODO clean up this. I think it can be made better -CK
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        tag = reader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (tag.Equals("category"))
                        {
                            drugName = reader.Value.Replace("Shortage Bulletin", String.Empty);
                        }
                        if (tag.Equals("link"))
                        {
                            // The top of the feed also contains links. Need to ensure these links are actually for drug shortage information
                            if (!String.IsNullOrEmpty(drugName))
                            {
                                shortages.Add(new Shortage(drugName, status, reader.Value));
                            }
                        }
                        break;
                }
            }

            return shortages;
        }
    }
}