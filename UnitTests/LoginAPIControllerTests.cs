//------------------------------------------------------------------
// <copyright file="LoginAPIControllerTests.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using MedicationsShortagesDashboard.Controllers;
    using MedicationsShortagesDashboard.Models;
    using MedicationsShortagesDashboard.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Class for testing the login interface controller
    /// </summary>
    [TestClass]
    public class LoginAPIControllerTests
    {
        /// <summary>
        /// Tests the default login interface controller constructor
        /// </summary>
        [TestMethod]
        public void LoginAPIControllerDefaultConstructor()
        {
            LoginAPIController l = new LoginAPIController();
            Assert.IsNotNull(l.LoginRepo);
        }

        /// <summary>
        /// Tests a GET that queries a populated database
        /// </summary>
        [TestMethod]
        public void LoginAPIControllerGETValidResult()
        {
            Login[] expectedResults = new Login[]
            {
                new Login("test1", "test2", "testType"),
                new Login("test3", "test4", "TestType")
            };

            var mock = new Mock<LoginRepository>();
            mock.Setup(foo => foo.GetAllLogins()).Returns(expectedResults);

            LoginAPIController controller = new LoginAPIController(mock.Object);

            List<Login> result = new List<Login>(controller.Get());
            foreach (Login login in expectedResults)
            {
                Assert.IsTrue(result.Contains(login));
            }
        }

        /// <summary>
        /// Tests a GET that queries an empty database
        /// </summary>
        [TestMethod]
        public void LoginAPIControllerGETEmptyResult()
        {
            Login[] expectedResults = new Login[]
            {
            };

            var mock = new Mock<LoginRepository>();
            mock.Setup(foo => foo.GetAllLogins()).Returns(expectedResults);

            LoginAPIController controller = new LoginAPIController(mock.Object);

            List<Login> result = new List<Login>(controller.Get());
            Assert.AreEqual(result.Count, 0);
        }
        
        /// <summary>
        /// Tests a POST that provides valid login data
        /// </summary>
        [TestMethod]
        public void LoginAPIControllerPOSTValidResult()
        {
            Login badLogin = new Login("d", "e", "f");

            var mock = new Mock<LoginRepository>();
            mock.Setup(foo => foo.CheckLogin(badLogin)).Returns(true);

            LoginAPIController controller = new LoginAPIController(mock.Object);
            //controller.Request = new HttpRequestMessage();
            //controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var result = controller.Post(badLogin);   

            Assert.IsTrue(result.IsSuccessStatusCode);

            //Assert.IsTrue(1==1);
        }

        /// <summary>
        /// Tests a POST that provides invalid login data
        /// </summary>
        [TestMethod]
        public void LoginAPIControllerPOSTInvalidResult()
        {
            Login badLogin = new Login("d", "e", "f");

            var mock = new Mock<LoginRepository>();
            mock.Setup(foo => foo.CheckLogin(badLogin)).Returns(false);

            LoginAPIController controller = new LoginAPIController(mock.Object);

            var result = controller.Post(badLogin);
            Assert.IsFalse(result.IsSuccessStatusCode);

            Assert.IsFalse(1 == 0);
        }
    }
}
