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
    /// Test calss for polar reader
    /// </summary>
    [TestClass()]
    public class PolarReaderTests
    {



        /// <summary>
        /// Test method to test loading data and 
        /// </summary>
        [TestMethod()]
        public void ReadFileTest()
        {
            PolarReader p = new PolarReader();
            p.ReadFile(@"C:\Users\DaveL\Downloads\ASDBExampleCycleComputerData.hrm");
            HrData hrdata = p.HrDataExtended;
            Assert.IsNotNull(hrdata);

        }

        /// <summary>
        /// Test method to tes get us summary
        /// </summary>
        [TestMethod()]
        public void GetSummaryUSTest()
        {
            PolarReader p = new PolarReader();
            p.ReadFile(@"C:\Users\DaveL\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.SummaryUS);
        }

        /// <summary>
        /// test method to get Euro summary
        /// </summary>
        [TestMethod()]
        public void GetSummaryEuroTest()
        {
            PolarReader p = new PolarReader();
            p.ReadFile(@"C:\Users\DaveL\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.SummaryEuro);
        }

        /// <summary>
        /// Test method for get unti test
        /// </summary>
        [TestMethod()]
        public void GetUnitTest()
        {
            PolarReader p = new PolarReader();
            p.ReadFile(@"C:\Users\DaveL\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.UnitBool);
        }

        /// <summary>
        /// Test method for get ride info
        /// </summary>
        [TestMethod()]
        public void GetRideInfoTest()
        {
            PolarReader p = new PolarReader();
            p.ReadFile(@"C:\Users\DaveL\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.GetRideInfo());
        }

        /// <summary>
        /// test methdo for get hr data
        /// </summary>
        [TestMethod()]
        public void GetHrDataTest()
        {
            PolarReader p = new PolarReader();
            p.ReadFile(@"C:\Users\DaveL\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.HrDataExtended);
        }

        /// <summary>
        /// test method for get smode 
        /// </summary>
        [TestMethod()]
        public void GetSMODETest()
        {
            PolarReader p = new PolarReader();
            p.ReadFile(@"C:\Users\DaveL\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.Smode);
        }

        /// <summary>
        /// test method get intensity factor
        /// </summary>
        [TestMethod()]
        public void GetIFTest()
        {
            PolarReader p = new PolarReader();
            p.ReadFile(@"C:\Users\DaveL\Downloads\ASDBExampleCycleComputerData.hrm");

            Assert.IsNotNull(p.GetIF(300, 243));
            Assert.IsTrue( (((double)300 / 243) * 100) == p.GetIF(300, 243));
        }
        /// <summary>
        /// test method for testing th summary retireved via a specific date time
        /// </summary>
        [TestMethod()]
        public void GetSummaryDataTimeSpecificedTest()
        {
            PolarReader p = new PolarReader();
            p.ReadFile(@"C:\Users\DaveL\Downloads\ASDBExampleCycleComputerData.hrm");
            DateTime start = new DateTime(2018, 1, 1, 0, 0, 0);
            DateTime end = new DateTime(2018, 1, 1, 0, 50, 5);
            Assert.IsNotNull(p.GetSummarySpecifiedTime(start, end));
            Assert.IsTrue(p.GetSummarySpecifiedTime(start, end).Count() > 0);

        }
        
        }
    }
