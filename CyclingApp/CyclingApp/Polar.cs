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

        /// <summary>
        /// Loads the data using the polar reader
        /// </summary>
        /// <param name="filePath">the file path of the file to load</param>
        public void LoadData(string filePath)
        {

            dataStore.ReadFile(filePath);
        }


        /// <summary>
        /// gets the summary in US data format
        /// </summary>
        /// <returns>the summary in a dictionary format</returns>
        public Dictionary<string, string> GetSummaryUS()
        {
            
                return dataStore.SummaryUS;
            
        }
        /// <summary>
        /// gets the summary in EURO data format
        /// </summary>
        /// <returns>the summary in a dictionary format</returns>
        public Dictionary<string, string> GetSummaryEuro()
        {
            return dataStore.SummaryEuro;
           
        }


        /// <summary>
        /// used to get the unit from the polar reader
        /// </summary>
        /// <returns></returns>
        public bool GetUnit()
        {
            return dataStore.UnitBool;
        }

        /// <summary>
        /// used to get the ride info in one list
        /// </summary>
        /// <returns>a list of all information relating to the ride</returns>
        public List<string> GetRideInfo()
        {
            return dataStore.GetRideInfo();
        }

        /// <summary>
        /// used to ge the HR data from the loaded file
        /// </summary>
        /// <returns>HrData object</returns>
        public HrData GetHrData()
        {
            return dataStore.HrDataExtended;
        }

        /// <summary>
        /// Used to get the SMODe
        /// </summary>
        /// <returns>Smode object</returns>
        public Smode GetSMODE()
        {
            return dataStore.Smode;
        }

        /// <summary>
        /// used to get and calc the Intensity Factor
        /// </summary>
        /// <param name="np"></param>
        /// <param name="ftp"></param>
        /// <returns></returns>
        public double GetIF(double np, int ftp)
        {
            return dataStore.GetIF(np,ftp);
        }

        /// <summary>
        /// used to pass data to polar reader to get the summary data
        /// </summary>
        /// <param name="start">start time</param>
        /// <param name="end">end time</param>
        /// <param name="unit">requird unit</param>
        /// <returns></returns>
        public Dictionary<string, string>[] GetSummaryDataTimeSpecificed(DateTime start, DateTime end, bool unit)
        {
            Console.WriteLine("We are getting data from polar");
            return dataStore.GetSummarySpecifiedTime(start, end);
        }
    }
}
