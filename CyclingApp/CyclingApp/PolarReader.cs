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
        private List<string> parametersList, noteList, intTimeList, intNotesList, extraDataList, lapNameList, summary123List, summaryThList, hrZoneList, swapTimeList, tripList, hrDataList, rideInfo;
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
            rideInfo = new List<string>();
        }

        /// <summary>
        /// called to reset all the lists that is used during reading
        /// </summary>
        private void resetLists()
        {
            //reset the lists
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
            rideInfo = new List<string>();
        }

        /// <summary>
        /// Called to get summary data for a specified time frame
        /// </summary>
        /// <param name="start">the start time </param>
        /// <param name="end">the end time</param>
        public Dictionary<string, string>[] GetSummarySpecifiedTime(DateTime start, DateTime end)
        {
            //we first get the data set we need and call all of the funtions and return the list created
            TimeSpan timeGroup = end - start;
            int groupLength = (int)timeGroup.TotalSeconds;
            DateTime temp = new DateTime(start.Year, start.Month, start.Day, 0, 0, 0);
            TimeSpan startTime = new TimeSpan(start.Hour, start.Minute, start.Second);
            TimeSpan endTime = new TimeSpan(end.Hour, end.Minute, end.Second);
            int endPostion = (int)(endTime.TotalSeconds/interval)-1;
            int startPosition = (int)startTime.TotalSeconds ;
            startPosition = (startPosition / interval)-1;
            if (startPosition < 0)
            {
                startPosition = 0;
            }
            groupLength = (groupLength / interval) + startPosition;
            List<HrDataSingle> tempData = new List<HrDataSingle>();

            for (int x = startPosition; x <= (endPostion);x++)
            {
                //Console.WriteLine(""+x);
                if (!smode.Unit)
                {
                    tempData.Add(hrDataExtended.DataEuro.ElementAt(x));

                }
                else
                {
                    tempData.Add(hrDataExtended.DataUS.ElementAt(x));
                }
               
            }

            Dictionary<string, string> sumEuro = new Dictionary<string, string>();
            Dictionary<string, string> sumUS = new Dictionary<string, string>();

            //we have the list then we need to genreate the values to pass back

            //Storing the summary data
            if (!unitBool)
            {


                if (smode.Speed)
                {
                    //total distance 
                    double distance = 0;
                    distance = GetTotalDistance(tempData);
                    sumEuro.Add("Total Distance", "" + Math.Round(distance, 2) + "KM");
                    sumUS.Add("Total Distance", "" + Math.Round((distance * 0.621371), 2) + "Miles");

                    //Average Speed

                    double averageSpeed = GetAverageSpeed(tempData);

                    sumEuro.Add("Average Speed", "" + Math.Round(averageSpeed) + "KPH");
                    sumUS.Add("Average Speed", "" + Math.Round((averageSpeed * 0.6213711922), 2) + "MPH");

                    //maximum speed
                    double speed = GetMaxSpeed(tempData);

                    sumEuro.Add("Maximum Speed", "" + speed + "KPH");
                    sumUS.Add("Maximum Speed", "" + Math.Round((speed * 0.6213711922), 2) + "MPH");

                }






                //Average Heart Rate
                int averageHeartRate = GetAverageHeartRate(tempData);

                sumEuro.Add("Average Heart Rate", "" + averageHeartRate);
                sumUS.Add("Average Heart Rate", "" + averageHeartRate);

                int maxHeartRate = GetMaxHeartRate(tempData);
                //Max Heart Rate
                sumEuro.Add("Maximum Heart Rate", "" + maxHeartRate + " BPM");
                sumUS.Add("Maximum Heart Rate", "" + maxHeartRate + " BPM");

                //Min Heart Rate
                int minHeartRate = GetMinHeartRate(tempData); ;

                sumEuro.Add("Minimum Heart Rate", "" + minHeartRate + " BPM");
                sumUS.Add("Minimum Heart Rate", "" + minHeartRate + " BPM");

                if (smode.Power)
                {
                    //Average power
                    int PowerAverage = GetAveragePower(tempData);
                    sumEuro.Add("Average Power", "" + PowerAverage);
                    sumUS.Add("Average Power", "" + PowerAverage);

                    //Max Power
                    int maxpower = GetMaxPower(tempData);

                    sumEuro.Add("Maximum Power", "" + maxpower);
                    sumUS.Add("Maximum Power", "" + maxpower);
                }


                if (smode.Altitude)
                {
                    //Average Altitude

                    double averageAlt = GetAverageAltitude(tempData); ;

                    sumEuro.Add("Average Altitude", "" + Math.Round(averageAlt, 2) + " Meters");
                    sumUS.Add("Average Altitude", "" + Math.Round((averageAlt * 3.280839895), 2) + " Feet");






                    //Max Altitude



                    double maxAlt = GetMaxAltitude(tempData);


                    sumEuro.Add("Maximum Altitude", "" + (maxAlt) + " Meters");

                    sumUS.Add("Maximum Altitude", "" + Math.Round((maxAlt * 3.280839895), 2) + " Feet");

                }










            }
            else
            {

                if (smode.Speed)
                {
//#TODO
                    //total distance not sure if for that trip or the odometer
                    double distance = GetTotalDistance(tempData);

                    sumEuro.Add("Total Distance", "" + Math.Round((distance * 1.60934), 2) + "KM");
                    sumUS.Add("Total Distance", "" + Math.Round(distance, 2) + "Miles");

                    //Average Speed

                    double averageSpeed = GetAverageSpeed(tempData); ;

                    sumEuro.Add("Average Speed", "" + Math.Round((averageSpeed * 1.60934), 2) + " KPH");
                    sumUS.Add("Average Speed", "" + Math.Round(averageSpeed, 2) + " MPH");

                    //maximum speed

                    double speed = GetMaxSpeed(tempData);
                    sumEuro.Add("Maximum Speed", "" + Math.Round((speed * 1.60934), 2) + " KPH");
                    sumUS.Add("Maximum Speed", "" + speed + " MPH");
                }
                //us starting values



                //Average Heart Rate
                int averageHeartRate = GetAverageHeartRate(tempData);

                sumEuro.Add("Average Heart Rate", "" + averageHeartRate + " BPM");
                sumUS.Add("Average Heart Rate", "" + averageHeartRate + " BPM");

                int maxHeartRate = GetMaxHeartRate(tempData);

                //Max Heart Rate
                sumEuro.Add("Maximum Heart Rate", "" + maxHeartRate + " BPM");
                sumUS.Add("Maximum Heart Rate", "" + maxHeartRate + " BPM");
                //Min Heart Rate
                int minHeartRate = GetMinHeartRate(tempData);

                sumEuro.Add("Minimum Heart Rate", "" + minHeartRate + " BPM");
                sumUS.Add("Minimum Heart Rate", "" + minHeartRate + " BPM");

                if (smode.Power)
                {
                    //Average power
                    int PowerAverage = GetAveragePower(tempData);
                    sumEuro.Add("Average Power", "" + PowerAverage + " Watts");
                    sumUS.Add("Average Power", "" + PowerAverage + " Watts");
                    //Max Power
                    int maxpower = GetMaxPower(tempData);

                    sumEuro.Add("Max Power", "" + maxpower + " Watts");
                    sumUS.Add("Max Power", "" + maxpower + " Watts");
                }

                if (smode.Altitude)
                {
                    //Average Altitude

                    double averageAlt = GetAverageAltitude(tempData);

                    sumEuro.Add("Average Altitude", "" + Math.Round((averageAlt * 0.3048), 2) + " Meters");
                    sumUS.Add("Average Altitude", "" + Math.Round(averageAlt, 2) + " Feet");



                    //Max Altitude

                    double maxAlt = GetMaxAltitude(tempData);

                    sumEuro.Add("Max Altitude", "" + Math.Round((maxAlt * 0.3048), 2) + "Meters");
                    sumUS.Add("Max Altitude", "" + Math.Round(maxAlt, 2) + "Feet");
                }




            }
            //advanced metrics/normalised power
            if (smode.Power)
            {
                //we then can calc, we have the temp data
                int normPower = GetNormalisedPower(tempData);
                sumEuro.Add("NormalisedPower",""+normPower+" W");
                sumUS.Add("NormalisedPower", "" + normPower + " W");

            }

             Dictionary<string, string>[] returnData = { sumEuro, sumUS};
            return returnData;
        }

        private int GetNormalisedPower(List<HrDataSingle> dataList)
        {
            /**
             * 1. Starting at the beginning of the data and calculating a 30-second rolling average for power;        

                2. Raising the values obtained in step 1 to the fourth power;        

                3. Taking the average of all the values obtained in step 2; and        

                4. Taking the fourth root of the number obtained in step 3. This is Normalized Power.
            **/
            List<long> averages = new List<long>();
            try
            {
                for (int i = 0; i < dataList.Count; i++)
                {
                    long tempPower = 0;
                    for (int x = 0; x < 30; x++)
                    {
                        tempPower = tempPower + dataList.ElementAt(x + i).Power;

                    }
                    tempPower = tempPower / 30;
                    averages.Add(tempPower);

                }

            }
            catch (Exception e)
            {

            }


            //convert list to array
            long[] averageInt = averages.ToArray();

            //raise to power of 4
            for (int i = 0; i < averageInt.Length;i++)
            {
                averageInt[i] = (long)Math.Pow( (double)averageInt[i], 4);
            }

            //take avaerage
            long averagePower = 0;
            for (int i = 0; i < averageInt.Length; i++)
            {
                averagePower = averagePower + averageInt[i];
            }

            averagePower = averagePower / averageInt.Length;
            
            long root = (long)Math.Pow(averagePower, ((double)1/4));
            Console.WriteLine(""+root);
            return (int)root;
        }

        /// <summary>
        /// Used to calculate the total distance traveled
        /// </summary>
        /// <param name="dataList">data used to calculate</param>
        /// <returns>The total distance</returns>
        private double GetTotalDistance(List<HrDataSingle> dataList)
        {
            double distance = 0;
            foreach (HrDataSingle data in dataList)
            {
                
                double hoursSpeed = data.Speed ;
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
            return distance;
        }

        private double GetAverageSpeed(List<HrDataSingle> dataList)
        {
            double averageSpeed = 0;
            foreach (HrDataSingle data in dataList)
            {
                averageSpeed = averageSpeed + data.Speed;
            }
            averageSpeed = averageSpeed / dataList.Count;
            
            return averageSpeed;

        }

        private double GetMaxSpeed(List<HrDataSingle> dataList)
        {
            double speed = 0;
            foreach (HrDataSingle data in dataList)
            {
                if (speed < data.Speed)
                {
                    speed = data.Speed;
                }
            }
           

            return speed;
        }
        private int GetMaxHeartRate(List<HrDataSingle> dataList)
        {
            int maxHeartRate = 0;
            foreach (HrDataSingle data in dataList)
            {
                if (data.HeartRate > maxHeartRate)
                {
                    maxHeartRate = data.HeartRate;
                }
            }
            return maxHeartRate;
        }

        /// <summary>
        /// used to calculate and pass back the Intensity Factor
        /// </summary>
        /// <param name="np">normalised power</param>
        /// <param name="ftp">Functional Threshold Power</param>
        /// <returns>intesity factor as percentage</returns>
        public double GetIF(double np, int ftp)
        {
            double IF = 0;

            IF = (np / ftp)*100;

            return IF;
        }

        private int GetAverageHeartRate(List<HrDataSingle> dataList)
        {
            int averageHeartRate = 0;
            foreach (HrDataSingle data in dataList)
            {
                averageHeartRate = averageHeartRate + data.HeartRate;
            }
            averageHeartRate = averageHeartRate / dataList.Count;
          
            return averageHeartRate;
        }

        private int GetMinHeartRate(List<HrDataSingle> dataList)
        {
            int minHeartRate = restHR;
            foreach (HrDataSingle data in dataList)
            {
                if (data.HeartRate < minHeartRate)
                {
                    minHeartRate = data.HeartRate;
                }
            }

            return minHeartRate;
        }

        private int GetAveragePower(List<HrDataSingle> dataList)
        {
            double PowerAverage = 0;
            foreach (HrDataSingle data in dataList)
            {
                PowerAverage = PowerAverage + data.Power;
            }
            PowerAverage = PowerAverage / dataList.Count;

            return (int)PowerAverage;
        }

        private int GetMaxPower(List<HrDataSingle> dataList)
        {
            int maxpower = 0;
            foreach (HrDataSingle data in dataList)
            {
                if (data.Power > maxpower)
                {
                    maxpower = data.Power;
                }

               
            }
            return maxpower;
        }

        private double GetAverageAltitude(List<HrDataSingle> dataList)
        {
            double averageAlt = 0;
            foreach (HrDataSingle data in dataList)
            {

                averageAlt = averageAlt + data.Altitude;

            }
         
            averageAlt = averageAlt / dataList.Count;

            return averageAlt;
        }

        private double GetMaxAltitude(List<HrDataSingle> dataList)
        {
            double maxAlt = 0; ;
            bool first = true;
            foreach (HrDataSingle data in dataList)
            {
                if (first)
                {
                    first = false;
                    maxAlt = data.Altitude;
                    continue;
                }
                if (maxAlt < data.Altitude)
                {
                    maxAlt = data.Altitude;
                }
            }

            return maxAlt;
        }

        /// <summary>
        /// Used to Pass The Ride Info Higher up
        /// </summary>
        /// <returns>list of strings with ride info</returns>
        public List<string> GetRideInfo()
        {
            return rideInfo;
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

        public HrData HrDataExtended
        {
            get
            {
                return hrDataExtended;
            }

            set
            {
                hrDataExtended = value;
            }
        }

        public Smode Smode
        {
            get
            {
                return smode;
            }

            set
            {
                smode = value;
            }
        }
        #endregion
        public void ReadFile(string filePath)
        {
            Console.WriteLine("We are in polar reader for read file");
            this.filePath = filePath;
            Console.WriteLine("We are after asigning file path");
            SeparateData();
        }

        /// <summary>
        /// flips the date as it is in incorrect format when supplied
        /// </summary>
        /// <returns>date in correct format</returns>
        public string FlipDate()
        {
            string newDate = "";

            newDate = date.Substring(6,2);
            newDate = newDate + "/" + date.Substring(4,2);
            newDate = newDate + "/" + date.Substring(0,4);



            return newDate;
        }

        /// <summary>
        /// function called to separate the data
        /// </summary>
        public void SeparateData()
        {
           // Console.WriteLine("We are in separeate data");
            try {
                //Console.WriteLine("We are in try catch");
                using (StreamReader sr = new StreamReader(filePath))
                {
                    //Console.WriteLine("We are in reader");
                    bool parameters, note, intTime, intNotes, extraData, lapName, summary123, summaryTh, hrZone, swapTime, trip, hrData;
                    parameters = note = intTime = intNotes = extraData = lapName = summary123 = summaryTh = hrZone = swapTime = trip = hrData = false;
                    string line;
                    
                    //Console.WriteLine("We are meme 1");
                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Console.WriteLine("We are reading data");
                        if (line.Equals(""))
                        {
                            continue;
                        }
                        switch (line)
                        {
                            case "[Params]":
                                parameters = true;
                                note = false;
                                intTime = false;
                                intNotes = false;
                                extraData = false;
                                lapName = false;
                                summary123 = false;
                                summaryTh = false;
                                hrZone = false;
                                swapTime = false;
                                trip = false;
                                hrData = false;
                                break;
                            case "[Note]":
                                parameters = false;
                                note = true;
                                intTime = false;
                                intNotes = false;
                                extraData = false;
                                lapName = false;
                                summary123 = false;
                                summaryTh = false;
                                hrZone = false;
                                swapTime = false;
                                trip = false;
                                hrData = false;
                                break;
                            case "[IntTimes]":
                                parameters = false;
                                note = false;
                                intTime = true;
                                intNotes = false;
                                extraData = false;
                                lapName = false;
                                summary123 = false;
                                summaryTh = false;
                                hrZone = false;
                                swapTime = false;
                                trip = false;
                                hrData = false;
                                break;
                            case "[IntNotes]":
                                parameters = false;
                                note = false;
                                intTime = false;
                                intNotes = true;
                                extraData = false;
                                lapName = false;
                                summary123 = false;
                                summaryTh = false;
                                hrZone = false;
                                swapTime = false;
                                trip = false;
                                hrData = false;
                                break;
                            case "[ExtraData]":
                                parameters = false;
                                note = false;
                                intTime = false;
                                intNotes = false;
                                extraData = true;
                                lapName = false;
                                summary123 = false;
                                summaryTh = false;
                                hrZone = false;
                                swapTime = false;
                                trip = false;
                                hrData = false;
                                break;
                            case "[LapNames]":
                                parameters = false;
                                note = false;
                                intTime = false;
                                intNotes = false;
                                extraData = false;
                                lapName = true;
                                summary123 = false;
                                summaryTh = false;
                                hrZone = false;
                                swapTime = false;
                                trip = false;
                                hrData = false;
                                break;
                            case "[Summary-123]":
                                parameters = false;
                                note = false;
                                intTime = false;
                                intNotes = false;
                                extraData = false;
                                lapName = false;
                                summary123 = true;
                                summaryTh = false;
                                hrZone = false;
                                swapTime = false;
                                trip = false;
                                hrData = false;
                                break;
                            case "[Summary-TH]":
                                parameters = false;
                                note = false;
                                intTime = false;
                                intNotes = false;
                                extraData = false;
                                lapName = false;
                                summary123 = false;
                                summaryTh = true;
                                hrZone = false;
                                swapTime = false;
                                trip = false;
                                hrData = false;
                                break;
                            case "[HRZones]":
                                parameters = false;
                                note = false;
                                intTime = false;
                                intNotes = false;
                                extraData = false;
                                lapName = false;
                                summary123 = false;
                                summaryTh = false;
                                hrZone = true;
                                swapTime = false;
                                trip = false;
                                hrData = false;
                                break;
                            case "[SwapTimes]":
                                parameters = false;
                                note = false;
                                intTime = false;
                                intNotes = false;
                                extraData = false;
                                lapName = false;
                                summary123 = false;
                                summaryTh = false;
                                hrZone = false;
                                swapTime = true;
                                trip = false;
                                hrData = false;
                                break;
                            case "[Trip]":
                                parameters = false;
                                note = false;
                                intTime = false;
                                intNotes = false;
                                extraData = false;
                                lapName = false;
                                summary123 = false;
                                summaryTh = false;
                                hrZone = false;
                                swapTime = false;
                                trip = true;
                                hrData = false;
                                break;
                            case "[HRData]":
                                parameters = false;
                                note = false;
                                intTime = false;
                                intNotes = false;
                                extraData = false;
                                lapName = false;
                                summary123 = false;
                                summaryTh = false;
                                hrZone = false;
                                swapTime = false;
                                trip = false;
                                hrData = true;
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

            //Console.WriteLine("We are meme 2");
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
            //Console.WriteLine("We are meme 3");
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
            date = FlipDate();
            
            rideInfo.Add(date);
            rideInfo.Add(startTime);
            rideInfo.Add(length);
            rideInfo.Add(""+interval);
            
           
           // Console.WriteLine("We are meme 5");
            //we remove the header that was used for detection [Hr Data]
            hrDataList.RemoveAt(0);
            if (version <= 105)
            {
                
                hrDataExtended = new HrData(unitBool, version, hrDataList, smode,mode.CadAltInt);
                //Console.WriteLine("We are meme 3.5");
            }
            else
            {
                hrDataExtended = new HrData(unitBool, version, hrDataList, smode);
                //Console.WriteLine("We are meme 3.51");
            }
            //Console.WriteLine("We are meme 3");
            //Storing the summary data
            if (!unitBool)
            {

                
                if (smode.Speed)
                {
                    //total distance 
                    double distance = 0;
                    distance = GetTotalDistance(HrDataExtended.DataEuro);
                    summaryEuro.Add("Total Distance", "" + Math.Round(distance,2) + "KM");
                    summaryUS.Add("Total Distance", "" + Math.Round((distance * 0.621371),2 )+ "Miles");

                    //Average Speed

                    double averageSpeed = GetAverageSpeed(hrDataExtended.DataEuro);

                    summaryEuro.Add("Average Speed", "" + Math.Round(averageSpeed) + "KPH");
                    summaryUS.Add("Average Speed", "" + Math.Round((averageSpeed * 0.6213711922),2) + "MPH");

                    //maximum speed
                    double speed = GetMaxSpeed(hrDataExtended.DataEuro);

                    summaryEuro.Add("Maximum Speed", "" + speed + "KPH");
                    summaryUS.Add("Maximum Speed", "" + Math.Round((speed * 0.6213711922),2) + "MPH");

                }

                
              

                

                //Average Heart Rate
                int averageHeartRate = GetAverageHeartRate(HrDataExtended.DataEuro);
               
                summaryEuro.Add("Average Heart Rate",""+averageHeartRate);
                summaryUS.Add("Average Heart Rate",""+averageHeartRate);

                int maxHeartRate = GetMaxHeartRate(hrDataExtended.DataEuro);
                //Max Heart Rate
                summaryEuro.Add("Maximum Heart Rate", "" + maxHeartRate + " BPM");
                summaryUS.Add("Maximum Heart Rate", "" + maxHeartRate + " BPM");

                //Min Heart Rate
                int minHeartRate = GetMinHeartRate(hrDataExtended.DataEuro); ;
                
                summaryEuro.Add("Minimum Heart Rate",""+minHeartRate + " BPM");
                summaryUS.Add("Minimum Heart Rate",""+minHeartRate + " BPM");

                if (smode.Power)
                {
                    //Average power
                    int PowerAverage = GetAveragePower(hrDataExtended.DataEuro);
                    summaryEuro.Add("Average Power", "" + PowerAverage);
                    summaryUS.Add("Average Power", "" + PowerAverage);

                    //Max Power
                    int maxpower = GetMaxPower(hrDataExtended.DataEuro);

                    summaryEuro.Add("Maximum Power", "" + maxpower);
                    summaryUS.Add("Maximum Power", "" + maxpower );
                }


                if (smode.Altitude)
                {
                    //Average Altitude

                    double averageAlt = GetAverageAltitude(hrDataExtended.DataEuro); ;

                    summaryEuro.Add("Average Altitude", "" + Math.Round(averageAlt,2) + " Meters");
                    SummaryUS.Add("Average Altitude", "" + Math.Round((averageAlt * 3.280839895),2 )+ " Feet");






                    //Max Altitude



                    double maxAlt = GetMaxAltitude(hrDataExtended.DataEuro);


                    summaryEuro.Add("Maximum Altitude", "" + (maxAlt) + " Meters");

                    SummaryUS.Add("Maximum Altitude", "" + Math.Round((maxAlt * 3.280839895),2) + " Feet");

                }










            }
            else
            {

                if (smode.Speed)
                {
                    //total distance not sure if for that trip or the odometer
                    double distance = GetTotalDistance(hrDataExtended.DataUS);

                    summaryEuro.Add("Total Distance", "" + Math.Round((distance * 1.60934),2) + "KM");
                    summaryUS.Add("Total Distance", "" + Math.Round(distance,2) + "Miles");

                    //Average Speed

                    double averageSpeed = GetAverageSpeed(hrDataExtended.DataUS); ;

                    summaryEuro.Add("Average Speed", "" + Math.Round((averageSpeed * 1.60934),2) + " KPH");
                    summaryUS.Add("Average Speed", "" + Math.Round(averageSpeed,2) + " MPH");

                    //maximum speed

                    double speed = GetMaxSpeed(hrDataExtended.DataUS);
                    summaryEuro.Add("Maximum Speed", "" + Math.Round((speed * 1.60934),2) + " KMPH");
                    summaryUS.Add("Maximum Speed", "" + speed + " MPH");
                }
                //us starting values



                //Average Heart Rate
                int averageHeartRate = GetAverageHeartRate(hrDataExtended.DataUS);

                summaryEuro.Add("Average Heart Rate", "" + averageHeartRate + " BPM");
                summaryUS.Add("Average Heart Rate", "" + averageHeartRate + " BPM");

                int maxHeartRate = GetMaxHeartRate(hrDataExtended.DataUS);
               
                //Max Heart Rate
                summaryEuro.Add("Maximum Heart Rate", "" + maxHeartRate + " BPM");
                summaryUS.Add("Maximum Heart Rate", "" + maxHeartRate + " BPM");
                //Min Heart Rate
                int minHeartRate = GetMinHeartRate(hrDataExtended.DataUS);

                summaryEuro.Add("Minimum Heart Rate", "" + minHeartRate + " BPM");
                summaryUS.Add("Minimum Heart Rate", "" + minHeartRate + " BPM");

                if (smode.Power)
                {
                    //Average power
                    int PowerAverage = GetAveragePower(hrDataExtended.DataUS);
                    summaryEuro.Add("Average Power", "" + PowerAverage + " Watts");
                    summaryUS.Add("Average Power", "" + PowerAverage + " Watts");
                    //Max Power
                    int maxpower = GetMaxPower(hrDataExtended.DataUS);

                    summaryEuro.Add("Max Power", "" + maxpower + " Watts");
                    summaryUS.Add("Max Power", "" + maxpower + " Watts");
                }

                if (smode.Altitude)
                {
                    //Average Altitude

                    double averageAlt = GetAverageAltitude(hrDataExtended.DataUS);

                    summaryEuro.Add("Average Altitude", "" + Math.Round((averageAlt * 0.3048),2) + " Meters");
                    SummaryUS.Add("Average Altitude", "" + Math.Round(averageAlt,2) + " Feet");



                    //Max Altitude

                    double maxAlt = GetMaxAltitude(hrDataExtended.DataUS);

                    summaryEuro.Add("Max Altitude", "" + Math.Round((maxAlt * 0.3048),2) + "Meters");
                    SummaryUS.Add("Max Altitude", "" + Math.Round(maxAlt,2) + "Feet");
                }
               
               
                
               
            }

            //advanced metrics/normalised power
            if (smode.Power)
            {
                //we then can calc, we have the temp data
                int normPower = GetNormalisedPower(hrDataExtended.DataEuro);
                summaryEuro.Add("NormalisedPower", "" + normPower + " W");
                SummaryUS.Add("NormalisedPower", "" + normPower + " W");

            }





        }
    }
}
