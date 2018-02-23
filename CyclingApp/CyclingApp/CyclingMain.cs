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
        private double ftp;
        private int maxHr;
        DataView dw;
        DataViewImproved dw1;


        public CyclingMain()
        {
            InitializeComponent();
            ftp = 0.0;
            maxHr = 0;
            
        }

        /// <summary>
        /// Method called when inital button called to load file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            fileDialog.ShowDialog();
            
        }

       

        private void FileOk(object sender, CancelEventArgs e)
        {

            if (fileDialog.FileName != null || !fileDialog.FileName.Equals(""))
            {
                polar = new Polar();
                polar.LoadData(fileDialog.FileName);

                dw1 = new DataViewImproved( polar.GetUnit(),polar.GetHrData(), polar.GetSMODE(), this.polar, this, polar.GetRideInfo());
                //dw1.AddRideInfo(polar.GetRideInfo());
                dw1.AddFullData();
                dw1.SetFTP(ftp);
                dw1.Dock = DockStyle.Fill;
                singleView.Controls.Clear();
                singleView.Controls.Add(dw1);

                //menuStrip3.Hide();
   
            }
        }
        public void SetFTP(double ftp)
        {
            this.ftp = ftp;
            dw1.SetFTP(ftp);
            
        }
        public void SetHR(int hr)
        {
            this.maxHr = hr;
            dw1.SetMaxHR(hr);
        }
        public void ftpMenu_Click(object sender, EventArgs e)
        {
            //we need to show a dialog to allow entering of data
            EnterFTP enter = new EnterFTP(this, ftp);
            enter.Show();

        }

        private void enterMaximumHeartRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterHR enterHR = new EnterHR(this, maxHr);
            enterHR.Show();
        }
    }
}
