//-----------------------------------------------------------------------
// <copyright file="ShortageTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using System;
    using MedicationsShortagesDashboard.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for Shortage
    /// </summary>
    [TestClass]
    public class ShortageTests
    {
        /// <summary>
        /// Tests the Id property
        /// </summary>
        [TestMethod]
        public void ShortageIDGetterSetter()
        {
            Shortage s = new Shortage();
            s.Id = 2;
            Assert.AreEqual(s.Id, 2);
        }

        /// <summary>
        /// Tests the national drug code property
        /// </summary>
        [TestMethod]
        public void ShortageNDCGetterSetter()
        {
            Shortage s = new Shortage();
            s.Ndc = "111-111-1123";
            Assert.AreEqual(s.Ndc, "111-111-1123");
        }

        /// <summary>
        /// Tests the DAteTime property
        /// </summary>
        [TestMethod]
        public void ShortageDateTimeGetterSetter()
        {
            Shortage s = new Shortage();
            DateTime dt = DateTime.Now;
            s.DateTime = dt;
            Assert.AreEqual(s.DateTime, dt);
        }

        /// <summary>
        /// Tests the Status property
        /// </summary>
        [TestMethod]
        public void ShortageStatusGetterSetter()
        {
            Shortage s = new Shortage();
            s.Status = "warning";
            Assert.AreEqual(s.Status, "warning");
        }
    }
}
