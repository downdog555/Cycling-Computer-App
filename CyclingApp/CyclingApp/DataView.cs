﻿using System;
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
    public partial class DataView : UserControl
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
        
        public DataView( bool unitType, HrData hrdata, Smode smode, Polar polar, CyclingMain cym)
        {
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
            recordingInterval.Text = data.ElementAt(3)+" S";
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
            this.maxHRValue.Text = ""+maxHr;
        }
        public void AddSummaryData(Dictionary<string, string> data, bool unitType)
        {
            summaryPanel.Controls.Clear();
            string distanceUnit,speedUnit, distanceSmallUnit;
            //summaryExpand.Header = "Ride Summary";
            string[] units = GetUnits(unitType);
            distanceUnit = units[0];
            speedUnit = units[1];
            distanceSmallUnit = units[2];
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.AllowUserToAddRows = false;
            List<string> valuesToBeInserted = new List<string>();
            foreach (KeyValuePair<string, string>  value in data)
            {
               
                if (value.Key.Equals("Average Heart Rate"))
                {
                    if (percentHR)
                    {
                        grid.Columns.Add(value.Key, value.Key+"(% of max hr)");
                        double percent = (Convert.ToDouble(value.Value) / MaxHR) * 100;
                        valuesToBeInserted.Add(""+percent);
                    }
                    else
                    {
                        grid.Columns.Add(value.Key, value.Key+"(BPM)");
                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else if (value.Key.Equals("Maximum Heart Rate"))
                {
                    if (percentHR)
                    {
                        grid.Columns.Add(value.Key, value.Key + "(% of max hr)");
                        double percent = (Convert.ToDouble(value.Value) / MaxHR) * 100;
                        valuesToBeInserted.Add("" + percent);
                    }
                    else
                    {
                        grid.Columns.Add(value.Key, value.Key + "(BPM)");
                        MaxHR = Convert.ToInt32(value.Value);
                        maxHRValue.Text =""+ MaxHR;

                        valuesToBeInserted.Add(value.Value);
                    }
                }
                else if (value.Key.Equals("Minimum Heart Rate"))
                {
                    if (percentHR)
                    {
                        grid.Columns.Add(value.Key, value.Key + "(% of max hr)");
                        double percent = (Convert.ToDouble(value.Value) / MaxHR) * 100;
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
                        double percent = (Convert.ToDouble(value.Value) / ftp) * 100;
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
                        double percent = (Convert.ToDouble(value.Value) / ftp) * 100;
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
     
            grid.Rows.Insert(0,valuesToBeInserted.ToArray());
            summaryPanel.Controls.Add(grid);
         //  summaryExpand.Content.Controls.Add(grid);



        }

        public void AddGraphs()
        {
            graphPanel.Controls.Clear();
            ZedGraphControl hrControl = new ZedGraphControl();
            hrControl.Click += HrControl_Click;
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
            GraphPane hrGraph = new GraphPane(new RectangleF(10f, 10f, 1000f, 1000f), "", "Time(S)", "Ride Data");
            PointPairList hr = new PointPairList();
            int x = 0;
            foreach (HrDataSingle data in graphDataRaw)
            {
                PointPair point;
                //if we dont have percentage
                if (percentHR)
                {
                    //Console.WriteLine("We go into graphs");
                    //Console.WriteLine("HR = "+data.HeartRate+" meow max hr is + "+MaxHR);
                    //Console.WriteLine((double)data.HeartRate/MaxHR);
                    double y = (((double)data.HeartRate / MaxHR) * 100);
                    //Console.WriteLine(y);
                     point = new PointPair(x,y );
                }
                else
                {
                   // Console.WriteLine("We dont have percent");
                     point = new PointPair(x, data.HeartRate);
                }
                
                x = x + 1;
                hr.Add(point);
            }
            hrGraph.AddCurve("meow",hr,Color.Red, SymbolType.Diamond);
            hrControl.GraphPane = hrGraph;
            hrControl.Size = graphPanel.Size;
            hrControl.Show();
            hrControl.RestoreScale(hrGraph);
            //disable zoom
            hrControl.IsEnableZoom = false;
            graphPanel.Controls.Add(hrControl);

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
            hrDataPanel.Controls.Clear();
            DataGridView fullData = new DataGridView();
            fullData.Dock = DockStyle.Fill;
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
                fullData.Columns.Add("airPressure", "Air PRessure");
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
            foreach (HrDataSingle dataLine in dataSmall)
            {
                List<string> dataToBeInserted = new List<string>();
                if (percentHR)
                {
                    double percent = (Convert.ToDouble(dataLine.HeartRate) / MaxHR) * 100;
                    dataToBeInserted.Add("" +percent);
                }
                else
                {
                    dataToBeInserted.Add("" + dataLine.HeartRate);
                }
                if (smode.Speed)
                {
                    dataToBeInserted.Add(""+dataLine.Speed);
                }
                if (smode.Cadence)
                {
                    dataToBeInserted.Add("" + dataLine.Cadence);
                }
                if (smode.Altitude)
                {
                    dataToBeInserted.Add("" + dataLine.Altitude);
                }
                if (smode.Power)
                {
                    if (percentFTP)
                    {
                        
                        double percent = (Convert.ToDouble(dataLine.Power)/ftp)*100;
                        //Console.WriteLine(percent);
                        dataToBeInserted.Add(""+percent);
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
            hrDataPanel.Controls.Add(fullData);

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
                return new string[]{"KM","KM/H","M" };
            }
            else
            {
                return new string[] {"M","MPH","F" };
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

        private void euroSelection_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Euro Selected");
            selectedUnit = false;
            AddFullData();
            AddSummaryData(summaryDataEuro, selectedUnit);
            //load
            AddGraphs();
        }
    }
}
