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
    public partial class UserMarkerControl : UserControl
    {
        private int markerIndex;
        DataViewImproved dv;
        private DateTime start, end;
        private List<HrDataSingle>[] data;
        private bool drawMarkers = true;
        private bool selected = false;

        public bool DrawMarkers { get { return drawMarkers; } set { drawMarkers = value; } }
        public bool Selected { get { return selected; } set { selected = value; } }

        public UserMarkerControl(int marker, DataViewImproved dv, DateTime start, DateTime end, List<HrDataSingle>[] data)
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
        }

        private void remove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dv.RemoveUserSelection(markerIndex);
            
        }

        private void loadSectionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //on click assgin the current data to the selected data
            drawMarkers = true;
            dv.MarkerSelected = true;
            Marker[] temp = dv.MarkerList1.ToArray();
            temp[markerIndex].Selected = true;
            dv.MarkerList1 = temp.ToList();




            dv.SetData(data);
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
