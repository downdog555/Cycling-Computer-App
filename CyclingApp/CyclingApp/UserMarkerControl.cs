﻿using System;
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
    /// class used to represent eh user marker control
    /// </summary>
    public partial class UserMarkerControl : UserControl
    {
        private int markerIndex;
        DataViewImproved dv;
        private DateTime start, end;
        private List<HrDataSingle>[] data;
        private bool drawMarkers = true;
        private bool selected = false;
        private MultipleSummaries ms;
        private bool unit;
        private bool type;
        private int interval;
        public bool DrawMarkers { get { return drawMarkers; } set { drawMarkers = value; } }
        public bool Selected { get { return selected; } set { selected = value; } }

        public bool Selected1
        {
            get
            {
                return selected;
            }

            set
            {
                selected = value;
                if (selected == true)
                {
                    chunkData.Show();
                }
                else
                {
                    chunkData.Hide();
                }
            }
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="marker">what index the marker is</param>
        /// <param name="dv">a reference to the data view</param>
        /// <param name="start">start time</param>
        /// <param name="end">end time</param>
        /// <param name="data">the data of this section</param>
        /// <param name="unit">the unit in this file</param>
        /// <param name="interval">the recording interval</param>
        /// <param name="type">true if marker is used for the chunks of data, false if user selection</param>
        public UserMarkerControl(int marker, DataViewImproved dv, DateTime start, DateTime end, List<HrDataSingle>[] data, bool unit, int interval, bool type)
        {
            InitializeComponent();
            this.markerIndex = marker;
            this.dv = dv;
            this.start = start;
            this.end = end;
            startTime.Text = start.ToLongTimeString();
            endTime.Text = end.ToLongTimeString();
            Console.WriteLine("Length of data in marker: "+data[0].Count);
            this.data = data;
            this.unit = unit;
            this.interval = interval;
            this.type = type;
            //chunkData.Hide();
            if (type)
            {
                loadSectionLink.Hide();
                chunkData.Hide();
            }
        }

        /// <summary>
        /// used to remove this marker from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void remove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (type)
            {
                dv.RemoveChunkSelection(markerIndex);
            }
            else
            {
                dv.RemoveUserSelection(markerIndex);
            }
           
            
        }

        /// <summary>
        /// called when the load section link is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadSectionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //on click assgin the current data to the selected data
            drawMarkers = true;
            dv.MarkerSelected = true;
            Marker[] temp = dv.MarkerList1.ToArray();
            temp[markerIndex].Selected = true;
            dv.MarkerList1 = temp.ToList();
            Console.WriteLine("We have loaded");
           // chunkData.Show();
            //this.Invalidate();



            dv.SetData(data);
            dv.AddGraphs();

        }

        /// <summary>
        /// called when the chunk data link is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chunkData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //we need to load the chunk data form etc and allow for input into the amount of chunks
            //we then need to show the summaries based on those chunks
            ms = new MultipleSummaries(data, dv, unit, interval);
            ms.Show();
          //  dv.AddGraphs();
        }

        /// <summary>
        /// called when the view summary is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dv.GetAndLoadSummary(start, end);
        }
    }
}
