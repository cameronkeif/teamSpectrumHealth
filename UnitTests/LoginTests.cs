//-----------------------------------------------------------------------
// <copyright file="LoginTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using System.Diagnostics.CodeAnalysis;
    using MedicationsShortagesDashboard.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests functionality of the Login class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LoginTests
    {
        /// <summary>
        /// Tests Equals method, where result should be true.
        /// </summary>
        [TestMethod]
        public void LoginEqualsValid()
        {
            Login a = new Login("UserA", "pass", "user");
            Login b = new Login("UserA", "pass", "user");

            Assert.IsTrue(a.Equals(b));
        }

        /// <summary>
        /// Tests Equals method, where result should be false because usernames differ
        /// </summary>
        [TestMethod]
        public void LoginEqualsUsernameFalse()
        {
            Login a = new Login("UserA", "pass", "user");
            Login b = new Login("UserB", "pass", "user");

            Assert.IsFalse(a.Equals(b));
        }

        /// <summary>
        /// Tests Equals method, where result should be false because passwords differ
        /// </summary>
        [TestMethod]
        public void LoginEqualsPasswordFalse()
        {
            Login a = new Login("UserA", "pass", "user");
            Login b = new Login("UserA", "pass1", "user");

            Assert.IsFalse(a.Equals(b));
        }

        /// <summary>
        /// Tests Equals method, where result should be false because types differ
        /// </summary>
        [TestMethod]
        public void LoginEqualsTypeFalse()
        {
            Login a = new Login("UserA", "pass", "user");
            Login b = new Login("UserA", "pass", "user1");

            Assert.IsFalse(a.Equals(b));
        }

        /// <summary>
        /// Tests default constructor
        /// </summary>
        [TestMethod]
        public void LoginDefaultConstructor()
        {
            Login login = new Login();
            Assert.IsTrue(login.Username == string.Empty && login.Password == string.Empty && login.Type == string.Empty);
        }

        /// <summary>
        /// Tests all of the setters
        /// </summary>
        [TestMethod]
        public void LoginSetters()
        {
            Login login = new Login();
            login.Username = "UserA";
            login.Password = "pass";
            login.Type = "type";

            Assert.IsTrue(login.Username == "UserA" &&
                          login.Password == "pass" &&
                          login.Type == "type");
        }
    }
}