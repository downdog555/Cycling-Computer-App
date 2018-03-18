using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclingApp
{
    /// <summary>
    /// Class containing the logic and code to alter/modify the data
    /// Contains a polar reader
    /// 
    /// </summary>
    public class Polar
    {
        /// <summary>
        /// Polar reader loads and separaates the data, also  acts as a data store
        /// </summary>
        private PolarReader dataStore;

        /// <summary>
        /// Constructor
        /// </summary>
        public Polar()
        {
            //instantiate the polar reader
            dataStore = new PolarReader();
        }

        public void LoadData(string filePath)
        {

            dataStore.ReadFile(filePath);
        }

        public Dictionary<string, string> GetSummaryUS()
        {
            
                return dataStore.SummaryUS;
            
        }

        public Dictionary<string, string> GetSummaryEuro()
        {
            return dataStore.SummaryEuro;
           
        }



        public bool GetUnit()
        {
            return dataStore.UnitBool;
        }

        public List<string> GetRideInfo()
        {
            return dataStore.GetRideInfo();
        }
        public HrData GetHrData()
        {
            return dataStore.HrDataExtended;
        }

        public Smode GetSMODE()
        {
            return dataStore.Smode;
        }

        public Dictionary<string, string>[] GetSummaryDataTimeSpecificed(DateTime start, DateTime end, bool unit)
        {
            Console.WriteLine("We are getting data from polar");
            return dataStore.GetSummarySpecifiedTime(start, end);
        }
    }
}
