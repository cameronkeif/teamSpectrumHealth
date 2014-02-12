//------------------------------------------------------------------
// <copyright file="AuthenticationTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using MedicationsShortagesDashboard.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class for testing the authentication controller
    /// </summary>
    [TestClass]
    public class AuthenticationTests
    {
        /// <summary>
        /// Tests default values
        /// </summary>
        [TestMethod]
        public void AuthenticationDefaultValues()
        {
            Assert.IsTrue(Authentication.Authenticated == false && Authentication.Username.Equals("Guest") && Authentication.Type.Equals(string.Empty));
        }

        /// <summary>
        /// Tests reset
        /// </summary>
        [TestMethod]
        public void AuthenticationReset()
        {
            Authentication.Reset();
            Assert.IsTrue(Authentication.Authenticated == false && Authentication.Username.Equals("Guest") && Authentication.Type.Equals(string.Empty));
        }

        /// <summary>
        /// Tests setters
        /// </summary>
        [TestMethod]
        public void AuthenticationSetters()
        {
            Authentication.Username = "TestUser";
            Authentication.Authenticated = true;
            Authentication.Type = "Test";
            Assert.IsTrue(Authentication.Authenticated == true && Authentication.Username.Equals("TestUser") && Authentication.Type.Equals("Test"));
            Authentication.Reset();
        }
    }
}
