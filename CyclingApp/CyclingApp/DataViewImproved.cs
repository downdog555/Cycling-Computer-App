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
    public partial class DataViewImproved : UserControl
    {
        

        private bool summaryHidden = false;
        private bool selectedUnit;
        private Polar polar;
        private HrData hrdata;
        private Smode smode;
        private bool percentFTP, percentHR;
        private Dictionary<string, string> summaryDataUS, summaryDataEuro;
        private double ftp;
        private int MaxHR;
        private CyclingMain cyclingMain;
        private GraphDetail hrDetail;
        private bool graphHr, graphPower, graphCadence, graphSpeed, graphAltitude;

        public DataViewImproved(bool unitType, HrData hrdata, Smode smode, Polar polar, CyclingMain cym, List<string> rideInfo)
        {
            InitializeComponent();
            graphHr = true;

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
            hrDetail = new GraphDetail();

            this.cyclingMain = cym;
            this.ftp = 1;

            this.MaxHR = 1;
            percentFTP = percentHR = false;
            this.polar = polar;
            summaryDataUS = polar.GetSummaryUS();
            summaryDataEuro = polar.GetSummaryEuro();

            this.hrdata = hrdata;
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
            //summaryExpand.Dock = DockStyle.Top;
        }

        public void AddRideInfo(List<string> data)
        {
            dateOfRide.Text = data.ElementAt(0);
            timeOfRide.Text = data.ElementAt(1);
            lengthOfRide.Text = data.ElementAt(2);
            recordingInterval.Text = data.ElementAt(3) + " S";
        }
        public void SetFTP(double ftp)
        {
            this.ftpValue.Text = "" + ftp;
            this.ftp = ftp;
            AddFullData();
        }
        public void SetMaxHR(int maxHr)
        {
            this.MaxHR = maxHr;
            this.maxHRValue.Text = "" + maxHr;
        }
        public void AddSummaryData(Dictionary<string, string> data, bool unitType)
        {
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

        public void AddGraphs()
        {
            //we need to update the graph to show  all values
            graphPanel.Controls.Clear();
            ZedGraphControl graphControl = new ZedGraphControl();
           // graphControl.Click += HrControl_Click;
            Console.WriteLine("We are adding graphs");
            List<HrDataSingle> graphDataRaw;
            if (!selectedUnit)
            {
                graphDataRaw = hrdata.DataEuro;
            }
            else
            {
                graphDataRaw = hrdata.DataUS;
            }
            //we first load hr graph over time
            //we know the interval etc so we need to build the data set
            GraphPane graph = new GraphPane(new RectangleF(10f, 10f, 1000f, 1000f), "", "Time(S)", "Ride Visualisation");

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

                xdate.AddSeconds(1);
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
            //graph.XAxis.Scale.Format = "T";
            // graph.XAxis.Scale.MajorUnit = DateUnit.Second;
            // graph.XAxis.Scale.MinorUnit = DateUnit.Second;
            //graph.XAxis.Scale.Max = new XDate(0,0,0,test.Hour,test.Minute, test.Second);
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
            
            graphPanel.Controls.Add(graphControl);

        }

        private void HrControl_Click(object sender, EventArgs e)
        {
            if (!hrDetail.Visible)
            {
                hrDetail.SetGraphType("hr");
                hrDetail.Show();
            }
            else
            {
                hrDetail.BringToFront();
            }
        }

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
                dataSmall = hrdata.DataUS;
            }
            else
            {
                dataSmall = hrdata.DataEuro;
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
            Console.WriteLine("We have change 2");
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

        /// <summary>
        /// called when the graph is zoomed in or our and summary data is recalcualted
        /// </summary>
        /// <param name="start">start time</param>
        /// <param name="end">end time</param>
        private void GetSummaryBetweenValue(DateTime start, DateTime end)
        {

        }


    }
}
