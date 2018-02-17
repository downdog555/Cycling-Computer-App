using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclingApp
{
    /// <summary>
    /// Struct to represent a single line in the hr data
    /// </summary>
   public  struct HrDataSingle
    {
        private int heartRate, cadence, altitude, power, airPressure;
        /// <summary>
        /// Power balance and pedaling index
        /// </summary>
        private int pbPedInd;
        private double speed;
        

        public HrDataSingle(List<string> data, int version, int cadAlt = 46)
        {
            heartRate = cadence = altitude = power = airPressure = pbPedInd = 0;
            speed = 0.0;
            if (data.Count == 3)
            {
                heartRate =(int)Convert.ToDouble(data.ElementAt(0));
                speed = Convert.ToDouble(data.ElementAt(1))/10;
                if (cadAlt == 0)
                {
                    cadence = Convert.ToInt32(data.ElementAt(2));
                }
                else if(cadAlt == 1)
                {
                    altitude = (int)Convert.ToDouble(data.ElementAt(2)); ;
                }
            }
            else if (data.Count == 6)
            {
                heartRate = Convert.ToInt32(data.ElementAt(0));
                speed = Convert.ToDouble(data.ElementAt(1)) / 10;
                cadence = Convert.ToInt32(data.ElementAt(2));
                altitude = Convert.ToInt32(data.ElementAt(3));
                power = Convert.ToInt32(data.ElementAt(4));
                pbPedInd = Convert.ToInt32(data.ElementAt(5));


            }
            else if (data.Count == 7)
            {
                heartRate = Convert.ToInt32(data.ElementAt(0));
                speed = Convert.ToDouble(data.ElementAt(1)) / 10;
                cadence = Convert.ToInt32(data.ElementAt(2));
                //Console.WriteLine(data.ElementAt(3));
                altitude = (int)Convert.ToDouble(data.ElementAt(3));
                power = Convert.ToInt32(data.ElementAt(4));
                pbPedInd = Convert.ToInt32(data.ElementAt(5));
                airPressure = Convert.ToInt32(data.ElementAt(6));
            }
        }

        public int HeartRate { get { return heartRate; } }
        public int Cadence { get { return cadence; } }
        public int Altitude { get { return altitude; } }
        public int Power { get { return power; } }
        public int AirPressure { get { return airPressure; } }
        public int PbPedInd { get { return pbPedInd; } }
        public double Speed { get { return speed; } }
    }
}
