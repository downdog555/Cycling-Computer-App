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
    public partial class EnterFTP : Form
    {
        private CyclingMain cyclingMain;
        private double ftp;
        public EnterFTP(CyclingMain cymain,double ftp = 0)
        {
            InitializeComponent();
            this.cyclingMain = cymain;
            this.ftp = ftp;

        }

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
