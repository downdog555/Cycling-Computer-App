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
        public DataView(Dictionary<string, string> data, bool unitType)
        {
            
            InitializeComponent();
            AddSummaryData(data, unitType);
           summaryExpand.Dock = DockStyle.Top;
            
   
            
           

 
        }

        public void AddSummaryData(Dictionary<string, string> data, bool unitType)
        {
            string distanceUnit,speedUnit, distanceSmallUnit;
            summaryExpand.Header = "Ride Summary";
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
            summaryExpand.Content.Controls.Add(grid);



        }

        private string[] GetUnits(bool unitType)
        {
            if (!unitType)
            {
                return new string[]{"KM","KM/H","M" };
            }
            else
            {
                return new string[] {"Miles","MPH","Ft" };
            }
        }
    }
}
