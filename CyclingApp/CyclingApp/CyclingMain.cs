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
      
        private Polar polar = new Polar();
        public CyclingMain()
        {
          

         
            InitializeComponent();
            
        }

        /// <summary>
        /// Method called when inital button called to load file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
            
        }

       

        private void FileOk(object sender, CancelEventArgs e)
        {
            if (fileDialog.FileName != null || fileDialog.FileName.Equals(""))
            {
                polar.LoadData(fileDialog.FileName);
                DataView dw = new DataView(polar.GetSummaryData(), polar.GetUnit());
                dw.Dock = DockStyle.Fill;
                singleView.Controls.Add(dw);
                menuStrip3.Hide();
            }
        }
    }
}
