using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CyclingApp
{
    /// <summary>
    /// Class For Reading a Polar type document
    /// </summary>
    class PolarReader : IFileReader
    {

        private Mode mode;
        private Smode smode;
        /// <summary>
        /// Dictionary to contain the summary data so that 
        /// </summary>
        private Dictionary<string, string> summaryEuro, summaryUS;
        /// <summary>
        /// The required lists for separating data
        /// </summary>
        private List<string> parametersList, noteList, intTimeList, intNotesList, extraDataList, lapNameList, summary123List, summaryThList, hrZoneList, swapTimeList, tripList, hrDataList;
        private string filePath, monitor, date, startTime, length, timer1, timer2, timer3, activeLimit, unit;
        private float VO2max, weight;
        private int interval, upper1, lower1, upper2, lower2, upper3, lower3, maxHR, restHR, startDelay, version;
        private bool unitBool;
        private HrData hrDataExtended;
        /// <summary>
        /// Constructor for Polar reader
        /// </summary>
        public PolarReader()
        {
            //initilise the lists
            parametersList = new List<string>();
            noteList = new List<string>();
            intTimeList = new List<string>();
            intNotesList = new List<string>();
            extraDataList = new List<string>();
            lapNameList = new List<string>();
            summary123List = new List<string>();
            summaryThList = new List<string>();
            hrZoneList = new List<string>();
            swapTimeList = new List<string>();
            tripList = new List<string>();
            hrDataList = new List<string>();
        }

        private string GetMonitorType(string raw)
        {
            raw = raw.Split('=')[1];
            switch (raw)
            {
                case "1":
                    return "Polar Sport Tester / Vantage XL";
          
                case "2":
                    return "Polar Vantage NV (VNV)";
             
                case "3":
                    return "Polar Accurex Plus";
             
                case "4":
                    return "Polar XTrainer Plus";
            
                case "6":
                    return "Polar S520";
          
                case "7":
                    return "Polar Coach";
            
                case "8":
                    return "Polar S210";
             
                case "9":
                    return "Polar S410";
           
                case "10":
                    return "Polar S510";
             
                case "11":
                    return "Polar S610 / S610i";
              
                case "12":
                    return "Polar S710 / S710i / S720i";
          
                case "13":
                    return "Polar S810 / S810i";
              
                case "15":
                    return "Polar E600";
                case "20":
                    return "Polar AXN500";
             
                case "21":
                    return "Polar AXN700";
          
                case "22":
                    return "Polar S625X / S725X";
            
                case "23":
                    return "Polar S725";
        
                case "33":
                    return "Polar CS400";
              
                case "34":
                    return "Polar CS600X";
                case "35":
                    return "Polar CS600";
                  
                case "36":
                    return "Polar RS400";
                  
                case "37":
                    return "Polar RS800";
                    
                case "38":
                    return "Polar RS800X";
                
                    


                default:
                    return "UNKNOWN";
                   
            }

        }
#region Getters and setters
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> ParametersList { get => parametersList;  }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> NoteList { get => noteList; }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> IntTimeList { get => intTimeList;  }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> IntNotesList { get => intNotesList;  }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> ExtraDataList { get => extraDataList;  }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> LapNameList { get => lapNameList; }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> Summary123List { get => summary123List;  }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> SummaryThList { get => summaryThList;  }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> HrZoneList { get => hrZoneList; }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> SwapTimeList { get => swapTimeList;  }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> TripList { get => tripList;  }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> HrDataList { get => hrDataList; }
        public Dictionary<string, string> SummaryEuro { get => summaryEuro; set => summaryEuro = value; }
        public Dictionary<string, string> SummaryUS { get => summaryUS; set => summaryUS = value; }
        public bool UnitBool { get => unitBool; set => unitBool = value; }
        #endregion
        public void ReadFile(string filePath)
        {
            this.filePath = filePath;
            SeparateData();
        }

        public void SeparateData()
        {

            using (StreamReader sr = new StreamReader(filePath))
            {
                bool parameters, note, intTime, intNotes, extraData, lapName, summary123, summaryTh, hrZone, swapTime, trip, hrData;
                parameters = note = intTime = intNotes = extraData = lapName = summary123 = summaryTh = hrZone = swapTime = trip = hrData = false;
                string line;


                // Read and display lines from the file until 
                // the end of the file is reached. 
                while ((line = sr.ReadLine()) != null)
                {

                    switch (line)
                    {
                        case "[Params]":
                            parameters = true;
                            break;
                        case "[Note]":
                            note = true;
                            parameters = false;
                            break;
                        case "[IntTimes]":
                            intTime = true;
                            note = false;
                            break;
                        case "[IntNotes]":
                            intNotes = true;
                            intTime = false;
                            break;
                        case "[ExtraData]":
                            extraData = true;
                            intNotes = false;
                            break;
                        case "[LapNames]":
                            lapName = true;
                            extraData = false;
                            break;
                        case "[Summary-123]":
                            summary123 = true;
                            lapName = false;
                            break;
                        case "[Summary-TH]":
                            summaryTh = true;
                            summary123 = false;
                            break;
                        case "[HRZones]":
                            hrZone = true;
                            summaryTh = false;
                            break;
                        case "[SwapTimes]":
                            swapTime = true;
                            hrZone = false;
                            break;
                        case "[Trip]":
                            trip = true;
                            swapTime = false;
                            break;
                        case "[HRData]":
                            hrData = true;
                            trip = false;
                            break;
                    }
                    if (parameters)
                    {
                        parametersList.Add(line);
                    }
                    else if (note)
                    {
                        noteList.Add(line);
                    }
                    else if (intTime)
                    {
                        intTimeList.Add(line);
                    }
                    else if (intNotes)
                    {
                        intNotesList.Add(line);
                    }
                    else if (extraData)
                    {
                        extraDataList.Add(line);
                    }
                    else if (lapName)
                    {
                        lapNameList.Add(line);
                    }
                    else if (summary123)
                    {
                        summary123List.Add(line);
                    }
                    else if (summaryTh)
                    {
                        summaryThList.Add(line);
                    }
                    else if (hrZone)
                    {
                        hrZoneList.Add(line);
                    }
                    else if (swapTime)
                    {
                        swapTimeList.Add(line);
                    }
                    else if (trip)
                    {
                        tripList.Add(line);
                    }
                    else if (hrData)
                    {
                        hrDataList.Add(line);
                    }

                }



            }

            //we need to separate the data out futher
            Console.WriteLine(parametersList.ElementAt(1));
            version = Convert.ToInt32(parametersList.ElementAt(1).Split('=')[1]);
            monitor = GetMonitorType(parametersList.ElementAt(2));
            if (version <= 105)
            {
                mode = new Mode(parametersList.ElementAt(3).Split('=')[1]);
                smode = null;
            }
            else if (version >= 106)
            {
                smode = new Smode(version, parametersList.ElementAt(3).Split('=')[1]);
                
                mode = null;
            }
            date = parametersList.ElementAt(4).Split('=')[1];
            startTime = parametersList.ElementAt(5).Split('=')[1];
            
            length = parametersList.ElementAt(6).Split('=')[1];
            interval = Convert.ToInt32(parametersList.ElementAt(7).Split('=')[1]);
            upper1 = Convert.ToInt32(parametersList.ElementAt(8).Split('=')[1]);
            lower1 = Convert.ToInt32(parametersList.ElementAt(9).Split('=')[1]);
            upper2 = Convert.ToInt32(parametersList.ElementAt(10).Split('=')[1]);
            lower2 = Convert.ToInt32(parametersList.ElementAt(11).Split('=')[1]); 
            upper3 = Convert.ToInt32(parametersList.ElementAt(12).Split('=')[1]);
            lower3 = Convert.ToInt32(parametersList.ElementAt(13).Split('=')[1]);
            timer1 = parametersList.ElementAt(14).Split('=')[1]; ;
            timer2 = parametersList.ElementAt(15).Split('=')[1]; ;
            timer3 = parametersList.ElementAt(16).Split('=')[1]; ;
            activeLimit = parametersList.ElementAt(17).Split('=')[1]; 
            maxHR = Convert.ToInt32(parametersList.ElementAt(18).Split('=')[1]);
            restHR = Convert.ToInt32(parametersList.ElementAt(19).Split('=')[1]);
            startDelay = Convert.ToInt32(parametersList.ElementAt(20).Split('=')[1]);
            VO2max = Convert.ToInt32(parametersList.ElementAt(21).Split('=')[1]);
            weight = Convert.ToInt32(parametersList.ElementAt(22).Split('=')[1]);
            //we remove the header that was used for detection [Hr Data]
            hrDataList.RemoveAt(0);
            if (version <= 105)
            {
                hrDataExtended = new HrData(unitBool, version, hrDataList, mode.CadAltInt);
            }
            else
            {
                hrDataExtended = new HrData(unitBool, version, hrDataList);
            }

            //Storing the summary data
            if (!unitBool)
            {
                //total distance not sure if for that trip or the odometer
                summaryEuro.Add("TotalDistanceTrip",""+(Convert.ToDouble(tripList.ElementAt(1))/10));
                summaryUS.Add("TotalDistanceTrip",""+((Convert.ToDouble(tripList.ElementAt(1))/10)* 0.621371));
                //total distance recorded by odometer
                summaryEuro.Add("TotalDistanceOdometer", "" + Convert.ToDouble(tripList.ElementAt(8)));
                summaryUS.Add("TotalDistanceOdometer", "" + (Convert.ToDouble(tripList.ElementAt(8)) * 0.621371));
                //Average Speed
                summaryEuro.Add("AverageSpeed",""+(Convert.ToDouble(tripList.ElementAt(6))/128));
                summaryUS.Add("AverageSpeed", "" + ((Convert.ToDouble(tripList.ElementAt(6))/128)* 0.6213711922));
                //maximum speed
                summaryEuro.Add("MaxSpeed", "" + (Convert.ToDouble(tripList.ElementAt(7))/128));
                summaryUS.Add("MaxSpeed", "" + ((Convert.ToDouble(tripList.ElementAt(7))/128) * 0.6213711922));
                //Average Heart Rate
                int averageHeartRate = 0;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    averageHeartRate = averageHeartRate + data.HeartRate;
                }
                averageHeartRate = averageHeartRate / hrDataExtended.DataEuro.Count;
                summaryEuro.Add("AverageHeartRate",""+averageHeartRate);
                summaryUS.Add("AverageHeartRate",""+averageHeartRate);
                //Max Heart Rate
                summaryEuro.Add("MaxHeartRate", "" + maxHR);
                summaryUS.Add("MaxHeartRate",""+ maxHR);
                //Min Heart Rate
                int minHeartRate = restHR;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    if (data.HeartRate < minHeartRate)
                    {
                        minHeartRate = data.HeartRate;
                    }
                }
                summaryEuro.Add("MinHeartRate",""+minHeartRate);
                summaryUS.Add("MinHeartRate",""+minHeartRate);
                //Average power
                int PowerAverage = 0;
                
                
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    PowerAverage = PowerAverage + data.Power;
                }
               PowerAverage = PowerAverage / hrDataExtended.DataEuro.Count;


               

               
                summaryEuro.Add("AveragePower", ""+ PowerAverage);
                summaryUS.Add("AveragePower", ""+ PowerAverage);
                //Max Power
                int maxpower = 0;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    if (data.Power > maxpower)
                    {
                        maxpower = data.Power;
                    }
                }
                summaryEuro.Add("MaxPower",""+maxpower);
                summaryUS.Add("MaxPower",""+maxpower);
                //Average Altitude
                if (version == 102)
                {
                    summaryEuro.Add("AverageAltitude", "" + (Convert.ToDouble(tripList.ElementAt(4))/10));
                    summaryUS.Add("AverageAltitude", "" + ((Convert.ToDouble(tripList.ElementAt(4))/10) * 3.280839895));
                }
                else
                {
                    summaryEuro.Add("AverageAltitude", "" + (Convert.ToDouble(tripList.ElementAt(4))));
                    summaryUS.Add("AverageAltitude", "" + (Convert.ToDouble(tripList.ElementAt(4)) * 3.280839895));
                }

                //Max Altitude
                if (version == 102)
                {
                    summaryEuro.Add("MaxAltitude", "" + (Convert.ToDouble(tripList.ElementAt(5))/10));
                    summaryUS.Add("MaxAltitude", "" + ((Convert.ToDouble(tripList.ElementAt(5))/10) * 3.280839895));
                }
                else
                {
                    summaryEuro.Add("MaxAltitude", "" + (Convert.ToDouble(tripList.ElementAt(5))));
                    summaryUS.Add("MaxAltitude", "" + (Convert.ToDouble(tripList.ElementAt(5)) * 3.280839895));

                }
                


            }
            else
            {
                //us starting values
                //total distance not sure if for that trip or the odometer
                summaryEuro.Add("TotalDistanceTrip", "" + (Convert.ToDouble(tripList.ElementAt(1)) / 10) * 1.60934);
                summaryUS.Add("TotalDistanceTrip", "" + ((Convert.ToDouble(tripList.ElementAt(1)) / 10)));
                //total distance recorded by odometer
                summaryEuro.Add("TotalDistanceOdometer", "" + (Convert.ToDouble(tripList.ElementAt(8))* 1.60934));
                summaryUS.Add("TotalDistanceOdometer", "" + (Convert.ToDouble(tripList.ElementAt(8))));
                //Average Speed
                summaryEuro.Add("AverageSpeed", "" + ((Convert.ToDouble(tripList.ElementAt(6)) / 128)* 1.60934));
                summaryUS.Add("AverageSpeed", "" + (Convert.ToDouble(tripList.ElementAt(6)) / 128) );
                //maximum speed
                summaryEuro.Add("MaxSpeed", "" + ((Convert.ToDouble(tripList.ElementAt(7)) / 128)*1.60934));
                summaryUS.Add("MaxSpeed", "" + (Convert.ToDouble(tripList.ElementAt(7)) / 128) );
                //Average Heart Rate
                int averageHeartRate = 0;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    averageHeartRate = averageHeartRate + data.HeartRate;
                }
                averageHeartRate = averageHeartRate / hrDataExtended.DataEuro.Count;
                summaryEuro.Add("AverageHeartRate", "" + averageHeartRate);
                summaryUS.Add("AverageHeartRate", "" + averageHeartRate);
                //Max Heart Rate
                summaryEuro.Add("MaxHeartRate", "" + maxHR);
                summaryUS.Add("MaxHeartRate", "" + maxHR);
                //Min Heart Rate
                int minHeartRate = restHR;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    if (data.HeartRate < minHeartRate)
                    {
                        minHeartRate = data.HeartRate;
                    }
                }
                summaryEuro.Add("MinHeartRate", "" + minHeartRate);
                summaryUS.Add("MinHeartRate", "" + minHeartRate);
                //Average power
                int PowerAverage = 0;


                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    PowerAverage = PowerAverage + data.Power;
                }
                PowerAverage = PowerAverage / hrDataExtended.DataEuro.Count;





                summaryEuro.Add("AveragePower", "" + PowerAverage);
                summaryUS.Add("AveragePower", "" + PowerAverage);
                //Max Power
                int maxpower = 0;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    if (data.Power > maxpower)
                    {
                        maxpower = data.Power;
                    }
                }
                summaryEuro.Add("MaxPower", "" + maxpower);
                summaryUS.Add("MaxPower", "" + maxpower);
                //Average Altitude
                if (version == 102)
                {
                    summaryEuro.Add("AverageAltitude", "" + ((Convert.ToDouble(tripList.ElementAt(4)) / 10) * 0.3048));
                    summaryUS.Add("AverageAltitude", "" + (Convert.ToDouble(tripList.ElementAt(4)) / 10) );
                }
                else
                {
                    summaryEuro.Add("AverageAltitude", "" + (Convert.ToDouble(tripList.ElementAt(4)) * 0.3048));
                    summaryUS.Add("AverageAltitude", "" + (Convert.ToDouble(tripList.ElementAt(4))));
                }

                //Max Altitude
                if (version == 102)
                {
                    summaryEuro.Add("MaxAltitude", "" +( (Convert.ToDouble(tripList.ElementAt(5)) / 10)* 0.3048));
                    summaryUS.Add("MaxAltitude", "" + (Convert.ToDouble(tripList.ElementAt(5)) / 10));
                }
                else
                {
                    summaryEuro.Add("MaxAltitude", "" + ((Convert.ToDouble(tripList.ElementAt(5)))* 0.3048));
                    summaryUS.Add("MaxAltitude", "" + (Convert.ToDouble(tripList.ElementAt(5))) );

                }
            }




        }
    }
}
