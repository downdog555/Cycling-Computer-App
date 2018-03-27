﻿using System;
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
        private string pbPedInd;

        private string powerBalance;
        private string powerIndex;
        private double speed;
        private Smode smode;

        public HrDataSingle(List<string> data, int version, Smode smode ,int cadAlt = 46, string pbPed = null)
        {
            this.powerBalance = "";
            this.powerIndex = "";
            
            this.smode = smode;
            heartRate = cadence = altitude = power = airPressure  = 0;
            pbPedInd = "";
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
                    power = Convert.ToInt32(data.ElementAt(2));
                }
                else if (smode.Power && !smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(2));
                }
                else if (smode.Power && !smode.Speed && smode.Altitude && smode.Cadence)
                {
                    power = Convert.ToInt32(data.ElementAt(3));
                }



                if (smode.PowerLeftRightBalance && smode.Power && smode.Speed && smode.Altitude && smode.Cadence)
                {
                    try
                    {
                        pbPedInd = data.ElementAt(5);
                        GetPBIndex();
                    }
                    catch (Exception e)
                    {
                        smode.PowerLeftRightBalance = false;
                        smode.PowerPedallingIndex = false;
                    }
                    
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && !smode.Altitude && !smode.Cadence)
                {
                    pbPedInd = data.ElementAt(2);
                    GetPBIndex();
                }
                else if (smode.PowerLeftRightBalance && smode.Power && smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    pbPedInd = data.ElementAt(4);
                    GetPBIndex();
                }
                else if (smode.PowerLeftRightBalance && smode.Power && smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    pbPedInd = data.ElementAt(4);
                    GetPBIndex();
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    pbPedInd = data.ElementAt(4);
                    GetPBIndex();
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    pbPedInd = data.ElementAt(4);
                    GetPBIndex();
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && smode.Altitude && smode.Cadence)
                {
                    pbPedInd = data.ElementAt(4);
                    
                        GetPBIndex();
                   
                    
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
                    pbPedInd = data.ElementAt(5);
                    GetPBIndex();
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && !smode.Altitude && !smode.Cadence)
                {
                    pbPedInd = data.ElementAt(2);
                    GetPBIndex();
                }
                else if (smode.PowerLeftRightBalance && smode.Power && smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    pbPedInd =data.ElementAt(4);
                    GetPBIndex();
                }
                else if (smode.PowerLeftRightBalance && smode.Power && smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    pbPedInd = data.ElementAt(4);
                    GetPBIndex();
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && smode.Altitude && !smode.Cadence)
                {
                    pbPedInd = data.ElementAt(4);
                    GetPBIndex();
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && !smode.Altitude && smode.Cadence)
                {
                    pbPedInd = data.ElementAt(4);
                    GetPBIndex();
                }
                else if (smode.PowerLeftRightBalance && smode.Power && !smode.Speed && smode.Altitude && smode.Cadence)
                {
                    pbPedInd = data.ElementAt(4);
                    GetPBIndex();
                }



                airPressure = Convert.ToInt32(data.ElementAt(6));

                
            }
        }

        private void GetPBIndex()
        {
            string binary = "";
            //we dont know the length of the bits as it is not constant
            //so convert the number as it is an integer, then get a string with the bit representation
            //split that into two halves to give the value
            int temp = Convert.ToInt32(pbPedInd);
            string tempBits = Convert.ToString(temp,2);
           
            //Console.WriteLine(Convert.ToString(temp, 2));
            int half = tempBits.Length / 2;
           // var m = pbPedInd.Substring(0, half);
            //var n = pbPedInd.Substring(half);
            int first = Convert.ToInt32(tempBits.Substring(0,half),2);
            int second = Convert.ToInt32(tempBits.Substring(half),2);
           
           
            
           
            
            
           

            powerBalance = Convert.ToString(first);
            powerIndex = Convert.ToString(second);
            
        }

        public int HeartRate { get { return heartRate; } set { heartRate = value; } }
        public int Cadence { get { return cadence; } }
        public int Altitude { get { return altitude; } }
        public int Power { get { return power; } set { power = value; } }
        public int AirPressure { get { return airPressure; } }
        public string PbPedInd { get { return pbPedInd; } }
        public double Speed { get { return speed; } }
        public string PB { get { return powerBalance; } }
        public string PI { get { return powerIndex; } }
    }
}
