﻿using System;
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
      /// <summary>
      /// polar used to reference the polar reader
      /// </summary>
        private Polar polar = new Polar();

        /// <summary>
        /// used to refernece the polar reader for the second file
        /// </summary>
        private Polar polar2 = new Polar();
        /// <summary>
        /// FTP of the user once entered
        /// </summary>
        private double ftp;
        /// <summary>
        /// max  heart rate once entered
        /// </summary>
        private int maxHr;
        /// <summary>
        /// Data view used to display and furhter process datra
        /// </summary>
        private DataViewImproved dw1;
        private DataViewImproved dw2;

        /// <summary>
        /// List of files loaded
        /// </summary>
        List<DataViewImproved> fileLists = new List<DataViewImproved>();

        private ComparrisonControl file1;
        private ComparrisonControl file2;



        /// <summary>
        /// Constructor for this class
        /// </summary>
        public CyclingMain()
        {
            InitializeComponent();
            ftp = 0.0;
            maxHr = 0;
            enterMaximumHeartRateToolStripMenuItem.HideDropDown();
            ftpMenu.HideDropDown();
            this.Invalidate();
            dw1 = null;
            
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

       
        /// <summary>
        /// Event called when ok is pressed on the fileopendialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                enterMaximumHeartRateToolStripMenuItem.ShowDropDown();
                ftpMenu.ShowDropDown();

                //menuStrip3.Hide();
                file1  = new ComparrisonControl( dw1, this);
                AddComparison();
            }
        }
        /// <summary>
        /// used to set the ftp values
        /// </summary>
        /// <param name="ftp">ftp that has been entered</param>
        public void SetFTP(double ftp)
        {
            this.ftp = ftp;
            dw1.SetFTP(ftp);


            file1.SetFTP(ftp);
            if (file2 != null)
            {
                file2.SetFTP(ftp);
            }
        }
        /// <summary>
        /// used to set the heart rate
        /// </summary>
        /// <param name="hr">heart rate entered</param>
        public void SetHR(int hr)
        {

            this.maxHr = hr;
            dw1.SetMaxHR(hr);

            file1.SetHR(hr);
            if (file2 != null)
            {
                file2.SetHR(hr);
            }
        }

        public string GetValueFromFile2(int row, int column)
        {
            string value = "String Value";





            return value;
        }

        /// <summary>
        /// event called when ftpmenu is clicked in turn opening the form to enter the value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ftpMenu_Click(object sender, EventArgs e)
        {
            if (dw1 != null)
            {
                //we need to show a dialog to allow entering of data
                EnterFTP enter = new EnterFTP(this, ftp);
                enter.Show();
            }
            else
            {
                MessageBox.Show("Please load a file before setting FTP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        /// <summary>
        /// event called when the enter heart rate button is called, in turn opening the form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterMaximumHeartRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dw1 != null)
            {
                EnterHR enterHR = new EnterHR(this, maxHr);
                enterHR.Show();
            }
            else
            {
                MessageBox.Show("Please load a file before setting Max HR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void loadFile1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
        }

        /// <summary>
        /// Called when load file two dialog is file ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void file2Dialog_FileOk(object sender, CancelEventArgs e)
        {
            if (file2Dialog.FileName != null || !file2Dialog.FileName.Equals(""))
            {
                polar2 = new Polar();
                polar2.LoadData(file2Dialog.FileName);

                dw2 = new DataViewImproved(polar2.GetUnit(), polar2.GetHrData(), polar2.GetSMODE(), this.polar2, this, polar2.GetRideInfo());
                //dw1.AddRideInfo(polar.GetRideInfo());
                dw2.AddFullData();
                dw2.SetFTP(ftp);
                dw2.Dock = DockStyle.Fill;
                //singleView.Controls.Clear();
                //singleView.Controls.Add(dw2);
                //enterMaximumHeartRateToolStripMenuItem.ShowDropDown();
               // ftpMenu.ShowDropDown();

                //menuStrip3.Hide();
                file2 = new ComparrisonControl(dw2, this);
                AddComparison();
            }
        }



        private void AddComparison()
        {
            comparisonPanel.Controls.Clear();
            comparisonPanel.Controls.Add(file1);

            if (file2 != null)
            {
                comparisonPanel.Controls.Add(file2);
            }        
            
        }

        private void loadFile2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file2Dialog.ShowDialog();
        }
    }
}
