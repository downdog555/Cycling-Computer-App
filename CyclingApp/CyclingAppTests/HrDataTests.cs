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
    /// Test class for the hrdata class
    /// </summary>
    [TestClass()]
    public class HrDataTests
    {
        /// <summary>
        /// testing the constructor
        /// </summary>
        [TestMethod()]
        public void HrDataTest()
        {
            Polar p = new Polar();
            p.LoadData(@"C:\Users\Reec\Downloads\ASDBExampleCycleComputerData.hrm");
            HrData hrdata = p.GetHrData();
            
            
                Assert.IsTrue(hrdata.DataEuro.Count == hrdata.DataUS.Count && hrdata.DataUS.Count > 0);
            


           
        }
    }
}