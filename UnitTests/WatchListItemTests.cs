//-----------------------------------------------------------------------
// <copyright file="WatchListItemTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using System;
    using MedicationsShortagesDashboard.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for WatchListItem
    /// </summary>
    [TestClass]
    public class WatchListItemTests
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        [TestMethod]
        public void WatchListItemDefaultConstructor()
        {
            WatchListItem w = new WatchListItem();
            Assert.IsNotNull(w);
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        [TestMethod]
        public void WatchListItemParameterizedConstructor()
        {
            WatchListItem w = new WatchListItem("Cam", "111-12332-43");
            Assert.IsTrue(w != null && w.Username.Equals("Cam") && w.Ndc.Equals("111-12332-43"));
        }

        /// <summary>
        /// Username setter
        /// </summary>
        [TestMethod]
        public void WatchListItemUsernameSetter()
        {
            WatchListItem w = new WatchListItem("Cam", "111-12332-43");
            w.Username = "BasedCam";
            Assert.AreEqual(w.Username, "BasedCam");
        }

        /// <summary>
        /// National Drug Code setter
        /// </summary>
        [TestMethod]
        public void WatchListItemNDCSetter()
        {
            WatchListItem w = new WatchListItem("Cam", "111-12332-43");
            w.Ndc = "999-12332-43";
            Assert.AreEqual(w.Ndc, "999-12332-43");
        }
    }
}
