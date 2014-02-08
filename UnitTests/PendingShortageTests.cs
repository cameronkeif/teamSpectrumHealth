//-----------------------------------------------------------------------
// <copyright file="PendingShortageTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using MedicationsShortagesDashboard.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests functionality of the PendingShortage class
    /// </summary>
    [TestClass]
    public class PendingShortageTests
    {
        /// <summary>
        /// Tests Equals method, where result should be true.
        /// </summary>
        [TestMethod]
        public void PendingShortageEqualsValid()
        {
            PendingShortage a = new PendingShortage("Ciprofloxacin Injection", "link1");
            PendingShortage b = new PendingShortage("Ciprofloxacin Injection", "link1");

            Assert.IsTrue(a.Equals(b));
        }

        /// <summary>
        /// Tests Equals method, where result should be false because both the source URLs
        /// and the drug names are not the same.
        /// </summary>
        [TestMethod]
        public void PendingShortageEqualsBothFalse()
        {
            PendingShortage a = new PendingShortage("Ciprofloxacin Injection", "link1");
            PendingShortage b = new PendingShortage("Hydromorphone Hydrochloride Injection", "link2");

            Assert.IsFalse(a.Equals(b));
        }

        /// <summary>
        /// Tests Equals method, where result should be false because the drug names
        /// are not the same.
        /// </summary>
        [TestMethod]
        public void PendingShortageEqualsDrugNameFalse()
        {
            PendingShortage a = new PendingShortage("Ciprofloxacin Injection", "link1");
            PendingShortage b = new PendingShortage("Hydromorphone Hydrochloride Injection", "link1");

            Assert.IsFalse(a.Equals(b));
        }

        /// <summary>
        /// Tests Equals method, where result should be false because the source URLs
        /// are not the same.
        /// </summary>
        [TestMethod]
        public void PendingShortageSourceUrlFalse()
        {
            PendingShortage a = new PendingShortage("Ciprofloxacin Injection", "link1");
            PendingShortage b = new PendingShortage("Ciprofloxacin Injection", "link2");

            Assert.IsFalse(a.Equals(b));
        }

        /// <summary>
        /// Tests default constructor
        /// </summary>
        [TestMethod]
        public void PendingShortageDefaultConstructor()
        {
            PendingShortage pendingShortage = new PendingShortage();
            Assert.IsTrue(pendingShortage.DrugName == string.Empty && pendingShortage.SourceURL == string.Empty);
        }

        /// <summary>
        /// Tests all of the setters
        /// </summary>
        [TestMethod]
        public void PendingShortageSetters()
        {
            PendingShortage pendingShortage = new PendingShortage();
            pendingShortage.SourceURL = "http://www.cameronIsGreat.com";
            pendingShortage.DrugName = "Aspirin, or something.";

            Assert.IsTrue(pendingShortage.DrugName == "Aspirin, or something." && 
                          pendingShortage.SourceURL == "http://www.cameronIsGreat.com");
        }
    }
}
