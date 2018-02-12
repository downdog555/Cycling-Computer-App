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
            summaryEuro = new Dictionary<string, string>();
            summaryUS = new Dictionary<string, string>();
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
        public List<string> ParametersList { get { return parametersList; }  }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> NoteList { get {return noteList; } }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> IntTimeList { get { return intTimeList;  } }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> IntNotesList { get { return intNotesList;  } }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> ExtraDataList { get { return extraDataList;  } }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> LapNameList { get { return lapNameList; } }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> Summary123List { get { return summary123List;  } }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> SummaryThList { get { return summaryThList;  } }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> HrZoneList { get { return hrZoneList; } }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> SwapTimeList { get { return swapTimeList; } }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> TripList { get { return tripList; } }
        /// <summary>
        /// Getter for data
        /// </summary>
        public List<string> HrDataList { get { return hrDataList; } }
        public Dictionary<string, string> SummaryEuro { get { return summaryEuro; } }
        public Dictionary<string, string> SummaryUS { get { return summaryUS; } }
        public bool UnitBool { get { return unitBool; } }
        #endregion
        public void ReadFile(string filePath)
        {
            Console.WriteLine("We are in polar reader for read file");
            this.filePath = filePath;
            Console.WriteLine("We are after asigning file path");
            SeparateData();
        }

        public void SeparateData()
        {
            Console.WriteLine("We are in separeate data");
            try {
                Console.WriteLine("We are in try catch");
                using (StreamReader sr = new StreamReader(filePath))
                {
                    Console.WriteLine("We are in reader");
                    bool parameters, note, intTime, intNotes, extraData, lapName, summary123, summaryTh, hrZone, swapTime, trip, hrData;
                    parameters = note = intTime = intNotes = extraData = lapName = summary123 = summaryTh = hrZone = swapTime = trip = hrData = false;
                    string line;


                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("We are reading data");

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
            }
            catch (Exception e)
            {
                Console.WriteLine("Error In reading File: "+e.Message);
            }
           

            //we need to separate the data out futher
            //Console.WriteLine(parametersList.ElementAt(1));
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
                
                //total distance 
                double distance = 0;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    double hoursSpeed = data.Speed / 10;
                   // Console.WriteLine("Hours: "+hoursSpeed);
                    double minsSpeed = hoursSpeed / 60;
                    //Console.WriteLine("mins: " + minsSpeed);
                    double secondSpeed = minsSpeed / 60;
                    //Console.WriteLine("secondfs: " + secondSpeed);
                    double intervalDistance = secondSpeed * interval;
                   // Console.WriteLine("int distance: " + intervalDistance);
                    distance = distance + intervalDistance;
                   // Console.WriteLine("cumaltive distnacew: " + distance);
                    //Console.WriteLine("########");
                }
                summaryEuro.Add("Total Distance",""+distance);
                summaryUS.Add("Total Distance",""+(distance* 0.621371));
                
                //Average Speed

                double averageSpeed = 0;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    averageSpeed = averageSpeed + data.Speed;
                }
                averageSpeed = averageSpeed / hrDataExtended.DataEuro.Count;
                averageSpeed = averageSpeed / 10;
                summaryEuro.Add("Average Speed",""+ averageSpeed);
                summaryUS.Add("Average Speed", "" + (averageSpeed * 0.6213711922));
               
                //maximum speed
                string hrdatastring = "";
                double speed = 0;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    if (speed < data.Speed)
                    {
                        speed = data.Speed;
                    }
                }
                hrdatastring = "" + (speed / 10);
                summaryEuro.Add("Maximum Speed", "" + Convert.ToDouble(hrdatastring));
                summaryUS.Add("Maximum Speed", "" + ((Convert.ToDouble(hrdatastring) * 0.6213711922)));

                

                //Average Heart Rate
                int averageHeartRate = 0;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    averageHeartRate = averageHeartRate + data.HeartRate;
                }
                averageHeartRate = averageHeartRate / hrDataExtended.DataEuro.Count;
                summaryEuro.Add("Average Heart Rate",""+averageHeartRate);
                summaryUS.Add("Average Heart Rate",""+averageHeartRate);
              
                //Max Heart Rate
                summaryEuro.Add("Maximum Heart Rate", "" + maxHR);
                summaryUS.Add("Maximum Heart Rate",""+ maxHR);
               
                //Min Heart Rate
                int minHeartRate = restHR;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    if (data.HeartRate < minHeartRate)
                    {
                        minHeartRate = data.HeartRate;
                    }
                }
                summaryEuro.Add("Minimum Heart Rate",""+minHeartRate);
                summaryUS.Add("Minimum Heart Rate",""+minHeartRate);
                
                //Average power
                int PowerAverage = 0;
                
                
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    PowerAverage = PowerAverage + data.Power;
                }
               PowerAverage = PowerAverage / hrDataExtended.DataEuro.Count;


               

               
                summaryEuro.Add("Average Power", ""+ PowerAverage);
                summaryUS.Add("Average Power", ""+ PowerAverage);
                
                //Max Power
                int maxpower = 0;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    if (data.Power > maxpower)
                    {
                        maxpower = data.Power;
                    }
                }
                summaryEuro.Add("Maximum Power",""+maxpower);
                summaryUS.Add("Maximum Power",""+maxpower);
                
                //Average Altitude

                if (version == 105)
                    {
                        //mode should exist
                        if (mode.CadAltInt == 0)
                        {
                            //means cadence


                        }
                        else if (mode.CadAltInt == 1)
                        {

                        }

                    }
                    else
                    {
                        double averageAlt = 0;
                        foreach (HrDataSingle data in hrDataExtended.DataEuro)
                        {
                            
                            averageAlt = averageAlt +  data.Altitude;
                            
                        }
                    Console.WriteLine(averageAlt);
                        averageAlt = averageAlt / hrDataExtended.DataEuro.Count;
                        summaryEuro.Add("Average Altitude", "" + averageAlt);
                        SummaryUS.Add("Average Altitude", "" + (averageAlt * 3.280839895));
                    }

                



                //Max Altitude

                if (version == 105)
                    {
                        //mode should exist
                        if (mode.CadAltInt == 0)
                        {
                            //means cadence
                            
                            
                        }
                        else if (mode.CadAltInt == 1)
                        {

                        }
                        
                    }
                    else
                    {
                    
                    double maxAlt = 0;
                        foreach (HrDataSingle data in hrDataExtended.DataEuro)
                        {
                            if (maxAlt < data.Altitude)
                            {
                                maxAlt = data.Altitude;
                            }
                        }
                  
                    summaryEuro.Add("Maximum Altitude" , ""+(maxAlt));
                    Console.WriteLine("We have finished reading");
                    SummaryUS.Add("Maximum Altitude", ""+(maxAlt * 3.280839895));
                    }


               




            }
            else
            {
                //us starting values
                //total distance not sure if for that trip or the odometer
                double distance = 0;
                foreach (HrDataSingle data in hrDataExtended.DataUS)
                {
                    double hoursSpeed = data.Speed / 10;
                    // Console.WriteLine("Hours: "+hoursSpeed);
                    double minsSpeed = hoursSpeed / 60;
                    //Console.WriteLine("mins: " + minsSpeed);
                    double secondSpeed = minsSpeed / 60;
                    //Console.WriteLine("secondfs: " + secondSpeed);
                    double intervalDistance = secondSpeed * interval;
                    // Console.WriteLine("int distance: " + intervalDistance);
                    distance = distance + intervalDistance;
                    // Console.WriteLine("cumaltive distnacew: " + distance);
                    //Console.WriteLine("########");
                }
                summaryEuro.Add("Total Distance", "" + (distance * 1.60934));
                summaryUS.Add("Total Distance", "" + distance);

                //Average Speed

                double averageSpeed = 0;
                foreach (HrDataSingle data in hrDataExtended.DataUS)
                {
                    averageSpeed = averageSpeed + data.Speed;
                }
                averageSpeed = averageSpeed / hrDataExtended.DataEuro.Count;
                averageSpeed = averageSpeed / 10;
                summaryEuro.Add("Average Speed", "" + (averageSpeed * 1.60934));
                summaryUS.Add("Average Speed", "" + (averageSpeed ));

                //maximum speed

                string hrdatastring = "";
                double speed = 0;
                foreach (HrDataSingle data in hrDataExtended.DataUS)
                {
                    if (speed < data.Speed)
                    {
                        speed = data.Speed;
                    }
                }
                hrdatastring = "" + (speed / 10);
                summaryEuro.Add("Maximum Speed", "" + (Convert.ToDouble(hrdatastring) * 1.60934));
                summaryUS.Add("Maximum Speed", "" + ((Convert.ToDouble(hrdatastring))));

               
                //Average Heart Rate
                int averageHeartRate = 0;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    averageHeartRate = averageHeartRate + data.HeartRate;
                }
                averageHeartRate = averageHeartRate / hrDataExtended.DataEuro.Count;
                summaryEuro.Add("Average Heart Rate", "" + averageHeartRate);
                summaryUS.Add("Average Heart Rate", "" + averageHeartRate);
                //Max Heart Rate
                summaryEuro.Add("Maximum Heart Rate", "" + maxHR);
                summaryUS.Add("Maximum Heart Rate", "" + maxHR);
                //Min Heart Rate
                int minHeartRate = restHR;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    if (data.HeartRate < minHeartRate)
                    {
                        minHeartRate = data.HeartRate;
                    }
                }
                summaryEuro.Add("Minimum Heart Rate", "" + minHeartRate);
                summaryUS.Add("Minimum Heart Rate", "" + minHeartRate);
                //Average power
                int PowerAverage = 0;


                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    PowerAverage = PowerAverage + data.Power;
                }
                PowerAverage = PowerAverage / hrDataExtended.DataEuro.Count;





                summaryEuro.Add("Average Power", "" + PowerAverage);
                summaryUS.Add("Average Power", "" + PowerAverage);
                //Max Power
                int maxpower = 0;
                foreach (HrDataSingle data in hrDataExtended.DataEuro)
                {
                    if (data.Power > maxpower)
                    {
                        maxpower = data.Power;
                    }
                }
                summaryEuro.Add("Max Power", "" + maxpower);
                summaryUS.Add("Max Power", "" + maxpower);
                //Average Altitude
                if (version == 105)
                {
                    //mode should exist
                    if (mode.CadAltInt == 0)
                    {
                        //means cadence


                    }
                    else if (mode.CadAltInt == 1)
                    {

                    }

                }
                else
                {
                    double averageAlt = 0;
                    foreach (HrDataSingle data in hrDataExtended.DataUS)
                    {
                       
                            averageAlt = averageAlt + data.Altitude;
                        
                    }
                    averageAlt = averageAlt / hrDataExtended.DataEuro.Count;
                    summaryEuro.Add("Average Altitude", "" + (averageAlt * 0.3048));
                    SummaryUS.Add("Average Altitude", "" + (averageAlt));
                }


                //Max Altitude
                if (version == 105)
                {
                    //mode should exist
                    if (mode.CadAltInt == 0)
                    {
                        //means cadence


                    }
                    else if (mode.CadAltInt == 1)
                    {

                    }

                }
                else
                {
                    double maxAlt = 0;
                    foreach (HrDataSingle data in hrDataExtended.DataUS)
                    {
                        if (maxAlt < data.Altitude)
                        {
                            maxAlt = data.Altitude;
                        }
                    }
                    summaryEuro.Add("Max Altitude", "" + (maxAlt * 0.3048));
                    SummaryUS.Add("Max Altitude", "" + (maxAlt));
                }
               
            }
            




        }
    }
}
