using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclingApp
{
    /// <summary>
    /// Class to represent and process the hr data section
    /// </summary>
    class HrData
    {
        private List<HrDataSingle> DataEuro;
        private List<HrDataSingle> DataUS;

        public HrData(Boolean dataType, int version, List<string> rawData, int cadAlt = 46)
        {
            //means euro data type
            if (!dataType)
            {
                DataEuro = new List<HrDataSingle>();
                DataUS = new List<HrDataSingle>();
                foreach (string line in rawData)
                {
                    HrDataSingle tempEuro = new HrDataSingle(line.Split('\t').ToList<string>(), version, cadAlt);

                    //we need to convert form euro to us 
                    List<string> lineConverted = new List<string>();
                    lineConverted.Add("" + tempEuro.HeartRate);
                    lineConverted.Add("" + (tempEuro.Speed * 0.6213711922));
                    if (cadAlt == 0)
                    {
                        lineConverted.Add("" + tempEuro.Cadence);
                    }
                    else if (cadAlt == 1)
                    {
                        lineConverted.Add("" + (tempEuro.Altitude * 3.280839895));
                    }
                    else
                    {
                        lineConverted.Add("" + tempEuro.Cadence);
                        lineConverted.Add("" + (tempEuro.Altitude * 3.280839895));
                    }
                    lineConverted.Add("" + tempEuro.Power);
                    lineConverted.Add("" + tempEuro.PbPedInd);
                    lineConverted.Add("" + tempEuro.AirPressure);
                    DataUS.Add(new HrDataSingle(lineConverted, version, cadAlt));
                    DataEuro.Add(tempEuro);
                }
            }
            else
            {
                foreach (string line in rawData)
                {
                    DataUS = new List<HrDataSingle>();
                    DataEuro = new List<HrDataSingle>();

                    HrDataSingle tempUS = new HrDataSingle(line.Split('\t').ToList<string>(), version, cadAlt);
                    //we need to convert form us to 
                    List<string> lineConverted = new List<string>();
                    lineConverted.Add(""+tempUS.HeartRate);
                    lineConverted.Add(""+(tempUS.Speed* 1.609344));
                    if (cadAlt == 0)
                    {
                        lineConverted.Add("" + tempUS.Cadence);
                    }
                    else if (cadAlt == 1)
                    {
                        lineConverted.Add("" + (tempUS.Altitude * 0.3048));
                    }
                    else
                    {
                        lineConverted.Add("" + tempUS.Cadence);
                        lineConverted.Add("" + (tempUS.Altitude * 0.3048));
                    }
                    lineConverted.Add(""+tempUS.Power);
                    lineConverted.Add(""+tempUS.PbPedInd);
                    lineConverted.Add(""+tempUS.AirPressure);
                    DataEuro.Add(new HrDataSingle(lineConverted, version, cadAlt));
                    DataUS.Add(tempUS);
                }
            }

        }
    }
}
