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
            chunkSelectionBox.Text = "Full Data";
            
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
                file1  = new ComparrisonControl( dw1, this, "file1");
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
            if (file2Dialog.FileName != null && !file2Dialog.FileName.Equals(""))
            {
                polar2 = new Polar();
                polar2.LoadData(file2Dialog.FileName);
                
                dw2 = new DataViewImproved(polar2.GetUnit(), polar2.GetHrData(), polar2.GetSMODE(), this.polar2, this, polar2.GetRideInfo());
                //dw1.AddRideInfo(polar.GetRideInfo());
                dw2.AddFullData();
                dw2.SetFTP(ftp);
                dw2.Dock = DockStyle.Fill;

                if (dw2.GetInterval() != dw1.GetInterval())
                {
                    MessageBox.Show("Error: Please load a file with the same recording interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dw2 = null;
                    return;
                }
                //singleView.Controls.Clear();
                //singleView.Controls.Add(dw2);
                //enterMaximumHeartRateToolStripMenuItem.ShowDropDown();
               // ftpMenu.ShowDropDown();

                //menuStrip3.Hide();
                file2 = new ComparrisonControl(dw2, this, "file2");
                AddComparison();
            }
        }


        /// <summary>
        /// Called to add the comparrison controls
        /// </summary>
        private void AddComparison()
        {
            comparisonPanel.Controls.Clear();
            comparisonPanel.Controls.Add(file1);

            if (file2 != null)
            {
                comparisonPanel.Controls.Add(file2);
            }        
            
        }

        /// <summary>
        /// Called when the load file 2 button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadFile2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file2Dialog.ShowDialog();
        }

        /// <summary>
        /// used to get value of opposite file at specified poisition
        /// </summary>
        /// <param name="headerText">the header text of the column, used to check if the column exists</param>
        /// <param name="rowIndex">the index of the row used with colulmn to find cell</param>
        /// <param name="file">which file has requested the value, used to find which is the opposit</param>
        /// <param name="grid">which grid we are checking summary or full data</param>
        /// <returns></returns>
        internal string GetValue(string headerText, int rowIndex, string file, string grid)
        {
            ComparrisonControl temp;
            if (file.Equals("file1"))
            {
                temp = file2;
            }
            else
            {
                temp = file1;
            }
            String value = "NOTFOUND";
            if (temp != null)
            {
                value = temp.GetValue(headerText, rowIndex, grid);
            }
            if (value == null || value.Equals("N/A"))
            {
                value = "NOTFOUND";
            }

           
           
            return value;

        }

        /// <summary>
        /// called when chunk button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChunkDataButton_Click(object sender, EventArgs e)
        {
            if (dw1 == null || dw2 == null)
            {
                MessageBox.Show("Error: Please load both files" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int numberOfChunks = 0;
            int length = 0;
            try
            {
                numberOfChunks = Convert.ToInt32(ChunkSizeBox.Text);
                //we need to see if they are of different lengths
                //if they are the final selection box 




                if (dw1.GetFullData().DataEuro.Count == dw2.GetFullData().DataEuro.Count)
                {
                    length = dw1.GetFullData().DataEuro.Count;
                }
                else if (dw1.GetFullData().DataEuro.Count > dw2.GetFullData().DataEuro.Count)
                {
                    length = dw2.GetFullData().DataEuro.Count;
                }
                else if (dw1.GetFullData().DataEuro.Count < dw2.GetFullData().DataEuro.Count)
                {
                    length = dw1.GetFullData().DataEuro.Count;
                }

                int chunkSize = length / numberOfChunks;



                file1.ChunkData(chunkSize, numberOfChunks);
                file2.ChunkData(chunkSize, numberOfChunks);

                chunkSelectionBox.Items.Clear();
                chunkSelectionBox.Items.Add("Full Data");
                for (int i = 1; i <= numberOfChunks; i++)
                {
                    chunkSelectionBox.Items.Add("" + i + "/" + numberOfChunks);
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show("Error: Number of Chunks wrong value" + e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// called when load chunk button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadChunkButton_Click(object sender, EventArgs e)
        {
            //get value from selection box
            string selectionValue = chunkSelectionBox.Text;
            if (selectionValue.Equals("Full Data"))
            {
                file1.LoadChunk(-1);
                if (file2 != null)
                {
                    file2.LoadChunk(-1);
                }
                
                

            }
            else
            {
                int selectionValueInt = Convert.ToInt32(selectionValue.Split('/')[0]);
                file1.LoadChunk(selectionValueInt);
                if (file2 != null)
                {
                    file2.LoadChunk(selectionValueInt);
                }
                

            }
        }
    }
}
