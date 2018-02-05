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
            
   
            
           

 
        }

        public void AddSummaryData(Dictionary<string, string> data, bool unitType)
        {
            string distanceUnit,speedUnit, distanceSmallUnit;
            string[] units = GetUnits(unitType);
            distanceUnit = units[0];
            speedUnit = units[1];
            distanceSmallUnit = units[2];
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.AllowUserToAddRows = true;
            Label test = new Label();
            test.Text = "emwoowdaw";
            //summaryExpand.Content.Controls.Add(test);
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
