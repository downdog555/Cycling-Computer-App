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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dv">dataview for this file</param>
        public ComparrisonControl(DataViewImproved dv )
        {
            InitializeComponent();
            this.dv = dv;
            this.hrData = dv.GetFullData();

            

            DateTime start = new DateTime(2018,1,1,0,0,0);
            DateTime end = dv.GetEndDateTime();
            dv.GetSummary(start, end);
            dv.GetListData(start, end);



            //just set the data in the view now
        }
    }
}
