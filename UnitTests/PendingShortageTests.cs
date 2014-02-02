using System;
using MedicationsShortagesDashboard.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class PendingShortageTests
    {
        [TestMethod]
        public void Equals_Valid()
        {
            PendingShortage a = new PendingShortage("Ciprofloxacin Injection", "link1");
            PendingShortage b = new PendingShortage("Ciprofloxacin Injection", "link1");

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void Equals_BothFalse()
        {
            PendingShortage a = new PendingShortage("Ciprofloxacin Injection", "link1");
            PendingShortage b = new PendingShortage("Hydromorphone Hydrochloride Injection", "link2");

            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void Equals_DrugNameFalse()
        {
            PendingShortage a = new PendingShortage("Ciprofloxacin Injection", "link1");
            PendingShortage b = new PendingShortage("Hydromorphone Hydrochloride Injection", "link1");

            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void Equals_SourceUrlFalse()
        {
            PendingShortage a = new PendingShortage("Ciprofloxacin Injection", "link1");
            PendingShortage b = new PendingShortage("Ciprofloxacin Injection", "link2");

            Assert.IsFalse(a.Equals(b));
        }
    }
}
