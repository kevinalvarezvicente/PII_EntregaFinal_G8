using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es el tipo de barco mas grande. Opción numero 3
    /// </summary>
    public class Submarine: Ship
    {
        /// <summary>
        /// Tiene tamaño 4
        /// </summary>
        /// <param name="coord">Cadena donde ubicar la primer coordenada del barco</param>
        /// <param name="direction">Direccion que desea si vertical u horizontal</param>
        /// <returns></returns>
        public Submarine(string coord, string direction):base(4)
        {
            (int x, int y)=Utils.SplitCoordIntoRowAndColumn(coord);
            if (direction.ToUpper()=="H")
            {
                CoordsDict.Add((x,y),false);
                CoordsDict.Add((x,y+1),false);
                CoordsDict.Add((x,y+2),false);
                CoordsDict.Add((x,y+3),false);
                this.VulnerableCoord=(x,y+2);
            }
            else if (direction.ToUpper()=="V")
            {
                CoordsDict.Add((x,y),false);
                CoordsDict.Add((x+1,y),false);
                CoordsDict.Add((x+3,y),false);
                CoordsDict.Add((x+4,y),false);
                this.VulnerableCoord=(x+2,y);
            }
        }

    }
}

