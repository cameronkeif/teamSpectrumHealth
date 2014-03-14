//-----------------------------------------------------------------------
// <copyright file="ShortagesListControllerTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using MedicationsShortagesDashboard.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for ShortageListController
    /// </summary>
    [TestClass]
    public class ShortagesListControllerTests
    {
        /// <summary>
        /// Test for Index
        /// </summary>
        [TestMethod]
        public void ShortagesListControllerIndex()
        {
            ShortagesListController controller = new ShortagesListController();

            Assert.IsNotNull(controller.Index());
        }

        /// <summary>
        /// Test for Create
        /// </summary>
        [TestMethod]
        public void ShortagesListControllerCreate()
        {
            ShortagesListController controller = new ShortagesListController();

            Assert.IsNotNull(controller.Create());
        }

        /// <summary>
        /// Test for Edit with a shortage ID that does not exist in the database
        /// </summary>
        [TestMethod]
        public void ShortagesListControllerEditNonExistentShortage()
        {
            ShortagesListController controller = new ShortagesListController();

            Assert.IsNotNull(controller.Edit(-6546456)); // This ID would not exist in the database
        }
    }
}
