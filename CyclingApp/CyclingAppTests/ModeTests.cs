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
    /// Test class for Mode
    /// </summary>
    [TestClass()]
    public class ModeTests
    {
        /// <summary>
        /// Test the constructor and getters
        /// </summary>
        [TestMethod()]
        public void ModeTest()
        {
            Mode m = new Mode("1000");
            Assert.IsTrue(m.CadAltInt == 1);
            Assert.IsTrue(m.CcData);
            Assert.IsTrue(m.Unit );
        }
    }
}