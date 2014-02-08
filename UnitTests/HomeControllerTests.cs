//------------------------------------------------------------------
// <copyright file="HomeControllerTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using System;
    using MedicationsShortagesDashboard.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests functionality of HomeController
    /// </summary>
    [TestClass]
    public class HomeControllerTests
    {
        /// <summary>
        /// Tests functionality of the Index method
        /// </summary>
        [TestMethod]
        public void HomeControllerIndex()
        {
            HomeController controller = new HomeController();
            Assert.AreNotEqual(controller.Index(), null);
        }
    }
}
