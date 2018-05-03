﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace CyclingApp
{
    public partial class MultipleSummaries : Form
    {
        private List<HrDataSingle>[] data;
        private DataViewImproved dv;
        private List<Marker> markers;
        private int interval;
        public MultipleSummaries(List<HrDataSingle>[] data, DataViewImproved dv, bool Unit, int interval)
        {
            InitializeComponent();
            this.data = data;
            this.dv = dv;
            this.interval = interval;
            this.markers = new List<Marker>();
        }

        /// <summary>
        /// Called when button to split the data is pressed
        /// checks for the number of chunbks wanted and if it is a valid integer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chunkButton_Click(object sender, EventArgs e)
        {
            int numberChunks = 0;
            try
            {
                numberChunks = Convert.ToInt32(chunkNum.Text);
                //if it works then we can add data on here
                //we need to pass back where the markers are needed
                //first we need to split the data up into a number chunks
               



            }
            catch (Exception e1)
            {
                MessageBox.Show("Error", "Data entered is not in correct format",MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }


            int chunkSize = data[0].Count / numberChunks;
            //we can then go through and ge thte start and end points or create markers
            Marker m = new Marker();
            XDate start = new XDate(2018, 1, 1, 0, 0, 0);
            m.Min = start;
            bool startBool = false;
            int x = 0;
            for (int i = 0; i < data[0].Count; i++)
            {


                if (startBool)
                {
                    m.GenColour();
                    markers.Add(m);
                    m = new Marker();
                    XDate temp = new XDate(2018, 1, 1, 0, 0, 0);
                    temp.AddSeconds(i * interval);
                    m.Min = temp;
                    startBool = false;
                }
                if (x == chunkSize - 1)
                {
                    startBool = true;
                    XDate temp = new XDate(2018, 1, 1, 0, 0, 0);
                    temp.AddSeconds(i * interval);
                    m.Max = temp;
                    x = 0;

                }








                x += 1;

            }



            //we need to pass the markers back and then generate the summaries
            //we need a control type thing to edit........



            Console.WriteLine("We have " + markers.Count + " chunks");

            //we then need the markers to be drawn

            dv.AddMarkers(markers);
            dv.AddChunkMarkers();
            this.Close();
        }

        private void summaries_Enter(object sender, EventArgs e)
        {

        }

        private void MultipleSummaries_Load(object sender, EventArgs e)
        {
            Screen s = Screen.PrimaryScreen;
            //on load place in bottom third of screen
            this.Left = (s.WorkingArea.Width/2);
            this.Top= (s.WorkingArea.Height/2);


        }
    }
}