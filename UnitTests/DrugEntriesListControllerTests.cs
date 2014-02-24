//------------------------------------------------------------------
// <copyright file="DrugEntriesListControllerTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using System;
    using MedicationsShortagesDashboard.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for DrugEntriesListController
    /// </summary>
    [TestClass]
    public class DrugEntriesListControllerTests
    {
        /// <summary>
        /// Tests the Index method.
        /// </summary>
        [TestMethod]
        public void DrugEntriesListControllerIndex()
        {
            DrugEntriesListController d = new DrugEntriesListController();

            Assert.IsNotNull(d.Index());
        }

        /// <summary>
        /// Tests the Upload method.
        /// </summary>
        [TestMethod]
        public void DrugEntriesListControllerUpload()
        {
            DrugEntriesListController d = new DrugEntriesListController();

            Assert.IsNotNull(d.Upload());
        }

        /// <summary>
        /// Tests the Details method given an NDC that doesn't exist in the database.
        /// </summary>
        [TestMethod]
        public void DrugEntriesListControllerDetailsNoExistingDrug()
        {
            DrugEntriesListController d = new DrugEntriesListController();

            Assert.IsNotNull(d.Details("This is obviously an invalid NDC"));
        }
    }
}
