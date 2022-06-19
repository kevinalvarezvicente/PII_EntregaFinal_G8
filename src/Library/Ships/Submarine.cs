using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es el tipo de barco mas grande. Opción numero 3
    /// </summary>
    public class Submarine: AbstractShip
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
            }
            else if (direction.ToUpper()=="V")
            {
                CoordsDict.Add((x,y),false);
                CoordsDict.Add((x+1,y),false);
                CoordsDict.Add((x+3,y),false);
                CoordsDict.Add((x+4,y),false);
            }
        }
        /// <summary>
        /// Permite acceder al tamaño del barco
        /// </summary>
        /// <returns>Devuelve un entero</returns>
        public override int GetLength()
        {
            return 4;
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

