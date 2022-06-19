using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es un tipo de barco
    /// </summary>
    public class LightCruiser: AbstractShip
    {
        /// <summary>
        /// Tiene tamaño 3 es la opción numero 2
        /// </summary>
        /// <param name="coord">Es una cadena</param>
        /// <param name="direction">Indica si el jugador quiere poner barcos horizontal o vertical</param>
        /// <returns></returns>
        public LightCruiser(string coord, string direction):base(3)
        {
            (int x, int y)=Utils.SplitCoordIntoRowAndColumn(coord);
            if (direction.ToUpper()=="H")
            {
                CoordsDict.Add((x,y),false);
                CoordsDict.Add((x,y+1),false);
                CoordsDict.Add((x,y+2),false);
            }
            else if (direction.ToUpper()=="V")
            {
                CoordsDict.Add((x,y),false);
                CoordsDict.Add((x+1,y),false);
                CoordsDict.Add((x+2,y),false);
            }
        }
        /// <summary>
        /// Permite acceder al largo del barco
        /// </summary>
        /// <returns>Retorna un entero</returns>
        public override int GetLength()
        {
            return 3;
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

