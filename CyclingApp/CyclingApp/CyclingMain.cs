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
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
            
        }

       

        private void FileOk(object sender, CancelEventArgs e)
        {

            if (fileDialog.FileName != null || fileDialog.FileName.Equals(""))
            {
                
                polar.LoadData(fileDialog.FileName);
               
                dw = new DataView( polar.GetUnit(),polar.GetHrData(), polar.GetSMODE(), this.polar);
                dw.AddRideInfo(polar.GetRideInfo());
                dw.AddFullData();
                dw.SetFTP(ftp);
                dw.Dock = DockStyle.Fill;

                singleView.Controls.Add(dw);

                menuStrip3.Hide();
   
            }
        }
        public void SetFTP(double ftp)
        {
            this.ftp = ftp;
            dw.SetFTP(ftp);
            
        }
        public void SetHR(int hr)
        {
            this.maxHr = hr;
            dw.SetMaxHR(hr);
        }
        private void ftpMenu_Click(object sender, EventArgs e)
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
