using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CyclingApp
{
    /// <summary>
    /// Struct that represents a marker
    /// has a staring and end point of a double as that can be converetd to a XDate
    /// </summary>
    public struct Marker
    {
        private double min, max;
        private Color c;
        private bool drawMarker ;
        private bool selected;

        /// <summary>
        /// Constructor for the marker, generates a random colour
        /// </summary>
        /// <param name="min">starting value for the marker where it will cross the x axis</param>
        /// <param name="max">ending value for the marker where it will cross the y axis</param>
       public Marker(double min, double max)
        {
            this.min = min;
            this.max = max;
            Random rand = new Random();
            c = Color.FromArgb(255, rand.Next(255), rand.Next(255), rand.Next(255));
            drawMarker = true;
            selected = false;
        }

    
        /// <summary>
        /// Method used to genereate a colour
        /// specifcally used when blank constructor used
        /// </summary>
        public void GenColour()
        {
            Random rand = new Random();
            c = Color.FromArgb(255, rand.Next(255), rand.Next(255), rand.Next(255));
        }

        public double Min { get { return min; } set { min = value; } }
        public double Max { get { return max; } set { max = value; } }
        public Color C { get { return c; } set { c = value; } }

        public bool DrawMarker { get { return drawMarker; } set { drawMarker = value; } }

        public bool Selected { get { return selected; } set { selected = value; } }
    }
}
