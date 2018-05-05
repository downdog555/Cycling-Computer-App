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
    /// <summary>
    /// Class used to represent the form used to enter the Heart rate
    /// </summary>
    public partial class EnterHR : Form
    {
        private CyclingMain cyclingMain;
        private int hr;

        /// <summary>
        /// constructor for entering the max heart rate
        /// </summary>
        /// <param name="cymain">refreence back to the intial entry point so we can update values</param>
        /// <param name="hr">value for the heart rate, defaults to zero if one is not provided</param>
        public EnterHR(CyclingMain cymain, int hr = 0)
        {
            InitializeComponent();
            this.cyclingMain = cymain;
            this.hr = hr;

        }

        /// <summary>
        /// called when the submit button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ftpSubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                hr = Convert.ToInt32(hrBox.Text);
                cyclingMain.SetHR(hr);
                this.Close();

            }
            catch (Exception e1)
            {
                MessageBox.Show("Error: FTP wrong value" + e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
