using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es el barco mas pequeño
    /// </summary>
    public class Frigate: AbstractShip
    {
        /// <summary>
        /// Tiene tamaño 2
        /// </summary>
        /// <param name="coord">Es la coordenada inicial y a partir de esta ya se guardan las siguientes como claves</param>
        /// <param name="direction">El usuario puede elegir si lo quiere ubicar vertical u horizontal</param>
        /// <returns></returns>
        public Frigate(string coord, string direction):base(2)
        {
            (int x, int y)=Utils.SplitCoordIntoRowAndColumn(coord);
            if (direction.ToUpper()=="H")
            {
                CoordsDict.Add((x,y),false);
                CoordsDict.Add((x,y+1),false);
            }
            else if (direction.ToUpper()=="V")
            {
                CoordsDict.Add((x,y),false);
                CoordsDict.Add((x+1,y),false);
            }
        }
        /// <summary>
        /// Permite acceder al largo del barco
        /// </summary>
        /// <returns>Retorna un entero</returns>
        public override int GetLength()
        {
            return 2;
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

