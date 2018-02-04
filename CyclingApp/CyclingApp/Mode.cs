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

        public Mode(string values)
        {
            char[] valueChar = values.ToCharArray();
            cadAltInt = Convert.ToInt32(valueChar[0]);
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
        public string CadAlt { get => cadAlt;}
        public int CadAltInt { get => cadAltInt; }
        public bool Unit { get => unit; }
        public bool CcData { get => ccData;}
    }
}
