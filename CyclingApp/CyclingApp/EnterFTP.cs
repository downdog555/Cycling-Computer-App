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
    /// Class to represent the form used to enter the FTP
    /// </summary>
    public partial class EnterFTP : Form
    {
        private CyclingMain cyclingMain;
        private double ftp;

        /// <summary>
        /// constructor for the current fdorm
        /// </summary>
        /// <param name="cymain">reference to the intial entrypoint so we can update values</param>
        /// <param name="ftp">the current FTP, defaults to zero if one is not provided</param>
        public EnterFTP(CyclingMain cymain,double ftp = 0)
        {
            InitializeComponent();
            //assigns the values
            this.cyclingMain = cymain;
            this.ftp = ftp;

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
                ftp = Convert.ToDouble(ftpBox.Text);
                cyclingMain.SetFTP(ftp);
                this.Close();

            }
            catch (Exception e1)
            {
                MessageBox.Show("Error: FTP wrong value"+e1.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
