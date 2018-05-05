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
    /// class representing the contorl used for the summary of a single file
    /// </summary>
    public partial class summary : UserControl
    {
        List<string> summaryList;
        double TSS, IF;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="summary">the list of summary data</param>
        /// <param name="TSS">the training stress score</param>
        /// <param name="IF">the intensity factor</param>
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
