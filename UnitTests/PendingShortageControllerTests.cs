//-----------------------------------------------------------------------
// <copyright file="PendingShortageControllerTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using System;
    using System.Collections.Generic;
    using MedicationsShortagesDashboard.Controllers;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Provides tests for the pending shortage controller
    /// </summary>
    [TestClass]
    public class PendingShortageControllerTests
    {
        /// <summary>
        /// Tests a GET that queries a populated database
        /// </summary>
        [TestMethod]
        public void PendingShortageControllerGETValidResult()
        {
            PendingShortage[] expectedResults = new PendingShortage[]
            {
                new PendingShortage("test1", "test2"),
                new PendingShortage("test3", "test4")
            };

            var mock = new Mock<PendingShortageRepository>();
            mock.Setup(foo => foo.GetAllPendingShortages()).Returns(expectedResults);

            PendingShortageController controller = new PendingShortageController(mock.Object);

            List<PendingShortage> result = new List<PendingShortage>(controller.Get());
            foreach (PendingShortage pendingShortage in expectedResults)
            {
                Assert.IsTrue(result.Contains(pendingShortage));
            }
        }

        /// <summary>
        /// Tests a GET that queries an empty database
        /// </summary>
        [TestMethod]
        public void PendingShortageControllerGETEmptyResult()
        {
            PendingShortage[] expectedResults = new PendingShortage[]
            {
            };

            var mock = new Mock<PendingShortageRepository>();
            mock.Setup(foo => foo.GetAllPendingShortages()).Returns(expectedResults);

            PendingShortageController controller = new PendingShortageController(mock.Object);

            List<PendingShortage> result = new List<PendingShortage>(controller.Get());
            Assert.AreEqual(result.Count, 0);
        }

        /// <summary>
        /// Tests default constructor
        /// </summary>
        [TestMethod]
        public void PendingShortageControllerDefaultConstructor()
        {
            PendingShortageController p = new PendingShortageController();

            Assert.IsNotNull(p);
        }
    }
}
