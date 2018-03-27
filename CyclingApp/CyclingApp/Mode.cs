using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclingApp
{
    /// <summary>
    /// class representing a mode 
    /// </summary>
    class Mode
    {
        private string cadAlt;
        private bool unit, ccData;
        private int cadAltInt;

        /// <summary>
        /// constructor for this class
        /// used when file has mode not SMODE
        /// </summary>
        /// <param name="values"></param>
        public Mode(string values)
        {
            char[] valueChar = values.ToCharArray();
            cadAltInt = Convert.ToInt32(""+valueChar[0]);
            if (valueChar[0].Equals('0'))
            {
                cadAlt = "Cad";
            }
            else if (valueChar[0].Equals('1'))
            {
                cadAlt = "Alt";
            }
            else if (valueChar[0].Equals('3'))
            {
                cadAlt = "None";
            }

            unit = !valueChar.Equals("0");
            ccData = !valueChar.Equals('0');
        }
        //getters and setters
        public string CadAlt { get { return cadAlt; } }
        public int CadAltInt { get { return cadAltInt; } }
        public bool Unit { get { return unit; } }
        public bool CcData { get { return ccData; } }
    }
}
