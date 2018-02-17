using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CyclingApp
{
    public partial class DataView : UserControl
    {
        private bool summaryHidden = false;
        private bool selectedUnit;
        private HrData hrdata;
        private Smode smode;
        private Dictionary<string, string> summaryDataUS, summaryDataEuro;
        
        public DataView(Dictionary<string, string> data, bool unitType, HrData hrdata, Smode smode)
        {
            summaryDataUS = new Dictionary<string, string>();
            summaryDataEuro = new Dictionary<string, string>();
            if (smode.Unit)
            {
                summaryDataUS = data;
            }
            else
            {
                summaryDataEuro = data;
            }
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
            AddSummaryData(data, unitType);
            AddFullData();
           //summaryExpand.Dock = DockStyle.Top;
            
   
            
           

 
        }
        public void AddRideInfo(List<string> data)
        {
            dateOfRide.Text = data.ElementAt(0);
            timeOfRide.Text = data.ElementAt(1);
            lengthOfRide.Text = data.ElementAt(2);
            recordingInterval.Text = data.ElementAt(3)+" S";
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
                grid.Columns.Add(value.Key, value.Key);
                valuesToBeInserted.Add(value.Value);
            }
     
            grid.Rows.Insert(0,valuesToBeInserted.ToArray());
            summaryPanel.Controls.Add(grid);
         //  summaryExpand.Content.Controls.Add(grid);



        }

        public void AddHeaderData()
        {
            /**
             *      For header data we need to display
             *      time and data
             *       
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * */
        }
        public void AddFullData()
        {
            hrDataPanel.Controls.Clear();
            DataGridView fullData = new DataGridView();
            fullData.Dock = DockStyle.Fill;
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
                fullData.Columns.Add("power", "Power(W)");

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
                    dataToBeInserted.Add("" + dataLine.Power);

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
        public void AddGraphs()
        {
        }

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

        private void euroSelection_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Euro Selected");
            selectedUnit = false;
            AddFullData();
            //load
        }
    }
}
