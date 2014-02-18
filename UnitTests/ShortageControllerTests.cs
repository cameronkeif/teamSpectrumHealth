using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedicationsShortagesDashboard.Models;
using Moq;
using MedicationsShortagesDashboard.Controllers;
using MedicationsShortagesDashboard.Services;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ShortageControllerTests
    {
        [TestMethod]
        public void ShortageControllerGetTest()
        {
            Shortage[] expectedResults = new Shortage[]
            {
                new Shortage(0, 1, DateTime.Now, "warning"),
                new Shortage(1, 2, DateTime.Now, "warning")
            };

            var mock = new Mock<ShortageRepository>();
            mock.Setup(x => x.GetAllShortages()).Returns(expectedResults);

            ShortageController controller = new ShortageController(mock.Object);

            List<Shortage> result = new List<Shortage>(controller.Get());
            foreach (Shortage shortage in expectedResults)
            {
                Assert.IsTrue(result.Contains(shortage));
            }
        }
    }
}
