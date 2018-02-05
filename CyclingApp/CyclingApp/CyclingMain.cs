using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyclingApp
{
    public partial class CyclingMain : Form
    {
        Polar polar = new Polar();
        public CyclingMain()
        {

            polar.LoadData(@"C:\Users\Reec\Downloads\ASDBExampleCycleComputerData.hrm");
            InitializeComponent();
            DataView dw = new DataView(polar.GetSummaryData(), polar.GetUnit());
            singleView.Controls.Add(dw);
        }
    }
}
