using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es el barco tamaño mediano
    /// Es una subclase o clase derivada de Ship ya que toma atributos y métodos de otra clase y 
    /// habitualmente se puede agregar nuevos atributos y nuevos métodos.
    /// Lo que se modifica es el tamaño del barco esté predeterminado según el tipo.
    /// Cumple SRP único motivo de cambio es si se desea agrgarle otro parámetro o cambiar el tamaño.
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

