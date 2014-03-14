//-----------------------------------------------------------------------
// <copyright file="DrugEntryTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using MedicationsShortagesDashboard.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit Tests for DrugEntry
    /// </summary>
    [TestClass]
    public class DrugEntryTests
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        [TestMethod]
        public void DrugEntryDefaultConstructor()
        {
            DrugEntry d = new DrugEntry();
            Assert.IsNotNull(d);
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        [TestMethod]
        public void DrugEntryParameterizedConstructor()
        {
            DrugEntry d = new DrugEntry("111-111-2234", "100mg", "Tylenol", "Acetaminophen", "good");
            Assert.IsNotNull(d);
        }

        /// <summary>
        /// National drug code getter
        /// </summary>
        [TestMethod]
        public void DrugEntryNDCGetter()
        {
            DrugEntry d = new DrugEntry("111-111-2234", "100mg", "Tylenol", "Acetaminophen", "good");
            Assert.AreEqual(d.NDC, "111-111-2234");
        }

        /// <summary>
        /// National drug code setter
        /// </summary>
        [TestMethod]
        public void DrugEntryNDCSetter()
        {
            DrugEntry d = new DrugEntry("222-111-2234", "100mg", "Tylenol", "Acetaminophen", "good");
            d.NDC = "111-111-2234";
            Assert.AreEqual(d.NDC, "111-111-2234");
        }

        /// <summary>
        /// Dosage getter
        /// </summary>
        [TestMethod]
        public void DrugEntryDosageGetter()
        {
            DrugEntry d = new DrugEntry("111-111-2234", "100mg", "Tylenol", "Acetaminophen", "good");
            Assert.AreEqual(d.Dosage, "100mg");
        }

        /// <summary>
        /// Dosage setter
        /// </summary>
        [TestMethod]
        public void DrugEntryDosageSetter()
        {
            DrugEntry d = new DrugEntry("111-111-2234", "0mg", "Tylenol", "Acetaminophen", "good");
            d.Dosage = "100mg";
            Assert.AreEqual(d.Dosage, "100mg");
        }

        /// <summary>
        /// Brand name getter
        /// </summary>
        [TestMethod]
        public void DrugEntryBrandGetter()
        {
            DrugEntry d = new DrugEntry("111-111-2234", "100mg", "Tylenol", "Acetaminophen", "good");
            Assert.AreEqual(d.Brand, "Tylenol");
        }

        /// <summary>
        /// Brand name setter
        /// </summary>
        [TestMethod]
        public void DrugEntryBrandSetter()
        {
            DrugEntry d = new DrugEntry("111-111-2234", "100mg", string.Empty, "Acetaminophen", "good");
            d.Brand = "Tylenol";
            Assert.AreEqual(d.Brand, "Tylenol");
        }

        /// <summary>
        /// Generic name getter
        /// </summary>
        [TestMethod]
        public void DrugEntryGenericGetter()
        {
            DrugEntry d = new DrugEntry("111-111-2234", "100mg", "Tylenol", "Acetaminophen", "good");
            Assert.AreEqual(d.Generic, "Acetaminophen");
        }

        /// <summary>
        /// Generic name setter
        /// </summary>
        [TestMethod]
        public void DrugEntryGenericSetter()
        {
            DrugEntry d = new DrugEntry("111-111-2234", "100mg", "Tylenol", string.Empty, "good");
            d.Generic = "Acetaminophen";
            Assert.AreEqual(d.Generic, "Acetaminophen");
        }

        /// <summary>
        /// Current status getter
        /// </summary>
        [TestMethod]
        public void DrugEntryCurrentStatusGetter()
        {
            DrugEntry d = new DrugEntry("111-111-2234", "100mg", "Tylenol", "Acetaminophen", "good");
            Assert.AreEqual(d.CurrentStatus, "good");
        }

        /// <summary>
        /// Current status setter
        /// </summary>
        [TestMethod]
        public void DrugEntryCurrentStatusSetter()
        {
            DrugEntry d = new DrugEntry("111-111-2234", "100mg", "Tylenol", "Acetaminophen", "good");
            d.CurrentStatus = "severe";
            Assert.AreEqual(d.CurrentStatus, "severe");
        }

        /// <summary>
        /// To string
        /// </summary>
        [TestMethod]
        public void DrugEntryToString()
        {
            DrugEntry d = new DrugEntry("111-111-2234", "100mg", "Tylenol", "Acetaminophen", "good");
            string expectedResult = "111-111-2234" + " - " + "100mg" + " - " + "Tylenol" + " - " + "Acetaminophen" + " - " + "good";
            Assert.AreEqual(d.ToString(), expectedResult);
        }
    }
}
