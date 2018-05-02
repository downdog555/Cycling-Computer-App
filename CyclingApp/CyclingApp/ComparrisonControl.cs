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
    public partial class ComparrisonControl : UserControl
    {
        private DataViewImproved dv;
        private HrData hrData;
        private List<HrDataSingle>[] data;
        private Dictionary<string, string>[] summary;
        private DataGridView fullData;
        private bool unit;
        private CyclingMain cyMain;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dv">dataview for this file</param>
        public ComparrisonControl(DataViewImproved dv, CyclingMain cyMain )
        {
            InitializeComponent();
            this.dv = dv;
            this.hrData = dv.GetFullData();
            this.cyMain = cyMain;
            unit = false;

            DateTime start = new DateTime(2018,1,1,0,0,0);
            DateTime end = dv.GetEndDateTime();
            summary = dv.GetSummary(start, end);
            //can get selection of data with get list data
            //  dv.GetListData(start, end);
            Dictionary<string, string> summaryData;
            if (!unit)
            {
                summaryData = summary[0];
            }
            else
            {
                summaryData = summary[1];
            }
            foreach (KeyValuePair<string, string> line in summaryData)
            {
                summaryBox.Text = summaryBox.Text + line.Key+" "+line.Value+"\n";
            }
        

            FullData();

            //just set the data in the view now
        }






        public void FullData()
        {
            dataGroupBox.Controls.Clear();
             fullData = new DataGridView();
            fullData.Dock = DockStyle.Fill;
            fullData.Columns.Add("time", "Time");

            fullData.CellMouseMove += dataGridView_CellMouseMove;
            fullData.CellMouseLeave += dataGridView_CellMouseLeave;
            Smode smode = dv.GetSmode();
          
            dataGroupBox.Controls.Add(fullData);

            fullData.Columns.Add("heartRate","Heart Rate(BPM)");
            if (smode.Speed)
            {
                if (unit)
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
                if (unit)
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
                if (unit)
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
            if (unit)
            {
                dataSmall = hrData.DataUS;
            }
            else
            {
                dataSmall = hrData.DataEuro;
            }
            DateTime dateTimeRide = dv.GetRideTime();

            int recordingIntervalInt = dv.GetInterval();
            foreach (HrDataSingle dataLine in dataSmall)
            {
                List<string> dataToBeInserted = new List<string>();
                //first add the time column
                //we need to add the interval
                dateTimeRide = dateTimeRide.AddSeconds(recordingIntervalInt);

                dataToBeInserted.Add(dateTimeRide.ToLongTimeString());
              
                    dataToBeInserted.Add("" + dataLine.HeartRate);
                
                if (smode.Speed)
                {
                    dataToBeInserted.Add("" + Math.Round(dataLine.Speed, 2));
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
        }

       

        public void UpdateSummary()
        {
            summaryBox.Text = "";
            DateTime start = new DateTime(2018, 1, 1, 0, 0, 0);
            DateTime end = dv.GetEndDateTime();
            summary = dv.GetSummary(start, end);
            //can get selection of data with get list data
            //  dv.GetListData(start, end);
            Dictionary<string, string> summaryData;
            if (!unit)
            {
                summaryData = summary[0];
            }
            else
            {
                summaryData = summary[1];
            }
            foreach (KeyValuePair<string, string> line in summaryData)
            {
                summaryBox.Text = summaryBox.Text + line.Key + " " + line.Value + "\n";
            }


        }

        public void SetHR(int hr)
        {
            dv.SetMaxHR(hr);

        }
        public void SetFTP(double ftp)
        {
            dv.SetFTP(ftp);
        }

        /// <summary>
        /// called when mouse enters cell,
        /// need to have timer check if mouse is still in there
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            //we need to call async method so the ui doesnt lag
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
               fullData[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Black;
            }

        }

        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                fullData[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }
    }
}
