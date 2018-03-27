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
        private Smode smode;

        /// <summary>
        /// constructor for the data from the cycle
        /// </summary>
        /// <param name="dataType">false for euro units, true for US</param>
        /// <param name="version">version of the file</param>
        /// <param name="rawData">list of the raw HR data</param>
        /// <param name="smode">the SMODE for the currnet file</param>
        /// <param name="cadAlt">Cad aLt if need for an earlier file, defaults to 46 if not provied</param>
        public HrData(Boolean dataType, int version, List<string> rawData, Smode smode ,int cadAlt = 46)
        {
            this.smode = smode;
            //means euro data type
            if (!dataType)
            {
                //Console.WriteLine("We are meme 3.512");
                dataEuro = new List<HrDataSingle>();
                dataUS = new List<HrDataSingle>();
                foreach (string line in rawData)
                {
                    HrDataSingle tempEuro = new HrDataSingle(line.Split('\t').ToList<string>(), version, smode,cadAlt);
                    //Console.WriteLine("We are meme 3.513");
                    //we need to convert form euro to us 
                    List<string> lineConverted = new List<string>();
                    lineConverted.Add("" + tempEuro.HeartRate);
                    //we times by 10 to compensate for the divide in hr data single
                    lineConverted.Add("" + ((tempEuro.Speed * 0.621371)*10));
                    //Console.WriteLine("We are meme 3.513");
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
                        //Console.WriteLine("We are meme 3.5134");
                    }
                    lineConverted.Add("" + tempEuro.Power);
                    lineConverted.Add("" + tempEuro.PbPedInd);
                    lineConverted.Add("" + tempEuro.AirPressure);
                    dataUS.Add(new HrDataSingle(lineConverted, version,smode ,cadAlt));
                    //Console.WriteLine("We are meme 3.5135");
                    dataEuro.Add(tempEuro);
                    //Console.WriteLine("We are meme 3.5136");
                }
                //Console.WriteLine("We are meme 3.512");
            }
            else
            {
                foreach (string line in rawData)
                {
                    dataUS = new List<HrDataSingle>();
                    dataEuro = new List<HrDataSingle>();

                    HrDataSingle tempUS = new HrDataSingle(line.Split('\t').ToList<string>(), version,smode, cadAlt);
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
                    dataEuro.Add(new HrDataSingle(lineConverted, version, smode,cadAlt));
                    dataUS.Add(tempUS);
                }
            }

        }
        /// <summary>
        /// getters and setters for data us
        /// </summary>
        public List<HrDataSingle> DataUS { get { return dataUS; } set { dataUS = value; } }
        /// <summary>
        /// getters and setters for data euro
        /// </summary>
        public List<HrDataSingle> DataEuro { get { return dataEuro; } set { dataEuro = value; } }
    }
}
