using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// 
    /// </summary>
    public class Frigate: AbstractShip
    {
        private Dictionary<(int, int), bool> coordsDic;

        public Frigate(string coord, string direction):base(2)
        {
            this.coordsDic = new Dictionary<(int, int), bool>();
            (int x, int y)=Utils.SplitCoordIntoRowAndColumn(coord);
            if (direction.ToUpper()=="H")
            {
                this.coordsDic.Add((x,y),false);
                this.coordsDic.Add((x,y+1),false);
            }
            else if (direction.ToUpper()=="V")
            {
                this.coordsDic.Add((x,y),false);
                this.coordsDic.Add((x+1,y),false);
            }
        }
        public override int GetLength()
        {
            return 2;
        }
        public Dictionary<(int, int), bool> CoordsDict
        {
            get
            {
                return this.coordsDic;
            }
            private set
            {
                this.coordsDic = value;
            }
        }

        /// <summary>
        /// Este método recorre todos los valores de las claves del barco.
        /// Si estan todos los valores en true entonces el barco esta hundido.
        /// </summary>
        /// <returns></returns>
        public override bool IsShipSinked()
        {
            foreach (bool value in CoordsDict.Values)
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

