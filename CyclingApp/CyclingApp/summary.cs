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
    public partial class summary : UserControl
    {
        List<string> summaryList;
        double TSS, IF;
        public summary(List<string> summary, double TSS, double IF)
        {
            InitializeComponent();
            this.summaryList = summary;
            this.TSS = TSS;
            this.IF = IF;

            this.ifData.Text = "" + IF;
            this.tssData.Text = "" + TSS;
            string data = "";
            foreach (string s in summaryList)
            {
                data = data + s + "\n";
            }
            summaryDataBox.Text = data;

        }

        private void summary_Load(object sender, EventArgs e)
        {

        }
    }
}
