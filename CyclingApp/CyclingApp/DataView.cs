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
    public partial class DataView : UserControl
    {
        public DataView()
        {
            InitializeComponent();
            Expander test = new Expander();
            test.Header.Text = "Meow ";
            Label labelContent = new Label();
            labelContent.Text = "This is the content part.\r\n\r\nYou can put any Controls here. You can use a Panel, a CustomControl, basically, anything you want.";
            labelContent.Size = new System.Drawing.Size(test.Width, 80);
            test.Content = labelContent;

            this.Controls.Add(test);
        }
    }
}
