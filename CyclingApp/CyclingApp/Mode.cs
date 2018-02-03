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
        string CadAlt;
        bool unit, ccData;

        public Mode(string values)
        {
            char[] valueChar = values.ToCharArray();
            if (valueChar[0].Equals('0'))
            {
                CadAlt = "Cad";
            }
            else if (valueChar[0].Equals('1'))
            {
                CadAlt = "Alt";
            }
            else if (valueChar[0].Equals('3'))
            {
                CadAlt = "None";
            }

            unit = !valueChar.Equals("0");
            ccData = !valueChar.Equals('0');
        }
        //getters and setters
        public string CadAlt1 { get => CadAlt; set => CadAlt = value; }
        public bool Unit { get => unit; set => unit = value; }
        public bool CcData { get => ccData; set => ccData = value; }
    }
}
