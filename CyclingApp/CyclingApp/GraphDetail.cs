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
    public partial class GraphDetail : Form
    {
        private string graphType;
        public GraphDetail()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Called to set up the current graphs
        /// </summary>
        private void Setup()
        {

        }

        public void SetGraphType(string graphType)
        {
            this.graphType = graphType;
            Setup();
        }

        /// <summary>
        /// prevents from from closing proper;y just hides the form, so we can access it again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HRGraphDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
