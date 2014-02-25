//-----------------------------------------------------------------------
// <copyright file="ShortageControllerTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using MedicationsShortagesDashboard.Controllers;
    using MedicationsShortagesDashboard.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for ShortageController
    /// </summary>
    [TestClass]
    public class ShortageControllerTests
    {
        /// <summary>
        /// Test default constructor
        /// </summary>
        [TestMethod]
        public void ShortageControllerDefaultConstructor()
        {
            ShortageController controller = new ShortageController();

            Assert.IsNotNull(controller);
        }

        /// <summary>
        /// Test parameterized constructor
        /// </summary>
        [TestMethod]
        public void ShortageControllerConstructorWithRepositories()
        {
            ShortageRepository shortageRepo = new ShortageRepository();
            DrugEntryRepository drugEntryRepo = new DrugEntryRepository();
            ShortageController controller = new ShortageController(shortageRepo, drugEntryRepo);

            Assert.IsNotNull(controller);
        }
    }
}
