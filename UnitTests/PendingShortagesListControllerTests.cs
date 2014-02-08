//------------------------------------------------------------------
// <copyright file="PendingShortagesListControllerTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using MedicationsShortagesDashboard.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests functionality of PendingShortagesListController class
    /// </summary>
    [TestClass]
    public class PendingShortagesListControllerTests
    {
        /// <summary>
        /// Tests Index method
        /// </summary>
        [TestMethod]
        public void PendingShortagesListControllerIndex()
        {
            PendingShortagesListController controller = new PendingShortagesListController();
            Assert.AreNotEqual(controller.Index(), null);
        }
    }
}
