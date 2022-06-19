using System.Collections.Generic;
using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Ship
    {
        List<int[,]> coordList = new List<int[,]>();
        private string [] ship;

        public Ship(int length)
        { 

            this.ship = new string[length];
            for (int i = 0; i < ship.GetLength(0); i++)
            {
                    ship[i] = "o";     
            }
            
        }

        public string [] GetShip()
        {
            return this.ship;
        }

        public bool IsShipSinked()
        {
            if (Array.TrueForAll(ship,element => element.StartsWith("x")))
            {
                return true;
            }
            return false;
        }
    }
}


