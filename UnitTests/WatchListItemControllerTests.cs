//-----------------------------------------------------------------------
// <copyright file="WatchListItemControllerTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using MedicationsShortagesDashboard.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for WatchListItemController
    /// </summary>
    [TestClass]
    public class WatchListItemControllerTests
    {
        /// <summary>
        /// Tests default constructor
        /// </summary>
        [TestMethod]
        public void WatchListItemControllerDefaultConstructor()
        {
            WatchListItemController controller = new WatchListItemController();

            Assert.IsNotNull(controller);
        }
    }
}
