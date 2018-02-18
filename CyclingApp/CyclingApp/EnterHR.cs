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
    public partial class EnterHR : Form
    {
        private CyclingMain cyclingMain;
        private int hr;
        public EnterHR(CyclingMain cymain, int hr = 0)
        {
            InitializeComponent();
            this.cyclingMain = cymain;
            this.hr = hr;

        }

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
