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
    public class HrData 
    {
        private List<HrDataSingle> dataEuro;
        private List<HrDataSingle> dataUS;

        public HrData(Boolean dataType, int version, List<string> rawData, int cadAlt = 46)
        {
            //means euro data type
            if (!dataType)
            {
                dataEuro = new List<HrDataSingle>();
                dataUS = new List<HrDataSingle>();
                foreach (string line in rawData)
                {
                    HrDataSingle tempEuro = new HrDataSingle(line.Split('\t').ToList<string>(), version, cadAlt);

                    //we need to convert form euro to us 
                    List<string> lineConverted = new List<string>();
                    lineConverted.Add("" + tempEuro.HeartRate);
                    //we times by 10 to compensate for the divide in hr data single
                    lineConverted.Add("" + ((tempEuro.Speed * 0.621371)*10));
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
                    dataUS.Add(new HrDataSingle(lineConverted, version, cadAlt));
                    dataEuro.Add(tempEuro);
                }
            }
            else
            {
                foreach (string line in rawData)
                {
                    dataUS = new List<HrDataSingle>();
                    dataEuro = new List<HrDataSingle>();

                    HrDataSingle tempUS = new HrDataSingle(line.Split('\t').ToList<string>(), version, cadAlt);
                    //we need to convert form us to 
                    List<string> lineConverted = new List<string>();
                    lineConverted.Add(""+tempUS.HeartRate);
                    lineConverted.Add(""+((tempUS.Speed* 1.609344)*10));
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
                    dataEuro.Add(new HrDataSingle(lineConverted, version, cadAlt));
                    dataUS.Add(tempUS);
                }
            }

        }

        public List<HrDataSingle> DataUS { get { return dataUS; } set { dataUS = value; } }
        public List<HrDataSingle> DataEuro { get { return dataEuro; } set { dataEuro = value; } }
    }
}
