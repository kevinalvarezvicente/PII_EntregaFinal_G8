using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// 
    /// </summary>
    public class LightCruiser: AbstractShip
    {
        public LightCruiser(string coord, string direction):base(4)
        {
            (int x, int y)=Utils.SplitCoordIntoRowAndColumn(coord);
            if (direction.ToUpper()=="H")
            {
                CoordsDict.Add((x,y),false);
                CoordsDict.Add((x,y+1),false);
                CoordsDict.Add((x,y+2),false);
                CoordsDict.Add((x,y+3),false);
            }
            else if (direction.ToUpper()=="V")
            {
                CoordsDict.Add((x,y),false);
                CoordsDict.Add((x+1,y),false);
                CoordsDict.Add((x+2,y),false);
                CoordsDict.Add((x+3,y),false);
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

