//-----------------------------------------------------------------------
// <copyright file="DrugEntryControllerTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using MedicationsShortagesDashboard.Controllers;
    using MedicationsShortagesDashboard.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for DrugEntryController
    /// </summary>
    [TestClass]
    public class DrugEntryControllerTests
    {
        /// <summary>
        /// Tests default constructor
        /// </summary>
        [TestMethod]
        public void DrugEntryControllerDefaultConstructor()
        {
            DrugEntryController d = new DrugEntryController();

            Assert.IsNotNull(d);
        }

        /// <summary>
        /// Tests constructor given a DrugEntryRepository as a parameter.
        /// </summary>
        [TestMethod]
        public void DrugEntryControllerConstructorWithRepository()
        {
            DrugEntryRepository repository = new DrugEntryRepository();
            DrugEntryController d = new DrugEntryController(repository);

            Assert.IsNotNull(d);
        }
    }
}
