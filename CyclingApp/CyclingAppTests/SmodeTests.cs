using Microsoft.VisualStudio.TestTools.UnitTesting;
using CyclingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclingApp.Tests
{
    /// <summary>
    /// Test class for the smode
    /// </summary>
    [TestClass()]
    public class SmodeTests
    {
        /// <summary>
        /// Tests the constructor and getters
        /// </summary>
        [TestMethod()]
        public void SmodeTest()
        {
            Smode s = new Smode(107, "100011111");
            Assert.IsTrue(s.Speed);
            Assert.IsFalse(s.Cadence);
            Assert.IsFalse(s.Altitude);
            Assert.IsFalse(s.Power);
            Assert.IsTrue(s.PowerLeftRightBalance);
            Assert.IsTrue(s.PowerPedallingIndex);
            Assert.IsTrue(s.HRCC1);
            Assert.IsTrue(s.Unit);
            Assert.IsTrue(s.AirPressure);

        }
    }
}