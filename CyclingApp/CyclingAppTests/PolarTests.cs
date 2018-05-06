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
    /// test class to test the polar class
    /// </summary>
    [TestClass()]
    public class PolarTests
    {
        
        /// <summary>
        /// Test method to test loading data and 
        /// </summary>
        [TestMethod()]
        public void LoadDataTest()
        {
            Polar p = new Polar();
            p.LoadData(@"C:\Users\Reec\Downloads\ASDBExampleCycleComputerData.hrm");
            HrData hrdata = p.GetHrData();
            Assert.IsNotNull(hrdata);

        }

        /// <summary>
        /// Test method to tes get us summary
        /// </summary>
        [TestMethod()]
        public void GetSummaryUSTest()
        {
            Polar p = new Polar();
            p.LoadData(@"C:\Users\Reec\Downloads\ASDBExampleCycleComputerData.hrm");
            
            Assert.IsNotNull(p.GetSummaryUS());
        }

        /// <summary>
        /// test method to get Euro summary
        /// </summary>
        [TestMethod()]
        public void GetSummaryEuroTest()
        {
            Polar p = new Polar();
            p.LoadData(@"C:\Users\Reec\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.GetSummaryEuro());
        }

        /// <summary>
        /// Test method for get unti test
        /// </summary>
        [TestMethod()]
        public void GetUnitTest()
        {
            Polar p = new Polar();
            p.LoadData(@"C:\Users\Reec\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.GetUnit());
        }

        /// <summary>
        /// Test method for get ride info
        /// </summary>
        [TestMethod()]
        public void GetRideInfoTest()
        {
            Polar p = new Polar();
            p.LoadData(@"C:\Users\Reec\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.GetRideInfo());
        }

        /// <summary>
        /// test methdo for get hr data
        /// </summary>
        [TestMethod()]
        public void GetHrDataTest()
        {
            Polar p = new Polar();
            p.LoadData(@"C:\Users\Reec\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.GetHrData());
        }

        /// <summary>
        /// test method for get smode 
        /// </summary>
        [TestMethod()]
        public void GetSMODETest()
        {
            Polar p = new Polar();
            p.LoadData(@"C:\Users\Reec\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.GetSMODE());
        }

        /// <summary>
        /// test method get intensity factor
        /// </summary>
        [TestMethod()]
        public void GetIFTest()
        {
            Polar p = new Polar();
            p.LoadData(@"C:\Users\Reec\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.GetIF(300, 243));
            Assert.IsTrue((((double)300 / 243) * 100) == p.GetIF(300, 243));
        }

        /// <summary>
        /// test method for testing th summary retireved via a specific date time
        /// </summary>
        [TestMethod()]
        public void GetSummaryDataTimeSpecificedTest()
        {
            Polar p = new Polar();
            p.LoadData(@"C:\Users\Reec\Downloads\ASDBExampleCycleComputerData.hrm");
            DateTime start = new DateTime(2018,1,1,0,0,0);
            DateTime end = new DateTime(2018, 1, 1, 0, 50, 5);
            Assert.IsNotNull(p.GetSummaryDataTimeSpecificed(start, end, false));
            Assert.IsTrue(p.GetSummaryDataTimeSpecificed(start, end, false).Count() > 0);
          
        }
    }
}