using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es el barco tamaño mediano
    /// Es una subclase de Ship ya que  atributos y métodos de otra clase y 
    /// habitualmente se puede agregar nuevos atributos y nuevos métodos 
    /// </summary>
    public class LightCruiser: Ship
    {
        /// <summary>
        /// Tiene tamaño 3 es la opción numero 2
        /// </summary>
        /// <param name="coord">Es una cadena</param>
        /// <param name="direction">Indica si el jugador quiere poner barcos horizontal o vertical</param>
        /// <returns></returns>
        public LightCruiser(string coord, string direction):base(3, coord, direction)
        {   
        }
    }
}

