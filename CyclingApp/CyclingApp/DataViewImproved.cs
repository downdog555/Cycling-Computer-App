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
            
            graphHr = true;

            if (smode.Power)
            {
                graphPower = true;
            }
            else
            {
                graphPower = false;
                powerButton.Hide();
            }
            if (smode.Speed)
            {
                graphSpeed = true;
            }
            else
            {
                graphSpeed = false;
                speedButton.Hide();
            }
            if (smode.Cadence)
            {
                graphCadence = true;
            }
            else
            {
                graphCadence = false;
                cadenceButton.Hide();
            }
            if (smode.Altitude)
            {
                graphAltitude = true;
            }
            else
            {
                graphAltitude = false;
                altitudeButton.Hide();
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
            InitializeComponent();
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
                summaryDataBox.Text = summaryDataBox.Text + value.Key + ": " + value.Value + "\n";
                
                if (value.Key.Equals("Average Heart Rate"))
                {
                    if (percentHR)
                    {
                        grid.Columns.Add(value.Key, value.Key + "(% of max hr)");
                        double percent = Math.Round((Convert.ToDouble(value.Value) / MaxHR) * 100,2);
                        valuesToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        grid.Columns.Add(value.Key, value.Key + "(BPM)");
                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else if (value.Key.Equals("Maximum Heart Rate"))
                {
                    if (percentHR)
                    {
                        grid.Columns.Add(value.Key, value.Key + "(% of max hr)");
                        double percent = Math.Round((Convert.ToDouble(value.Value) / MaxHR) * 100,2);
                        valuesToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        grid.Columns.Add(value.Key, value.Key + "(BPM)");
                        MaxHR = Convert.ToInt32(value.Value);
                        maxHRValue.Text = "" + MaxHR;

                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else if (value.Key.Equals("Minimum Heart Rate"))
                {
                    if (percentHR)
                    {
                        grid.Columns.Add(value.Key, value.Key + "(% of max hr)");
                        double percent = Math.Round((Convert.ToDouble(value.Value) / MaxHR) * 100,2);
                        valuesToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        grid.Columns.Add(value.Key, value.Key + "(BPM)");
                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else if (value.Key.Equals("Average Power"))
                {
                    if (percentFTP)
                    {
                        grid.Columns.Add(value.Key, value.Key + "(% of FTP)");
                        double percent = Math.Round((Convert.ToDouble(value.Value) / ftp) * 100,2);
                        valuesToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        grid.Columns.Add(value.Key, value.Key + "(W)");
                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else if (value.Key.Equals("Maximum Power"))
                {
                    if (percentFTP)
                    {
                        grid.Columns.Add(value.Key, value.Key + "(% of FTP)");
                        double percent = Math.Round((Convert.ToDouble(value.Value) / ftp) * 100,2);
                        valuesToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        grid.Columns.Add(value.Key, value.Key + "(W)");
                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else
                {
                    grid.Columns.Add(value.Key, value.Key);
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
            foreach (HrDataSingle data in graphDataRaw)
            {
                PointPair powerPoint;

                if (graphPower)
                {
                    if (percentFTP)
                    {
                        powerPoint = new PointPair(x, ((double)data.Power / ftp) * 100);
                    }
                    else
                    {
                        powerPoint = new PointPair(x, data.Power);
                    }
                    power.Add(powerPoint);
                   
                }

                PointPair speedPoint;
                if (graphSpeed)
                {
                    speedPoint = new PointPair(x, data.Speed);
                    speed.Add(speedPoint);
                }

                PointPair cadencePoint;
                if (graphCadence)
                {
                    cadencePoint = new PointPair(x, data.Cadence);
                    cadence.Add(cadencePoint);

                }

                PointPair altitudePoint;
                if (graphAltitude)
                {
                    altitudePoint = new PointPair(x, data.Altitude);
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
                    pointHR = new PointPair(x, y);
                }
                else
                {
                    // Console.WriteLine("We dont have percent");
                    pointHR = new PointPair(x, data.HeartRate);
                }

                x = x + 1;
                hr.Add(pointHR);
            }

            if (graphHr)
            {
                graph.AddCurve("Heart Rate", hr, Color.Red, SymbolType.Diamond);
            }

            if (graphPower)
            {
                graph.AddCurve("Power", power, Color.Blue, SymbolType.Default);
            }

            if (graphSpeed)
            {
                graph.AddCurve("Speed", speed, Color.Green, SymbolType.Circle);
            }

            if (graphAltitude)
            {
                graph.AddCurve("Altitude", altitude, Color.Brown, SymbolType.Square);
            }

            if (graphCadence)
            {
                graph.AddCurve("Cadence", cadence, Color.Black, SymbolType.Default);
            }
            





            graphControl.GraphPane = graph;
            graphControl.Size = graphPanel.Size;
            graphControl.Show();
            graphControl.RestoreScale(graph);
            //disable zoom
            graphControl.IsEnableZoom = true;
            graphControl.IsEnableVZoom = false;
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
                fullData.Columns.Add("hr", "Heart Rate");
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
                    dataToBeInserted.Add("" + dataLine.PbPedInd);
                }
                if (smode.PowerPedallingIndex)
                {
                    dataToBeInserted.Add("" + dataLine.PbPedInd);
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

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cyclingMain.loadFileToolStripMenuItem_Click(sender, e);
        }

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
