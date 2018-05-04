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
    /// <summary>
    /// Class that represents the comparison control
    /// </summary>
    public partial class ComparrisonControl : UserControl
    {
        private DataViewImproved dv;
        private HrData hrData;
        private List<HrDataSingle>[] data;
        private Dictionary<string, string>[] summary;
        private DataGridView fullData;

        private DataGridView summaryDataGrid;
        private bool unit;
        private CyclingMain cyMain;
        private string file;

       /// <summary>
       /// Constructor
       /// </summary>
       /// <param name="dv">reference to the dataview for this file</param>
       /// <param name="cyMain">refrenec to the main window</param>
       /// <param name="file">file, file 1 or file 2</param>
        public ComparrisonControl(DataViewImproved dv, CyclingMain cyMain, string file )
        {
            InitializeComponent();
            this.dv = dv;
            this.hrData = dv.GetFullData();
            this.cyMain = cyMain;
            unit = false;
            this.file = file;
            groupBox1.Text = file;


            UpdateSummaryNoDate();
            FullData();

            //just set the data in the view now
        }



        /// <summary>
        /// Called to get fulldata for a specific time span
        /// </summary>
        /// <param name="start">the start time</param>
        /// <param name="end">the end time</param>
        private void FullDataDate(DateTime start, DateTime end)
        {
            data = dv.GetListData(start, end);
            hrData.DataEuro = data[0];
            hrData.DataUS = data[1];

            FullData();
        }


        /// <summary>
        /// called toadd full data with no date
        /// </summary>
        private void FullDataNoDate()
        {
            //we use th 
            //we assgin the data again
            this.hrData = dv.GetFullData();
            FullData();
        }

        /// <summary>
        /// Adds the full hr data to the display
        /// </summary>
        public void FullData()
        {
            dataGroupBox.Controls.Clear();
            fullData = new DataGridView();
            fullData.Dock = DockStyle.Fill;
            fullData.Columns.Add("time", "Time");

            fullData.CellMouseEnter += dataGridView_CellMouseMove;
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


        /// <summary>
        /// Called to update the summary section with a specific span of time
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void UpdateSummaryDate(DateTime start, DateTime end)
        {
            UpdateSummary(start, end);
        }


        /// <summary>
        /// Called when summary is needed to be updated, with out a date, meaning that it resets the data selection
        /// </summary>
        public void UpdateSummaryNoDate()
        {
            DateTime start = new DateTime(2018, 1, 1, 0, 0, 0);
            DateTime end = dv.GetEndDateTime();
            UpdateSummary(start, end);
        }

        /// <summary>
        /// Function to update the summary grid view with new data
        /// </summary>
        /// <param name="start">the start time of the section to load</param>
        /// <param name="end">end time/date of the section to load</param>
        private void UpdateSummary(DateTime start, DateTime end)
        {

            summaryGroupBox.Controls.Clear();
            summaryDataGrid = new DataGridView();
            summaryDataGrid.Dock = DockStyle.Fill;
           

            summaryDataGrid.CellMouseEnter += summaryDataGrid_CellMouseEnter;
            summaryDataGrid.CellMouseLeave += summaryDataGrid_CellMouseLeave;

            summaryGroupBox.Controls.Add(summaryDataGrid);

            
           
            summary = dv.GetSummary(start, end);
            //can get selection of data with get list data
            //  dv.GetListData(start, end);
            List<string> dataToBeInserted = new List<string>();

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
                summaryDataGrid.Columns.Add(line.Key, line.Key);
                dataToBeInserted.Add(line.Value.Split(' ')[0]);
            }

            summaryDataGrid.Rows.Add(dataToBeInserted.ToArray());
        }


        /// <summary>
        /// Event called when mouse leaves a cell on the summary section, resets background colour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void summaryDataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1)
            {
                summaryDataGrid[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }


        /// <summary>
        /// Event called when mouse enters cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void summaryDataGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //we need to call get value from other control

                string value = cyMain.GetValue(summaryDataGrid[e.ColumnIndex, 0].OwningColumn.HeaderText, e.RowIndex, file, "summary");

                if (value == null||!value.Equals("NOTFOUND"))
                {

                    Console.WriteLine("Value is: " + value);
                    double valueDoub = Convert.ToDouble(value);
                    double currentValue = Convert.ToDouble((string)summaryDataGrid[e.ColumnIndex, e.RowIndex].Value);
                    double sumValue = currentValue - valueDoub;

                    if (sumValue > 0)
                    {
                        summaryDataGrid[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Green;
                        summaryDataGrid[e.ColumnIndex, e.RowIndex].ToolTipText = "+ " + sumValue;
                    }
                    else if (sumValue < 0)
                    {
                        summaryDataGrid[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
                        summaryDataGrid[e.ColumnIndex, e.RowIndex].ToolTipText = "" + sumValue;
                    }
                    else
                    {
                        summaryDataGrid[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Gray;
                        summaryDataGrid[e.ColumnIndex, e.RowIndex].ToolTipText = "+/- 0";
                    }


                }

            }
        }

        public void SetHR(int hr)
        {
            dv.SetMaxHR(hr);
            UpdateSummaryNoDate();

        }
        public void SetFTP(double ftp)
        {
            dv.SetFTP(ftp);
            UpdateSummaryNoDate();
        }

        /// <summary>
        /// called when mouse enters cell,
        /// used to calcualte oppostie value if it exists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellMouseMove(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1)
            {
                //we need to call get value from other control
                
               string value = cyMain.GetValue(fullData[e.ColumnIndex, 0].OwningColumn.HeaderText, e.RowIndex, file, "full");

                if (!value.Equals("NOTFOUND") && fullData[e.ColumnIndex, e.RowIndex].Value != null && !fullData[e.ColumnIndex, e.RowIndex].Value.Equals("N/A"))
                {
                   
                    Console.WriteLine("Value is: "+value);
                    double valueDoub = Convert.ToDouble(value);

                   
                    double currentValue = Convert.ToDouble((string)fullData[e.ColumnIndex, e.RowIndex].Value);
                    double sumValue = currentValue - valueDoub;

                    if (sumValue > 0)
                    {
                        fullData[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Green;
                        fullData[e.ColumnIndex, e.RowIndex].ToolTipText = "+ "+sumValue;
                    }
                    else if (sumValue < 0)
                    {
                        fullData[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
                        fullData[e.ColumnIndex, e.RowIndex].ToolTipText = "" +sumValue;
                    }
                    else
                    {
                        fullData[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Gray;
                        fullData[e.ColumnIndex, e.RowIndex].ToolTipText = "+/- 0";
                    }
                    

                }
              
            }

        }

        /// <summary>
        /// Called by cycling main to get a value of a specific cell
        /// </summary>
        /// <param name="headerText">the text of the header of the column to check if it exists in this file</param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        internal string GetValue(string headerText, int rowIndex, string grid)
        {
            DataGridView temp;
            if (grid.Equals("full"))
            {
                temp = fullData;
            }
            else
            {
                temp = summaryDataGrid;
            }
            string value = "NOTFOUND";
            int columnNum = 0;
            bool found = false;
            for (int i = 0; i < temp.ColumnCount; i++)
            {
                if (temp[i, 0].OwningColumn.HeaderText.Equals(headerText))
                {
                    found = true;
                    columnNum = i;
                }

            }



            if (found)
            {

                if (rowIndex < temp.RowCount)
                {
                    value = (string)temp[columnNum, rowIndex].Value;
                }
               
            }

            return value;
        }

        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1)
            {
                fullData[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }
    }
}
