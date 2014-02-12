//------------------------------------------------------------------
// <copyright file="LoginControllerTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using System;
    using MedicationsShortagesDashboard.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class for testing the login controller
    /// </summary>
    [TestClass]
    public class LoginControllerTests
    {
        /// <summary>
        /// Tests functionality of the Index method
        /// </summary>
        [TestMethod]
        public void LoginControllerIndex()
        {
            LoginController controller = new LoginController();
            Assert.AreNotEqual(controller.Index(), null);
        }
    }
}
