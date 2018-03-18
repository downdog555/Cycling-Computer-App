using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CyclingApp
{
    struct Marker
    {
        private double min, max;
        private Color c;

       public Marker(double min, double max)
        {
            this.min = min;
            this.max = max;
            Random rand = new Random();
            c = Color.FromArgb(255, rand.Next(255), rand.Next(255), rand.Next(255));
        }

        public double Min { get { return min; } set { min = value; } }
        public double Max { get { return max; } set { max = value; } }
        public Color C { get { return c; } set { c = value; } }
    }
}
