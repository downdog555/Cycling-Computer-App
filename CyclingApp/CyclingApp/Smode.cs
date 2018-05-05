using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclingApp
{
    /// <summary>
    /// Class representing a SMODE
    /// </summary>
    public class Smode
    {
        int[] valuesInt;
        private bool speed, cadence, altitude, power, powerLeftRightBalance, powerPedallingIndex, HRCC, unit, airPressure; 

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="version">Version of data file</param>
        /// <param name="values">the smode values</param>
        public Smode(int version, string values)
        {
            //converts the value string to an int array
            //so we can just use booleans
            valuesInt = new int[values.ToCharArray().Length];
            int i = 0;
            foreach (char c in values.ToCharArray())
            {
                string b = "" + c;
                valuesInt[i] = Convert.ToInt32(b);
                i++;
            }
            if (version == 106)
            {
                airPressure = false;
            }
            else
            {
                airPressure = valuesInt[8] != 0;
            }
            speed = valuesInt[0] != 0;
            cadence = valuesInt[1] != 0;
            altitude = valuesInt[2] != 0;
            power = valuesInt[3] != 0;
            powerLeftRightBalance = valuesInt[4] != 0;
            powerPedallingIndex = valuesInt[5] != 0;
            HRCC = valuesInt[6] != 0;
            unit = valuesInt[7] != 0;
        }
        #region getters and setters
        public bool Speed { get { return speed; } set { speed = value; } }
        public bool Cadence { get { return cadence; } set { cadence = value; } }
        public bool Altitude { get { return altitude; } set { altitude = value; } }
        public bool Power { get { return power; } set { power = value; } }
        public bool PowerLeftRightBalance { get { return powerLeftRightBalance; } set { powerLeftRightBalance = value; } }
        public bool PowerPedallingIndex { get { return powerPedallingIndex; } set { powerPedallingIndex = value; } }
        public bool HRCC1 { get { return HRCC; } set { HRCC = value; } }
        public bool Unit { get { return unit; } set { unit = value; } }
        public bool AirPressure { get { return airPressure; } set { airPressure = value; } }
        #endregion
    }
}
