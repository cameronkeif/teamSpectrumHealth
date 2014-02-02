//-----------------------------------------------------------------------
// <copyright file="RssFeedParserTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains tests for the RSS Feed Parser class.
    /// </summary>
    [TestClass]
    public class RssFeedParserTests
    {
        /// <summary>
        /// Tests a valid ASHP feed with multiple shortage entries
        /// </summary>
        [TestMethod]
        public void ASHP_WithValidFeed_MultipleEntries()
        {
            string xmlData =
                        @"<rss version='2.0'>
                            <item>
                                <title>
                                    <![CDATA[ Ciprofloxacin Injection]]>
                                </title>
                                <link>
                                    link1
                                </link>
                            </item>
                            <item>
                                <title>
                                    <![CDATA[ Hydromorphone Hydrochloride Injection ]]>
                                </title>
                                <link>
                                    link2
                                </link>
                            </item>
                            <item>
                                <title>
                                    <![CDATA[ Rifampin for Injection ]]>
                                </title>
                                <link>
                                    link3
                                </link>
                            </item>
                        </rss>";
            
            StringReader xml = new StringReader(xmlData);
            XmlReader reader = XmlReader.Create(xml);
            List<PendingShortage> results = RssFeedParser.ParseAshpFeed(reader);
            List<PendingShortage> expected = new List<PendingShortage> 
            {
                new PendingShortage("Ciprofloxacin Injection", "link1"),
                new PendingShortage("Hydromorphone Hydrochloride Injection", "link2"),
                new PendingShortage("Rifampin for Injection", "link3")
            };
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.IsTrue(results[i].Equals(expected[i]));
            }
        }

        /// <summary>
        /// Tests a valid ASHP feed with a single shortage entry
        /// </summary>
        [TestMethod]
        public void ASHP_WithValidFeed_SingleEntry()
        {
            string xmlData =
                        @"<rss version='2.0'>
                            <item>
                                <title>
                                    <![CDATA[ Ciprofloxacin Injection]]>
                                </title>
                                <link>
                                    link1
                                </link>
                            </item>
                        </rss>";
            
            StringReader xml = new StringReader(xmlData);
            XmlReader reader = XmlReader.Create(xml);
            List<PendingShortage> results = RssFeedParser.ParseAshpFeed(reader);
            
            Assert.IsTrue(results[0].Equals(new PendingShortage("Ciprofloxacin Injection", "link1")));
        }

        /// <summary>
        /// Tests parsing a well-formed XML document that does not match the
        /// same structure as the ASHP feed
        /// </summary>
        [TestMethod]
        public void ASHP_WithInvalidFeed()
        {
            string xmlData =
                @"<rss version='2.0'>
                    <item>
                        <book genre='autobiography' publicationdate='1981-03-22' ISBN='1-861003-11-0'>
                            <title>The Autobiography of Benjamin Franklin</title>
                            <author>
                                <first-name>Benjamin</first-name>
                                <last-name>Franklin</last-name>
                            </author>
                            <price>8.99</price>
                        </book>
                    </item>
                </rss>";

            StringReader xml = new StringReader(xmlData);
            XmlReader reader = XmlReader.Create(xml);
            List<PendingShortage> results = RssFeedParser.ParseAshpFeed(reader);

            Assert.IsTrue(results.Count == 0);
        }

        /// <summary>
        /// Tests an empty feed
        /// </summary>
        [TestMethod]
        public void ASHP_WithEmptyFeed()
        {
            string xmlData = string.Empty;

            StringReader xml = new StringReader(xmlData);
            XmlReader reader = XmlReader.Create(xml);
            List<PendingShortage> results = RssFeedParser.ParseAshpFeed(reader);

            Assert.IsTrue(results.Count == 0);
        }

        /// <summary>
        /// Tests a feed that is missing closing tags
        /// </summary>
        [TestMethod]
        public void ASHP_WithoutClosingTag()
        {
            string xmlData =
                        @"<rss version='2.0'>
                            <item>
                                <title>
                                    <![CDATA[ Ciprofloxacin Injection]]>
                                </title>
                                <link>
                                    link1
                                </link>
                            </item>
                            <item>
                                <title>
                                    <![CDATA[ Rifampin for Injection]]>
                                </title>
                                <link>
                                    link2
                                </link>";

            StringReader xml = new StringReader(xmlData);
            XmlReader reader = XmlReader.Create(xml);
            List<PendingShortage> results = RssFeedParser.ParseAshpFeed(reader);

            Assert.IsTrue(results[0].Equals(new PendingShortage("Ciprofloxacin Injection", "link1")));
        }
    }
}
