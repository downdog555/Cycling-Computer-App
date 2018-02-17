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
        private Smode smode;

        public HrDataSingle(List<string> data, int version, Smode smode ,int cadAlt = 46)
        {
            
            this.smode = smode;
            heartRate = cadence = altitude = power = airPressure = pbPedInd = 0;
            speed = 0.0;
            if (version == 105)
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
            else if (version == 106)
            {
                heartRate = Convert.ToInt32(data.ElementAt(0));
              

                if (smode.Speed)
                {
                    speed = Convert.ToDouble(data.ElementAt(1)) / 10;
                }

                if (smode.Cadence && smode.Speed)
                {
                    cadence = Convert.ToInt32(data.ElementAt(2));
                }
                else if (!smode.Speed)
                {
                    cadence = Convert.ToInt32(data.ElementAt(1));
                }

                if (smode.Altitude && smode.Cadence && smode.Speed)
                {
                    altitude = Convert.ToInt32(data.ElementAt(3).Split('.')[0]);
                }
                else if (!smode.Cadence && !smode.Speed && smode.Altitude)
                {
                    altitude = Convert.ToInt32(data.ElementAt(1).Split('.')[0]);
                }
                else if (!smode.Cadence && smode.Speed && smode.Altitude)
                {
                    altitude = Convert.ToInt32(data.ElementAt(2).Split('.')[0]);
                }
                else if (smode.Cadence && !smode.Speed && smode.Altitude)
                {
                    altitude = Convert.ToInt32(data.ElementAt(2).Split('.')[0]);
                }


                if (smode.Power && smode.Speed && smode.Altitude && smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(4));
                }
                else if(smode.Power && !smode.Speed && !smode.Altitude && !smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(1));
                }
                else if (smode.Power && smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(3));
                }
                else if (smode.Power && smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(3));
                }
                else if (smode.Power && !smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(3));
                }
                else if (smode.Power && !smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(3));
                }
                else if (smode.Power && !smode.Speed && smode.Altitude && smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(3));
                }



                if (smode.PowerLeftRightBalance && smode.Power && smode.Speed && smode.Altitude && smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(5));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && !smode.Altitude && !smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(2));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(4));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(4));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(4));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(4));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && smode.Altitude && smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(4));
                }




                


            }
            else if (version == 107)
            {
                heartRate = Convert.ToInt32(data.ElementAt(0));


                if (smode.Speed)
                {
                    speed = Convert.ToDouble(data.ElementAt(1)) / 10;
                }

                if (smode.Cadence && smode.Speed)
                {
                    cadence = Convert.ToInt32(data.ElementAt(2));
                }
                else if (!smode.Speed)
                {
                    cadence = Convert.ToInt32(data.ElementAt(1));
                }

                if (smode.Altitude && smode.Cadence && smode.Speed)
                {
                    altitude = Convert.ToInt32(data.ElementAt(3).Split('.')[0]);
                }
                else if (!smode.Cadence && !smode.Speed && smode.Altitude)
                {
                    altitude = Convert.ToInt32(data.ElementAt(1).Split('.')[0]);
                }
                else if (!smode.Cadence && smode.Speed && smode.Altitude)
                {
                    altitude = Convert.ToInt32(data.ElementAt(2).Split('.')[0]);
                }
                else if (smode.Cadence && !smode.Speed && smode.Altitude)
                {
                    altitude = Convert.ToInt32(data.ElementAt(2).Split('.')[0]);
                }


                if (smode.Power && smode.Speed && smode.Altitude && smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(4));
                }
                else if (smode.Power && !smode.Speed && !smode.Altitude && !smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(1));
                }
                else if (smode.Power && smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(3));
                }
                else if (smode.Power && smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(3));
                }
                else if (smode.Power && !smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(3));
                }
                else if (smode.Power && !smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(3));
                }
                else if (smode.Power && !smode.Speed && smode.Altitude && smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(3));
                }



                if (smode.PowerLeftRightBalance && smode.Power && smode.Speed && smode.Altitude && smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(5));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && !smode.Altitude && !smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(2));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(4));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(4));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(4));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(4));
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && smode.Altitude && smode.Cadence)
                {
                    pbPedInd = Convert.ToInt32(data.ElementAt(4));
                }



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
