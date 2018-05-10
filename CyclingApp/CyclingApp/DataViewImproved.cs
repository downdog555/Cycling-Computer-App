using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace CyclingApp
{
    /// <summary>
    /// class to represent the single data view of a file, note as impreved as the second version
    /// </summary>
    public partial class DataViewImproved : UserControl
    {


        private bool summaryHidden = false;
        private bool selectedUnit;
        private Polar polar;
        private HrData hrdata;
        private HrData hrDataBeforeSmooth = null;
        private Smode smode;
        private bool percentFTP, percentHR;
        private Dictionary<string, string> summaryDataUS, summaryDataEuro;
        private double ftp;
        private int MaxHR;
        private CyclingMain cyclingMain;
        private double IntensityFactor;
        private int NormalisedPower;
        private double TSS;
        private bool markerSelected;


        private List<Marker> chunkMarkers;

        private List<HrDataSingle>[] selectedDataSet = new List<HrDataSingle>[2];

        private bool graphHr, graphPower, graphCadence, graphSpeed, graphAltitude;
        private GraphPane graph;
        private ZedGraphControl graphControl;
        private double currentXState = 0;
        private List<Marker> MarkerList;
        private List<Marker> intervalList;
        private HrDataSingle[] dataEuroBackup = null;
        private HrDataSingle[] dataUSBackup = null;

        public bool MarkerSelected { get { return markerSelected; } set { markerSelected = value; } }
        public List<Marker> MarkerList1 { get { return MarkerList; } set { MarkerList = value; } }

        /// <summary>
        /// Used to get the SMODE object
        /// </summary>
        /// <returns></returns>
        public Smode GetSmode()
        {
            return smode;
        }



        /// <summary>
        /// constructor for the data view
        /// </summary>
        /// <param name="unitType">boolean to tell if the unit is euro or us  by default</param>
        /// <param name="hrdata">a hrdata object conating all of the data process by polar reader</param>
        /// <param name="smode">a smode object reference of the current file</param>
        /// <param name="polar">a reference to the polar object above this</param>
        /// <param name="cym">a reference to the cyclingmain object that created this object</param>
        /// <param name="rideInfo">A list containg the basic ride info</param>
        public DataViewImproved(bool unitType, HrData hrdata, Smode smode, Polar polar, CyclingMain cym, List<string> rideInfo)
        {
            InitializeComponent();
            chunkMarkers = new List<Marker>();
            markerSelected = false;
            graphHr = true;
            MarkerList = new List<Marker>();
            intervalList = new List<Marker>();
            if (smode.Power)
            {
                graphPower = true;
                powerLabel.Text = "Active";
            }
            else
            {
                graphPower = false;
                powerButton.Hide();
                powerLabel.Text = "Offline";
            }
            if (smode.Speed)
            {
                graphSpeed = true;
                speedLabel.Text = "Active";
            }
            else
            {
                graphSpeed = false;
                speedButton.Hide();
                speedLabel.Text = "Offline";
            }
            if (smode.Cadence)
            {
                graphCadence = true;
                cadenceLabel.Text = "Active";
            }
            else
            {
                graphCadence = false;
                cadenceButton.Hide();
                cadenceLabel.Text = "Offline";
            }
            if (smode.Altitude)
            {
                graphAltitude = true;
                altitudeLabel.Text = "Active";
            }
            else
            {
                graphAltitude = false;
                altitudeButton.Hide();
                altitudeLabel.Text = "Offline";
            }


            this.cyclingMain = cym;
            this.ftp = 1;

            this.MaxHR = 1;
            percentFTP = percentHR = false;
            this.polar = polar;
            summaryDataUS = polar.GetSummaryUS();
            summaryDataEuro = polar.GetSummaryEuro();

            this.hrdata = hrdata;
            selectedDataSet[0] = hrdata.DataEuro;
            selectedDataSet[1] = hrdata.DataUS;
            this.smode = smode;
            selectedUnit = unitType;

            AddRideInfo(rideInfo);




            if (!unitType)
            {
                euroSelection.Checked = true;
                Console.WriteLine("Euro Select");

            }
            else
            {
                usSelection.Checked = true;
            }
            if (!unitType)
            {
                AddSummaryData(summaryDataEuro, unitType);
            }
            else
            {
                AddSummaryData(summaryDataUS, unitType);
            }
            AddFullData();
            AddGraphs();

            //summaryExpand.Dock = DockStyle.Top
            //assign the data currntly so we can allow for the selection of chunking selected data.........

        }


        /// <summary>
        /// Loads the ride info into the required labels
        /// </summary>
        /// <param name="data">a list with the required data</param>
        public void AddRideInfo(List<string> data)
        {
            dateOfRide.Text = data.ElementAt(0);
            timeOfRide.Text = data.ElementAt(1);
            lengthOfRide.Text = data.ElementAt(2);
            recordingInterval.Text = data.ElementAt(3) + " S";
        }

        /// <summary>
        /// Used to set markers for outside current class
        /// </summary>
        /// <param name="newMarkers"></param>
        public void AddMarkers(List<Marker> newMarkers)
        {
            chunkMarkers = newMarkers;

            AddGraphs();
        }

        /// <summary>
        /// methdo called to set hte ftp value
        /// </summary>
        /// <param name="ftp">double containg the FTP</param>
        public void SetFTP(double ftp)
        {
            this.ftpValue.Text = "" + ftp;
            this.ftp = ftp;
            AddFullData();
        }

        /// <summary>
        /// function to set the max Heart rate
        /// </summary>
        /// <param name="maxHr">integer with the max hr</param>
        public void SetMaxHR(int maxHr)
        {
            this.MaxHR = maxHr;
            this.maxHRValue.Text = "" + maxHr;
        }

        /// <summary>
        /// Gets the data from this data view
        /// </summary>
        /// <returns>the hr data</returns>
        public HrData GetFullData()
        {

            return hrdata;
        }

        /// <summary>
        /// Adds the summary data when called
        /// 
        /// </summary>
        /// <param name="data">dictionary containg the summary data</param>
        /// <param name="unitType">the unit that it represents</param>
        public void AddSummaryData(Dictionary<string, string> data, bool unitType)
        {

            GetAdvancedMetrics();
            //summaryPanel.Controls.Clear();
            summaryDataBox.Text = "";
            string distanceUnit, speedUnit, distanceSmallUnit;
            //summaryExpand.Header = "Ride Summary";
            string[] units = GetUnits(unitType);
            distanceUnit = units[0];
            speedUnit = units[1];
            distanceSmallUnit = units[2];
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.AllowUserToAddRows = false;
            List<string> valuesToBeInserted = new List<string>();
            foreach (KeyValuePair<string, string> value in data)
            {


                if (value.Key.Equals("Average Heart Rate"))
                {
                    if (percentHR)
                    {


                        double percent = Math.Round((Convert.ToDouble(value.Value.Split(' ')[0]) / MaxHR) * 100, 2);
                        summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + percent + "%\n";
                        valuesToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        //  grid.Columns.Add(value.Key, value.Key + "(BPM)");
                        summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + value.Value + " BPM\n";
                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else if (value.Key.Equals("Maximum Heart Rate"))
                {
                    if (percentHR)
                    {
                        grid.Columns.Add(value.Key, value.Key + "(% of max hr)");
                        double percent = Math.Round((Convert.ToDouble(value.Value.Split(' ')[0]) / MaxHR) * 100, 2);
                        summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + percent + " %\n";
                        valuesToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        // grid.Columns.Add(value.Key, value.Key + "(BPM)");
                        //MaxHR = Convert.ToInt32(value.Value);
                        maxHRValue.Text = "" + MaxHR;
                        summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + value.Value + "\n";
                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else if (value.Key.Equals("Minimum Heart Rate"))
                {
                    if (percentHR)
                    {
                        grid.Columns.Add(value.Key, value.Key + "(% of max hr)");
                        double percent = Math.Round((Convert.ToDouble(value.Value.Split(' ')[0]) / MaxHR) * 100, 2);
                        summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + percent + " %\n";
                        valuesToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        grid.Columns.Add(value.Key, value.Key + "(BPM)");
                        summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + value.Value + "\n";
                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else if (value.Key.Equals("Average Power"))
                {
                    if (percentFTP)
                    {
                        grid.Columns.Add(value.Key, value.Key + "(% of FTP)");

                        double percent = Math.Round((Convert.ToDouble(value.Value.Split(' ')[0]) / ftp) * 100, 2);
                        summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + percent + "%\n";
                        valuesToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        grid.Columns.Add(value.Key, value.Key + "(W)");
                        summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + value.Value + "W\n";
                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else if (value.Key.Equals("Maximum Power"))
                {
                    if (percentFTP)
                    {
                        grid.Columns.Add(value.Key, value.Key + "(% of FTP)");
                        double percent = Math.Round((Convert.ToDouble(value.Value.Split(' ')[0]) / ftp) * 100, 2);
                        summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + percent + "%\n";
                        valuesToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        grid.Columns.Add(value.Key, value.Key + "(W)");
                        summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + value.Value + "W\n";
                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else if (value.Key.Equals("NormalisedPower"))
                {
                    NormalisedPower = Convert.ToInt32(value.Value.Split(' ')[0]);
                    summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + value.Value + "\n";
                }
                else
                {
                    grid.Columns.Add(value.Key, value.Key);
                    summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + value.Value + "\n";
                    valuesToBeInserted.Add(value.Value);
                }

            }

            grid.Rows.Insert(0, valuesToBeInserted.ToArray());
            // summaryPanel.Controls.Add(grid);
            //  summaryExpand.Content.Controls.Add(grid);



        }



        /// <summary>
        /// used to set data when selection is loaded
        /// </summary>
        /// <param name="data"></param>
        public void SetData(List<HrDataSingle>[] data)
        {
            selectedDataSet[0] = data[0];
            selectedDataSet[1] = data[1];
            //tjem load graphs etc

            AddFullData();
            AddGraphs();

        }

        public void loadSummaryOnGraphChange()
        {

        }

        /// <summary>
        /// function used when summary data is wanted for a specific start and end time
        /// </summary>
        /// <param name="start">start time for data selection</param>
        /// <param name="end">end time for data selection</param>
        public void GetAndLoadSummary(DateTime start, DateTime end)
        {


            Dictionary<string, string>[] summary = polar.GetSummaryDataTimeSpecificed(start, end, polar.GetUnit());
            if (smode.Power)
            {
                NormalisedPower = Convert.ToInt32(summary[0].ElementAt(summary[0].Count - 1).Value.Split(' ')[0]);
            }

            if (!selectedUnit)

            {
                AddSummaryData(summary[0], false);
            }
            else
            {
                AddSummaryData(summary[1], true);
            }

            //we then need to do similar for the advanced metrics
            //calc list etc
            //we need  to do same on inital load we could do it in get summary data time specifed
            GetAdvancedMetrics();
        }
        /// <summary>
        /// used to calculate and pass back the Intensity Factor
        /// </summary>
        /// <param name="np">normalised power</param>
        /// <param name="ftp">Functional Threshold Power</param>
        /// <returns>intesity factor as percentage</returns>
        public double GetIF(double np)
        {
            double IF = 0;

            IF = (np / ftp);

            return IF;
        }
        /// <summary>
        /// used to get the advenced metrics normalised power, IF and TSS
        /// </summary>
        private void GetAdvancedMetrics()
        {
            IntensityFactor = GetIF(NormalisedPower);
            Console.WriteLine("Norm Power: " + NormalisedPower);
            //we can then calculate the TSS
            Console.WriteLine("IF is :" + IntensityFactor);
            //we need the number of seconds in the ride
            string temp = lengthOfRide.Text;
            int lengthH = Convert.ToInt32(lengthOfRide.Text.Split(':')[0]);
            int lengthM = Convert.ToInt32(lengthOfRide.Text.Split(':')[1]);
            int lengthS = (int)Convert.ToDouble(lengthOfRide.Text.Split(':')[2]);
            DateTime startTemp = new DateTime(2018, 10, 10, 0, 0, 0);
            DateTime tempDateToGetSec = new DateTime(2018, 10, 10, lengthH, lengthM, lengthS);
            TimeSpan t = tempDateToGetSec - startTemp;
            Console.WriteLine("Total Seconds: " + t.TotalSeconds);
            TSS = ((t.TotalSeconds * NormalisedPower * IntensityFactor) / (ftp * 3600) * 100);
            Console.WriteLine("TSS = " + TSS);
            tssData.Text = "" + Math.Round(TSS, 0);
            ifData.Text = "" + Math.Round(IntensityFactor, 2);
            normPower.Text = "" + NormalisedPower;
        }

        /// <summary>
        /// Used to get the end date tiem of the file
        /// </summary>
        /// <returns>the end date time</returns>
        public DateTime GetEndDateTime()
        {
            int lengthH = Convert.ToInt32(lengthOfRide.Text.Split(':')[0]);
            int lengthM = Convert.ToInt32(lengthOfRide.Text.Split(':')[1]);
            int lengthS = (int)Convert.ToDouble(lengthOfRide.Text.Split(':')[2]);
            DateTime endTime = new DateTime(2018, 10, 10, lengthH, lengthM, lengthS);
            return endTime;
        }

        /// <summary>
        /// used to get the summary
        /// </summary>
        /// <param name="start">start time of the summary</param>
        /// <param name="end">end time of the summary</param>
        /// <returns></returns>
        public Dictionary<string, string>[] GetSummary(DateTime start, DateTime end)
        {


            List<string> data = new List<string>();




            Dictionary<string, string>[] summary = polar.GetSummaryDataTimeSpecificed(start, end, polar.GetUnit());
            if (smode.Power)
            {
                NormalisedPower = Convert.ToInt32(summary[0].ElementAt(summary[0].Count - 1).Value.Split(' ')[0]);
            }
            
            summary[0].Add("Intensity Factor", "" + GetIF(NormalisedPower));
            summary[1].Add("Intensity Factor", "" + GetIF(NormalisedPower));

           
            TimeSpan t = end - start;
         // tss
            double tss = ((t.TotalSeconds * NormalisedPower * IntensityFactor) / (ftp * 3600) * 100);
            summary[0].Add("TSS", "" + TSS);
            summary[1].Add("TSS", "" +TSS);

            return summary;
        }
        /// <summary>
        /// Gets the hrdata
        /// </summary>
        /// <param name="start">start date of the section</param>
        /// <param name="end">end date of the section</param>
        /// <returns></returns>
        public List<HrDataSingle>[] GetListData(DateTime start, DateTime end)
        {
            List<HrDataSingle>[] data = new List<HrDataSingle>[2];
            List<HrDataSingle> euro = new List<HrDataSingle>();
            List<HrDataSingle> us = new List<HrDataSingle>();


            int interval = Convert.ToInt32(recordingInterval.Text.Split(' ')[0]);
            DateTime zeroPoint = new DateTime(start.Year, start.Month, start.Day,0,0,0);
            TimeSpan startTime = start - zeroPoint;
            TimeSpan endTme = end - zeroPoint;

            int startPoint = (int)startTime.TotalSeconds / interval;
            int endPoint = (int)endTme.TotalSeconds / interval;


            Console.WriteLine("Length of data: " + ((endPoint - startPoint)/interval));
         
            

            bool startFound = false;
            for (int i = 0; i < hrdata.DataEuro.Count; i++)
            {
                if (i == startPoint)
                {
                    startFound = true;
                }

                if (startFound)
                {
                    euro.Add(hrdata.DataEuro.ElementAt(i));
                    us.Add(hrdata.DataUS.ElementAt(i));
                }
                if (i == endPoint-1)
                {
                    break;
                }
            }
            data[0] = euro;
            data[1] = us;
            return data;

        }

        /// <summary>
        /// Called to add the markers for the chunks
        /// </summary>
        public void AddChunkMarkers()
        {
            chunkmFlow.Controls.Clear();
            //Console.WriteLine("Marker list count" + MarkerList.Count);
            if (chunkMarkers.Count > 0)
            {
                Random rand = new Random();
                //we need to draw the markers if we have them 
                for (int i = 0; i < chunkMarkers.Count; i++)
                {
                    Marker marker = chunkMarkers.ElementAt(i);
                    XDate start = new XDate(marker.Min);
                    XDate endTime = new XDate(marker.Max);
                    UserMarkerControl u = new UserMarkerControl(i, this, start.DateTime, endTime.DateTime, GetListData(start.DateTime, endTime.DateTime), selectedUnit, Convert.ToInt32(recordingInterval.Text.Split(' ')[0]), true);
                    chunkmFlow.Controls.Add(u);


                    YAxis startMarker = new YAxis("");
                    startMarker.Color = marker.C;
                    startMarker.Scale.IsVisible = false;
                    startMarker.MajorTic.IsAllTics = false;
                    startMarker.MinorTic.IsAllTics = false;
                    startMarker.MajorTic.PenWidth = 2;
                    startMarker.Cross = marker.Min;

                    YAxis endMarker = new YAxis("");
                    endMarker.Color = marker.C;
                    endMarker.Scale.IsVisible = false;
                    endMarker.MajorTic.IsAllTics = false;
                    endMarker.MinorTic.IsAllTics = false;
                    endMarker.Cross = marker.Max;
                    endMarker.MajorTic.PenWidth = 2;

                    graph.YAxisList.Add(startMarker);
                    graph.YAxisList.Add(endMarker);



                }
            }
        }

        /// <summary>
        /// function called to add the graphs to the current data view
        /// </summary>
        public void AddGraphs()
        {
            //we need to update the graph to show  all values
            graphPanel.Controls.Clear();
            graphControl = new ZedGraphControl();
           // graphControl.Click += HrControl_Click;
            Console.WriteLine("We are adding graphs");
            List<HrDataSingle> graphDataRaw;
            if (!selectedUnit)
            {
                graphDataRaw = selectedDataSet[0];
            }
            else
            {
                graphDataRaw = selectedDataSet[1];
            }
            //we first load hr graph over time
            //we know the interval etc so we need to build the data set
             graph = new GraphPane(new RectangleF(10f, 10f, 1000f, 1000f), "", "Time(S)", "Ride Visualisation");

            PointPairList hr = new PointPairList();
            PointPairList power = new PointPairList();
            PointPairList speed = new PointPairList();
            PointPairList cadence = new PointPairList();
            PointPairList altitude = new PointPairList();


            int x = 0;
            XDate xdate = new XDate(2018, 10, 10, 0, 0, 0);
            foreach (HrDataSingle data in graphDataRaw)
            {
                PointPair powerPoint;

                if (graphPower)
                {
                    if (percentFTP)
                    {
                        powerPoint = new PointPair((double) xdate, ((double)data.Power / ftp) * 100);
                    }
                    else
                    {
                        powerPoint = new PointPair((double)xdate, data.Power);
                    }
                    power.Add(powerPoint);
                   
                }

                PointPair speedPoint;
                if (graphSpeed)
                {
                    speedPoint = new PointPair((double)xdate, data.Speed);
                    speed.Add(speedPoint);
                }

                PointPair cadencePoint;
                if (graphCadence)
                {
                    cadencePoint = new PointPair((double)xdate, data.Cadence);
                    cadence.Add(cadencePoint);

                }

                PointPair altitudePoint;
                if (graphAltitude)
                {
                    altitudePoint = new PointPair((double)xdate, data.Altitude);
                    altitude.Add(altitudePoint);
                }

                PointPair pointHR;
                //if we dont have percentage
                if (percentHR)
                {
                    //Console.WriteLine("We go into graphs");
                    //Console.WriteLine("HR = "+data.HeartRate+" meow max hr is + "+MaxHR);
                    //Console.WriteLine((double)data.HeartRate/MaxHR);
                    double y = (((double)data.HeartRate / MaxHR) * 100);
                    //Console.WriteLine(y);
                    pointHR = new PointPair((double)xdate, y);
                }
                else
                {
                    // Console.WriteLine("We dont have percent");
                    pointHR = new PointPair((double)xdate, data.HeartRate);
                }

                xdate.AddSeconds(Convert.ToInt32(recordingInterval.Text.Split(' ')[0]));
                    hr.Add(pointHR);
            }

            graph.YAxisList.Clear();
            graph.Y2AxisList.Clear();
            if (graphHr)
            {
                GraphPane temp = new GraphPane();
                LineItem hrCurve = graph.AddCurve("Heart Rate", hr, Color.Red, SymbolType.None);
                hrCurve.YAxisIndex = 0;
                

                YAxis yAxis3 = new YAxis("Heart Rate");
                graph.YAxisList.Add(yAxis3);
                yAxis3.Scale.FontSpec.FontColor = Color.Red;
                yAxis3.Title.FontSpec.FontColor = Color.Red;
                yAxis3.Color = Color.Red;
                yAxis3.MajorTic.Color = Color.Red;
                yAxis3.MinorTic.Color = Color.Red;
                // turn off the opposite tics so the Y2 tics don't show up on the Y axis
                yAxis3.MajorTic.IsInside = false;
                yAxis3.MinorTic.IsInside = false;
                yAxis3.MajorTic.IsOpposite = false;
                yAxis3.MinorTic.IsOpposite = false;
                // Align the Y2 axis labels so they are flush to the axis
                yAxis3.Scale.Align = AlignP.Inside;
                
               
            }

            if (graphPower)
            {
                LineItem powerCurve = graph.AddCurve("Power", power, Color.Blue, SymbolType.None);
                powerCurve.IsY2Axis = true;
                powerCurve.YAxisIndex = 0;

                Y2Axis yAxis4 = new Y2Axis("Power");
                yAxis4.IsVisible = true;
                graph.Y2AxisList.Add(yAxis4);
                yAxis4.Scale.FontSpec.FontColor = Color.Blue;
                yAxis4.Title.FontSpec.FontColor = Color.Blue;
                yAxis4.Color = Color.Blue;
                yAxis4.MajorTic.Color = Color.Blue;
                yAxis4.MinorTic.Color = Color.Blue;
                // turn off the opposite tics so the Y2 tics don't show up on the Y axis
                yAxis4.MajorTic.IsInside = false;
                yAxis4.MinorTic.IsInside = false;
                yAxis4.MajorTic.IsOpposite = false;
                yAxis4.MinorTic.IsOpposite = false;
                // Align the Y2 axis labels so they are flush to the axis
                yAxis4.Scale.Align = AlignP.Inside;
            }

            if (graphSpeed)
            {
               LineItem speedCurve = graph.AddCurve("Speed", speed, Color.Green, SymbolType.None);
                YAxis yAxis3 = new YAxis("Speed");
                graph.YAxisList.Add(yAxis3);
                yAxis3.Scale.FontSpec.FontColor = Color.Green;
                yAxis3.Title.FontSpec.FontColor = Color.Green;
                yAxis3.Color = Color.Green;
                yAxis3.MajorTic.Color = Color.Green;
                yAxis3.MinorTic.Color = Color.Green;
                // turn off the opposite tics so the Y2 tics don't show up on the Y axis
                yAxis3.MajorTic.IsInside = false;
                yAxis3.MinorTic.IsInside = false;
                yAxis3.MajorTic.IsOpposite = false;
                yAxis3.MinorTic.IsOpposite = false;
                // Align the Y2 axis labels so they are flush to the axis
                yAxis3.Scale.Align = AlignP.Inside;
                if (graphHr)
                {
                    speedCurve.YAxisIndex = 1;
                   
                }
                else
                {
                    speedCurve.YAxisIndex = 0;
                }
              
          
            }

            if (graphAltitude)
            {
                LineItem altitudeCurve = graph.AddCurve("Altitude", altitude, Color.Brown, SymbolType.None);
                altitudeCurve.IsY2Axis = true;

     
                
                
                if (graphPower)
                {
                    altitudeCurve.YAxisIndex = 1;
                }
                else
                {
                    altitudeCurve.YAxisIndex = 0;
                }
                Y2Axis yAxis4 = new Y2Axis("Altitude");
                yAxis4.IsVisible = true;
                graph.Y2AxisList.Add(yAxis4);
                yAxis4.Scale.FontSpec.FontColor = Color.Brown;
                yAxis4.Title.FontSpec.FontColor = Color.Brown;
                yAxis4.Color = Color.Brown;
                yAxis4.MajorTic.Color = Color.Brown;
                yAxis4.MinorTic.Color = Color.Brown;
                // turn off the opposite tics so the Y2 tics don't show up on the Y axis
                yAxis4.MajorTic.IsInside = false;
                yAxis4.MinorTic.IsInside = false;
                yAxis4.MajorTic.IsOpposite = false;
                yAxis4.MinorTic.IsOpposite = false;
                // Align the Y2 axis labels so they are flush to the axis
                yAxis4.Scale.Align = AlignP.Inside;


            }

            if (graphCadence)
            {
                LineItem graphCadence = graph.AddCurve("Cadence", cadence, Color.Black, SymbolType.None);
                YAxis yAxis3 = new YAxis("Cadence");
                graph.YAxisList.Add(yAxis3);
                yAxis3.Scale.FontSpec.FontColor = Color.Black;
                yAxis3.Title.FontSpec.FontColor = Color.Black;
                yAxis3.Color = Color.Black;
                // turn off the opposite tics so the Y2 tics don't show up on the Y axis
                yAxis3.MajorTic.IsInside = false;
                yAxis3.MinorTic.IsInside = false;
                yAxis3.MajorTic.IsOpposite = false;
                yAxis3.MinorTic.IsOpposite = false;
                // Align the Y2 axis labels so they are flush to the axis
                yAxis3.Scale.Align = AlignP.Inside;
                if (graphHr && graphSpeed)
                {
                    graphCadence.YAxisIndex = 2;

                }
                else if (graphSpeed || graphHr)
                {
                    graphCadence.YAxisIndex = 1;
                   
                }
                else
                {
                    graphCadence.YAxisIndex = 0;
                }
                
               
            }


           
           

            graph.XAxis.Type = AxisType.Date;
           graph.XAxis.Title.Text = "Time(HH:MM:SS)";
           // graph.XAxis.Scale.Format = "hh:mm:ss";
            //graph.XAxis.Scale.Min = new XDate(0,0,0,0,0,0);
            //DateTime test = Convert.ToDateTime(lengthOfRide.Text);
    
            graph.XAxis.Scale.Format = "HH:mm:ss";
            graph.XAxis.Scale.MajorUnit = DateUnit.Hour;
            graph.XAxis.Scale.MinorUnit = DateUnit.Second;
            graph.XAxis.Scale.Min = (double) new XDate(2018, 10, 10, 0, 0, 0);
            XDate end = new XDate(2018, 10, 10, 0, 0, 0);
            end.AddSeconds((selectedDataSet[0].Count * Convert.ToInt32(recordingInterval.Text.Split(' ')[0])));
            graph.XAxis.Scale.Max = end;
            
            if (graph.YAxisList.Count == 0)
            {
                YAxis temp = new YAxis("hidden");
                temp.IsVisible = false;
                graph.YAxisList.Add(temp);
            }

            if (graph.Y2AxisList.Count == 0)
            {
                Y2Axis temp = new Y2Axis("hidden");
                temp.IsVisible = false;
                graph.Y2AxisList.Add(temp);
            }

            graph.AxisChange();

            graphControl.GraphPane = graph;
            graphControl.Size = graphPanel.Size;
            graphControl.Show();
            //graphControl.RestoreScale(graph);
            //disable zoom
            graphControl.IsEnableZoom = true;
            graphControl.IsEnableVZoom = false;
            graphControl.IsShowPointValues = true;
            //dissable pan so control isnt used for that
            graphControl.IsEnableHPan = false;
            graphControl.IsEnableVPan = false;
            //set control as a modifier so we can still zoom with it pressed
            //set the second zoom button to left click as well
            graphControl.ZoomButtons2 = MouseButtons.Left;
            //modifer key means it doenst work unless control is pressed.
            graphControl.ZoomModifierKeys2 = Keys.Control;
           

            graphPanel.Controls.Add(graphControl);
            graphControl.ZoomEvent += new ZedGraphControl.ZoomEventHandler(graphZoom);
            
           // graphControl.ZoomModifierKeys = Keys.Control;
            graph.AxisChangeEvent += new GraphPane.AxisChangeEventHandler(GetSummaryBetweenValue);
            currentXState = graph.XAxis.Scale.Min;

            foreach (Marker m in intervalList)
            {
                //Console.WriteLine("Marker start: "+m.Min+" Marker End: "+m.Max+" Marker Colour: "+m.C.ToString());
                YAxis startMarker1 = new YAxis("");
                startMarker1.Color = m.C;
                startMarker1.Scale.IsVisible = false;
                startMarker1.MajorTic.IsAllTics = false;
                startMarker1.MinorTic.IsAllTics = false;
                startMarker1.Cross = m.Min;
                startMarker1.MajorTic.PenWidth = 2;

                YAxis endMarker1 = new YAxis("");
                endMarker1.Color = m.C;
                endMarker1.Scale.IsVisible = false;
                endMarker1.MajorTic.IsAllTics = false;
                endMarker1.MinorTic.IsAllTics = false;
                endMarker1.Cross = m.Max;
                endMarker1.MajorTic.PenWidth = 2;

                graph.YAxisList.Add(startMarker1);
                graph.YAxisList.Add(endMarker1);
            }

            userIntervalsFlow.Controls.Clear();
            //Console.WriteLine("Marker list count" + MarkerList.Count);
            if (MarkerList.Count > 0)
            {
                Random rand = new Random();
                //we need to draw the markers if we have them 
                for(int i = 0; i < MarkerList.Count;i++)
                {
                    Marker marker = MarkerList.ElementAt(i);
                    XDate start = new XDate(marker.Min);
                    XDate endTime = new XDate(marker.Max);
                    UserMarkerControl u = new UserMarkerControl(i, this, start.DateTime, endTime.DateTime, GetListData(start.DateTime, endTime.DateTime), selectedUnit, Convert.ToInt32(recordingInterval.Text.Split(' ')[0]),false);
                    userIntervalsFlow.Controls.Add(u);

                    if (marker.DrawMarker && !marker.Selected && !MarkerSelected)
                    {
                        YAxis startMarker = new YAxis("");
                        startMarker.Color = marker.C;
                        startMarker.Scale.IsVisible = false;
                        startMarker.MajorTic.IsAllTics = false;
                        startMarker.MinorTic.IsAllTics = false;
                        startMarker.MajorTic.PenWidth = 2;
                        startMarker.CrossAuto = false;
                        startMarker.Cross = marker.Min;

                        YAxis endMarker = new YAxis("");
                        endMarker.Color = marker.C;
                        endMarker.Scale.IsVisible = false;
                        endMarker.MajorTic.IsAllTics = false;
                        endMarker.MinorTic.IsAllTics = false;
                        endMarker.CrossAuto = false;
                        endMarker.Cross = marker.Max;
                        endMarker.MajorTic.PenWidth = 2;

                        graph.YAxisList.Add(startMarker);
                        graph.YAxisList.Add(endMarker);
                    }
                  
                    
                }
            }



            Console.WriteLine("Chunk markers: " + chunkMarkers.Count);
            chunkmFlow.Controls.Clear();
            //Console.WriteLine("Marker list count" + MarkerList.Count);
            if (chunkMarkers.Count > 0)
            {
               
                //we need to draw the markers if we have them 
                for (int i = 0; i < chunkMarkers.Count; i++)
                {
                    Marker marker = chunkMarkers.ElementAt(i);
                    XDate start = new XDate(marker.Min);
                    start.AddMilliseconds(1);
                    XDate endTime = new XDate(marker.Max);
                    UserMarkerControl u = new UserMarkerControl(i, this, start.DateTime, endTime.DateTime, GetListData(start.DateTime, endTime.DateTime), selectedUnit, Convert.ToInt32(recordingInterval.Text.Split(' ')[0]), true);
                    chunkmFlow.Controls.Add(u);


                    YAxis startMarker = new YAxis("");
                    startMarker.Color = marker.C;
                    startMarker.Scale.IsVisible = false;
                    startMarker.MajorTic.IsAllTics = false;
                    startMarker.MinorTic.IsAllTics = false;
                    startMarker.MajorTic.PenWidth = 2;
                    startMarker.Cross = start;
                    Console.WriteLine("marker Min: "+marker.Min);

                    YAxis endMarker = new YAxis("");
                    endMarker.Color = marker.C;
                    endMarker.Scale.IsVisible = false;
                    endMarker.MajorTic.IsAllTics = false;
                    endMarker.MinorTic.IsAllTics = false;

                    if (i == (chunkMarkers.Count - 1))
                    {
                        XDate ends = graph.XAxis.Scale.Max;
                        ends.AddMilliseconds(-1);
                        
                        endMarker.Cross = ends;
                    }
                    else
                    {
                        endMarker.Cross = marker.Max;
                    }
                   
                    endMarker.MajorTic.PenWidth = 2;

                    graph.YAxisList.Add(startMarker);
                    graph.YAxisList.Add(endMarker);



                }
            }
             Console.WriteLine("min x on graph "+ graphControl.GraphPane.XAxis.Scale.Min);

            
        }

        
       
       /// <summary>
       /// Function called when the graph is zoomed
       /// is also used to apply markers, seeing if control is pressed
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="oldState"></param>
       /// <param name="newState"></param>
        private void graphZoom(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            //we need to check to see if modifer key has been pressed if so that means we want to select so zoom and then undo the zoom
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                
                Console.WriteLine("Control is pressed so zoom and get values then unzoom");
                double min = sender.GraphPane.XAxis.Scale.Min;
                double max = sender.GraphPane.XAxis.Scale.Max;
                //ender.ZoomOut(sender.GraphPane);
               // newState.ApplyState(sender.GraphPane);
                //Console.WriteLine("We have zoomed out");
                //we then add the values to the list
               
                bool exists = false;
                foreach (Marker line in MarkerList)
                {
                    if (line.Min == min && line.Max == max)
                    {
                        exists = true;
                    }
                }
                // if this exact marker does not exist then add to list 
                if (!exists)
                {
                    Marker temp = new Marker(min, max);
                    MarkerList.Add(temp);
                }

                
                AddGraphs();
            }
            else
            {
                //we now know that we have zoomed
                if (currentXState > sender.GraphPane.XAxis.Scale.Min)
                {
                    Console.WriteLine("Zoom out");
                    currentXState = sender.GraphPane.XAxis.Scale.Min;

                }
                else
                {
                    Console.WriteLine("Zoom in");
                    currentXState = sender.GraphPane.XAxis.Scale.Min;

                }
                XDate start = new XDate(sender.GraphPane.XAxis.Scale.Min);
                XDate end = new XDate(sender.GraphPane.XAxis.Scale.Max);
                DateTime s = start.DateTime;
                DateTime e = end.DateTime;

                Dictionary<string, string>[] dataTemp = polar.GetSummaryDataTimeSpecificed(s, e, selectedUnit);
                int i = 0;
                if (!selectedUnit)
                {
                    i = 0;
                }
                else
                {
                    i = 1;
                }
              
                AddSummaryData(dataTemp[i], false);
            }



           

        }

        /// <summary>
        /// called when the graph is zoomed in or our and summary data is recalcualted
        /// </summary>
        /// <param name="start">start time</param>
        /// <param name="end">end time</param>

        private void  GetSummaryBetweenValue(GraphPane pane)
        {
           // Console.WriteLine("Graph zoomed");
            //we will need to reload summary
         //   double start,end,startGraph, endGraph;
           // startGraph = graph.XAxis.Scale.Min;
           // endGraph = graph.XAxis.Scale.Max;
          //  start = pane.XAxis.Scale.Min;
          //  end = pane.XAxis.Scale.Max;
           
          //  Console.WriteLine("Graph Scale:");
         //   Console.WriteLine("Start: "+startGraph);
          //  Console.WriteLine("End: "+endGraph);
         //   Console.WriteLine("Selection Scale");
          //  Console.WriteLine("Start: "+start);
          //  Console.WriteLine("End: "+end);
        }


        /// <summary>
        /// Gets the date time for the ride
        /// </summary>
        /// <returns>dat time fo start of ride</returns>
        public DateTime GetRideTime()
        {
            return new DateTime(Convert.ToInt32(dateOfRide.Text.Split('/')[2]), Convert.ToInt32(dateOfRide.Text.Split('/')[1]), Convert.ToInt32(dateOfRide.Text.Split('/')[0]), Convert.ToInt32(timeOfRide.Text.Split(':')[0]), Convert.ToInt32(timeOfRide.Text.Split(':')[1]), Convert.ToInt32(timeOfRide.Text.Split(':')[2].Split('.')[0]));
        }

        /// <summary>
        /// Gets the recording interval
        /// </summary>
        /// <returns>the recording interval</returns>
        public int GetInterval()
        {
            return Convert.ToInt32(recordingInterval.Text.Split(' ')[0]);
        }
        /// <summary>
        /// Adds the full set of data to the control
        /// </summary>
        public void AddFullData()
        {
            fullDataFlow.Controls.Clear();
            DataGridView fullData = new DataGridView();
            fullData.Dock = DockStyle.Fill;
            fullData.Columns.Add("time","Time");
            if (percentHR)
            {
                fullData.Columns.Add("hr", "Heart Rate % of Max");
            }
            else
            {
                fullData.Columns.Add("hr", "Heart Rate(BPM)");
            }
            //we need to add headers
            if (smode.Speed)
            {
                if (selectedUnit)
                {
                    fullData.Columns.Add("speed", "Speed(MPH)");
                }
                else
                {
                    fullData.Columns.Add("speed", "Speed(KPH)");
                }

            }
            if (smode.Cadence)
            {
                fullData.Columns.Add("cadence", "Cadence(RPM)");
            }
            if (smode.Altitude)
            {
                if (selectedUnit)
                {
                    fullData.Columns.Add("altitude", "Altitude(Feet)");
                }
                else
                {
                    fullData.Columns.Add("altitude", "Altitude(Meters)");
                }
            }
            if (smode.Power)
            {
                if (percentFTP)
                {
                    fullData.Columns.Add("power", "Power(% of FTP)");
                }
                else
                {
                    fullData.Columns.Add("power", "Power(W)");
                }


            }
            if (smode.PowerLeftRightBalance)
            {
                fullData.Columns.Add("powerBalance", "Power Balance");
            }
            if (smode.PowerPedallingIndex)
            {
                fullData.Columns.Add("powerPedelingIndex", "Power Pedeling Index");
            }
            if (smode.HRCC1)
            {
                //we will need this if hr data only
            }

            if (smode.AirPressure)
            {
                fullData.Columns.Add("airPressure", "Air Pressure");
            }

            //we then need to loop through all data
            List<HrDataSingle> dataSmall;
            if (selectedUnit)
            {
                dataSmall = selectedDataSet[1];
            }
            else
            {
                dataSmall = selectedDataSet[0];
            }
            DateTime dateTimeRide = new DateTime(Convert.ToInt32(dateOfRide.Text.Split('/')[2]),Convert.ToInt32(dateOfRide.Text.Split('/')[1]),Convert.ToInt32(dateOfRide.Text.Split('/')[0]), Convert.ToInt32(timeOfRide.Text.Split(':')[0]),Convert.ToInt32(timeOfRide.Text.Split(':')[1]), Convert.ToInt32(timeOfRide.Text.Split(':')[2].Split('.')[0]));
       
            int recordingIntervalInt = Convert.ToInt32(recordingInterval.Text.Split(' ')[0]); 
            foreach (HrDataSingle dataLine in dataSmall)
            {
                List<string> dataToBeInserted = new List<string>();
                //first add the time column
                //we need to add the interval
                dateTimeRide = dateTimeRide.AddSeconds(recordingIntervalInt);
  
                dataToBeInserted.Add(dateTimeRide.ToLongTimeString());
                if (percentHR)
                {
                    double percent = Math.Round((Convert.ToDouble(dataLine.HeartRate) / MaxHR) * 100,2);
                    dataToBeInserted.Add("" + percent);
                }
                else
                {
                    dataToBeInserted.Add("" + dataLine.HeartRate);
                }
                if (smode.Speed)
                {
                    dataToBeInserted.Add("" + Math.Round(dataLine.Speed,2));
                }
                if (smode.Cadence)
                {
                    dataToBeInserted.Add("" + dataLine.Cadence);
                }
                if (smode.Altitude)
                {
                    dataToBeInserted.Add("" +  dataLine.Altitude);
                }
                if (smode.Power)
                {
                    if (percentFTP)
                    {

                        double percent = (Convert.ToDouble(dataLine.Power) / ftp) * 100;
                        //Console.WriteLine(percent);
                        percent = Math.Round(percent, 2);
                        dataToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        dataToBeInserted.Add("" + dataLine.Power);
                    }
                }
                if (smode.PowerLeftRightBalance)
                {
                    dataToBeInserted.Add("" + dataLine.PB);
                }
                if (smode.PowerPedallingIndex)
                {
                    dataToBeInserted.Add("" + dataLine.PI);
                }


                if (smode.AirPressure)
                {
                    dataToBeInserted.Add("" + dataLine.AirPressure);
                }
                fullData.Rows.Add(dataToBeInserted.ToArray());
            }
            fullDataFlow.Controls.Add(fullData);

        }

        /// <summary>
        /// Function to get the units text for a specifc bool
        /// </summary>
        /// <param name="unitType">false means euro units true means us units</param>
        /// <returns></returns>
        private string[] GetUnits(bool unitType)
        {
            if (!unitType)
            {
                return new string[] { "KM", "KM/H", "M" };
            }
            else
            {
                return new string[] { "M", "MPH", "F" };
            }
        }


        /// <summary>
        /// Function called when the US unit selection is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usSelection_Click(object sender, EventArgs e)
        {
            Console.WriteLine("US Click");
            selectedUnit = true;
            AddFullData();
            AddSummaryData(summaryDataUS, selectedUnit);
            AddGraphs();
        }

        private void summaryButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// called when summary button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void summaryButton_Click_1(object sender, EventArgs e)
        {
            if (summaryHidden)
            {
                summaryPanel.Visible = true;


            }
            else
            {
                summaryPanel.Visible = false;
            }
        }

        /// <summary>
        /// Called when the altitude button is pressed
        /// turns the altitude line on and off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void altitudeButton_Click(object sender, EventArgs e)
        {
            if (graphAltitude)
            {
                graphAltitude = false;
                AddGraphs();
            }
            else
            {
                graphAltitude = true;
                AddGraphs();
            }
        }

        /// <summary>
        /// Called whne the cadence button is pressed
        /// turns the cadence line on and off if it exists
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cadenceButton_Click(object sender, EventArgs e)
        {
            if (graphCadence)
            {
                graphCadence = false;
                AddGraphs();
            }
            else
            {
                graphCadence = true;
                AddGraphs();
            }
        }

        /// <summary>
        /// Turns the power button on and off
        /// called when the power button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void powerButton_Click(object sender, EventArgs e)
        {
            if (graphPower)
            {
                graphPower = false;
                AddGraphs();
            }
            else
            {
                graphPower = true;
                AddGraphs();
            }
        }

        /// <summary>
        /// Called when the speed button is pressed
        /// turns the speed line on and offf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speedButton_Click(object sender, EventArgs e)
        {
            if (graphSpeed)
            {
                graphSpeed = false;
                AddGraphs();
            }
            else
            {
                graphSpeed = true;
                AddGraphs();
            }
        }

        /// <summary>
        /// called when the HR button is called
        /// turns the HR line onm and off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hrButton_Click(object sender, EventArgs e)
        {
            if (graphHr)
            {
                graphHr = false;
                AddGraphs();
            }
            else
            {
                graphHr = true;
                AddGraphs();
            }
        }

        private void summaryDataBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Called when interval detection button is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intervalDetection_Click(object sender, EventArgs e)
        {
            intervalList.Clear();
            if (!smode.Power)
            {
                MessageBox.Show("Error: Cannot detect intervals without power", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            int DetectionValue = 110;
            //we need to create the lines
            HrDataSingle past2=new HrDataSingle() ;
            bool first = true;
            bool start = false;
            bool markerDone = false;
            int averageHR = 0;
            int averagePower = 0;
            foreach (KeyValuePair<string, string> keyData in summaryDataEuro)
            {
                if (keyData.Key.Equals("Average Heart Rate"))
                {
                    averageHR = Convert.ToInt32(keyData.Value);
                }
                else if (keyData.Key.Equals("Average Power"))
                {
                    averagePower = Convert.ToInt32(keyData.Value);
                }
            }
            Marker intervalMarker = new Marker();
            XDate date = new XDate(2018, 10, 10, 0, 0, 0);
            for (int x=0;x<selectedDataSet[0].Count;x++)
            {
                HrDataSingle data = selectedDataSet[0].ElementAt(x);
                if (markerDone)
                {
                    intervalMarker = new Marker();
                    markerDone = false;
                }
                if (first)
                {
                    past2 = data;
                    first = false;
                }
                else
                {
                    int diff = 0;
                    diff = past2.Power - data.Power;
                   
                    if (diff >= 0)
                    {
                        if ( start )
                        {
                            int hrDiff = past2.HeartRate - data.HeartRate;
                            if ( data.Power <= (past2.Power - (past2.Power / 6)) )
                            {
                                Console.WriteLine("Difference = " + diff);
                                //means we have marker
                                Console.WriteLine("end found");
                                //create list of interval markers

                                Console.WriteLine("Date double: " + date);
                                // m.Min = (double)date;

                                intervalMarker.Max = (double)date;
                                //intervalList.Add(m);
                                start = false;
                                markerDone = true;
                            }
                           


                        }
                    }
                    else
                    {
                        if ( !start )
                        {
                            int hrDiff = past2.HeartRate - data.HeartRate;
                            Console.WriteLine("Average HR: "+averageHR);
                            if (  (data.HeartRate > past2.HeartRate && data.HeartRate >= averageHR-(((float)averageHR/100 *19))) && (data.Power >= (past2.Power + (past2.Power / 4)) && data.Power > (averagePower-(averagePower/2))) )
                            {
                                Console.WriteLine("Difference = " + diff);
                                //means we have marker
                                Console.WriteLine("start found");
                                //create list of interval markers
                                // Marker m = new Marker();
                                Console.WriteLine("Date double: " + date);
                                XDate temp = new XDate(date);
                                temp.AddSeconds(-1);
                                intervalMarker.Min = (double)temp;

                                //intervalList.Add(m);

                                start = true;

                            }



                        }
                    }
               
                   
                    
                }
                date.AddSeconds(Convert.ToInt32(recordingInterval.Text.Split(' ')[0]));
                if (markerDone)
                {
                    intervalMarker.GenColour();
                    intervalList.Add(intervalMarker);
                }
                past2 = data;
            }
            Console.WriteLine("Inteval Marker Count: "+intervalList.Count);


          
            
            AddGraphs();
            
        }

        /// <summary>
        /// function called to remove a user added marker
        /// </summary>
        /// <param name="index"></param>
        public void RemoveUserSelection(int index)
        {
            MarkerList.RemoveAt(index);
            AddGraphs();
        }

        /// <summary>
        /// used to remove a chunk selection
        /// </summary>
        /// <param name="index"></param>
        public void RemoveChunkSelection(int index)
        {
            chunkMarkers.RemoveAt(index);
            AddChunkMarkers();
            AddGraphs();
            
        }

        /// <summary>
        /// called when button is clicked, remvoes the markers added by the interval detection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            intervalList.Clear();
            AddGraphs();
        }

        /// <summary>
        /// function called when apply smoothing button is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smoothing_Click(object sender, EventArgs e)
        {
            //first take copy of current data etc
            if (dataEuroBackup == null && dataUSBackup == null)
            {
                dataEuroBackup = selectedDataSet[0].ToArray();
                dataUSBackup = selectedDataSet[1].ToArray();
            }
            int windowSize = 0;
            //we can then apply the smooth
            try
            {
                 windowSize = Convert.ToInt32(windowSizeEntry.Text);
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error","Value entered for smoothing is not valid, please enter an integer value",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ApplySmooth(windowSize);

        }

        /// <summary>
        /// called after the event function to actually apply the smoothing
        /// </summary>
        /// <param name="windowSize">size of the smoothing window</param>
        private void ApplySmooth(int windowSize)
        {
            Console.WriteLine("We are here");
           /// HrData newData = hrdata;
           /// //we convert to array so we can acutally edit the proper values, cannot do that as foreach and list, or even index at as it is a copy
            HrDataSingle[] dataEuro = selectedDataSet[0].ToArray();
            HrDataSingle[] dataUS = selectedDataSet[1].ToArray();
           // newData.DataEuro.Clear();
           // newData.DataUS.Clear();
            for (int i = 0; i< selectedDataSet[0].Count;i++)
            {
                //we need another loop for window size counter etc
                int x = 0;
                //declare the values first
                double powerUS, powerEuro;
                double heartRate;
                powerUS = powerEuro = heartRate = 0;
                while (x < windowSize)
                {

                    try
                    {
                        powerEuro =powerEuro + selectedDataSet[0].ElementAt(i+x).Power;
                        powerUS = powerUS + selectedDataSet[1].ElementAt(i + x).Power;
                        heartRate = heartRate + selectedDataSet[0].ElementAt(i+x).HeartRate;

                        x += 1;
                    }
                    catch (Exception e)
                    {
                        //means we have gone our of range
                        //we can just exit out of loop 
                        break;
                    }


                   
                }
                powerEuro = powerEuro / x;
                powerUS = powerUS / x;
                heartRate = heartRate / x;
                //Console.WriteLine("Indext: "+i+" Power: "+powerEuro+" HeartRate: "+heartRate);
                //HrDataSingle tempeuro =  selectedDataSet[0].ElementAt(i);
               // HrDataSingle tempus = selectedDataSet[1].ElementAt(i);
                
                dataEuro[i].Power = (int)powerEuro;
               dataUS[i].Power = (int)powerUS;
                dataEuro[i].HeartRate = (int)heartRate;
                dataUS[i].HeartRate = (int)heartRate;

                //newData.DataEuro.Add(tempeuro);
                //newData.DataUS.Add(tempus);
            }
            //convert back to list from array
            selectedDataSet[0] = dataEuro.ToList();
            selectedDataSet[1] = dataUS.ToList();
           
            
            AddGraphs();
            AddFullData();
        }

        /// <summary>
        /// function called when the remove smoothing button is pressed reverst back to data used initally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeSmooth_Click(object sender, EventArgs e)
        {
            if (dataEuroBackup != null && dataUSBackup != null)
            {
                selectedDataSet[0] = dataEuroBackup.ToList();
                selectedDataSet[1] = dataUSBackup.ToList();
                dataEuroBackup = null;
                dataUSBackup = null;
                AddGraphs();
                AddFullData();

              
            }
      
        }

        /// <summary>
        /// used to revert the selected data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void revertData_Click(object sender, EventArgs e)
        {
            selectedDataSet[0] = hrdata.DataEuro;
            selectedDataSet[1] = hrdata.DataUS;
            markerSelected = false;
            Marker[] intArrayTemp = MarkerList.ToArray();
            for (int i = 0; i < MarkerList.Count;i++)
            {
                
                if (intArrayTemp[i].Selected)
                {
                    intArrayTemp[i].Selected = false;
                }
            }
            Console.WriteLine("marker list"+ MarkerList.Count);
            MarkerList = intArrayTemp.ToList();

            AddGraphs();
            AddFullData();

           
        }

        /// <summary>
        /// called when the ftp box is checked
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ftpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("We have changed");
            if (percentFTP)
            {
                percentFTP = false;
            }
            else
            {
                percentFTP = true;
            }
            AddFullData();
            if (selectedUnit)
            {
                AddSummaryData(summaryDataUS, selectedUnit);
            }
            else
            {
                AddSummaryData(summaryDataEuro, selectedUnit);
            }
            AddGraphs();

        }

        /// <summary>
        /// called when load file is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cyclingMain.loadFileToolStripMenuItem_Click(sender, e);
        }

        private void basePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// called when the load gile is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cyclingMain.loadFileToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        /// called when the HR check box is called
        /// converst the hr between a percent and normal values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hrCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           // Console.WriteLine("We have change 2");
            if (percentHR)
            {
                percentHR = false;
            }
            else
            {
                percentHR = true;
            }
            AddFullData();
            if (selectedUnit)
            {
                AddSummaryData(summaryDataUS, selectedUnit);
            }
            else
            {
                AddSummaryData(summaryDataEuro, selectedUnit);
            }
            AddGraphs();

        }

        /// <summary>
        /// called when the all button is clciked
        /// resets the graph to show all lines
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allButton_Click(object sender, EventArgs e)
        {
            if (smode.Power && !graphPower)
            {
                graphPower = true;
            }
            else
            {
                if (!graphPower)
                {
                    graphPower = false;
                }
                
            }

            if (smode.Speed && !graphSpeed)
            {
                graphSpeed = true;
            }
            else
            {
                if (!graphSpeed)
                {
                    graphSpeed = false;
                }
                
            }

            if (smode.Cadence && !graphCadence)
            {
                graphCadence = true;
            }
            else
            {
                if (!graphCadence)
                {
                    graphCadence = false;
                }
               
            }

            if (smode.Altitude && !graphAltitude)
            {
                graphAltitude = true;
            }
            else
            {
                if (!graphAltitude)
                {
                    graphAltitude = false;
                }
                
            }

            if ( !graphHr)
            {
                graphHr = true;
            }
            else
            {
                if (!graphHr)
                {
                    graphHr = false;
                }
             
            }
            AddGraphs();

        }

        /// <summary>
        /// called when the euro radio is cclicked
        /// cahnges values into metric
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void euroSelection_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Euro Selected");
            selectedUnit = false;
            AddFullData();
            AddSummaryData(summaryDataEuro, selectedUnit);
            //load
            AddGraphs();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }



        

    


    }
}
