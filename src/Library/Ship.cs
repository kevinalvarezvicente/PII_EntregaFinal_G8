using System.Collections.Generic;
using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// 
    /// </summary>
    public class Ship
    {
        //List<int[,]> coordList = new List<int[,]>();
        //private string [] ship;
        //List<Tuple<int, int>> _coords = new List<Tuple<int, int>>();
        Dictionary<(int,int), bool> coordsDic;

        public Ship(int shipSize, string coords, string direction)
        {
            this.coordsDic = new Dictionary<(int,int), bool>();
            
        }
        /// <summary>
        /// Este método agrega la clave tupla con una coordanda del barco en el Tablero con el valor false
        /// cuando se realice el disparo el valor de esta tupla sera true
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>

        public void AddCoord(int x, int y)
        {
            coordsDic.Add((x,y),false);
        }

        public Dictionary<(int,int), bool> CoordsDict
        {
            get
            {
                return this.coordsDic;
            }
            private set
            {
                this.coordsDic=value;
            }
        }
        /// <summary>
        /// Este método recorre todos los valores de las claves del barco.
        /// Si estan todos los valores en true entonces el barco esta hundido.
        /// </summary>
        /// <returns></returns>

        public bool IsShipSinked()
        {
            foreach (bool value in coordsDic.Values)
            {
                if (value is false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}


