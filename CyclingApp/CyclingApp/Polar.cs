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
    class Polar
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

    }
}
