﻿namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es el barco mas pequeño, hereda de Ship
    /// Es una subclase de Ship ya que  atributos y métodos de otra clase y 
    /// habitualmente se puede agregar nuevos atributos y nuevos métodos.
    /// Lo que se modifica es el tamaño del barco esté predeterminado según el tipo. 
    /// SRP: único motivo de cambio es si se desea agrgarle otro parámetro o cambiar el tamaño.
    /// /// </summary>
    public class AircraftCarrier : Ship
    {
        /// <summary>
        /// Tiene tamaño 57
        /// </summary>
        /// <param name="coord">Es la coordenada inicial y a partir de esta ya se guardan las siguientes como claves</param>
        /// <param name="direction">El usuario puede elegir si lo quiere ubicar vertical u horizontal</param>
        /// <returns></returns>
        public AircraftCarrier(string coord, string direction) : base(5, coord, direction)
        {
        }
    }
}
