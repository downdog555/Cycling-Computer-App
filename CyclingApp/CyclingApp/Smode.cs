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
    class Smode
    {
        int[] valuesInt;
        private bool speed, cadence, altitude, power, powerLeftRightBalance, powerPedallingIndex, HRCC, unit, airPressure; 
        public Smode(string values)
        {
            valuesInt = new int[values.ToCharArray().Length];
            int i = 0;
            foreach (char c in values.ToCharArray())
            {
                valuesInt[i] = c;
                i++;
            }
            if (valuesInt.Length == 8)
            {
                airPressure = false;
            }
        }
    }
}
