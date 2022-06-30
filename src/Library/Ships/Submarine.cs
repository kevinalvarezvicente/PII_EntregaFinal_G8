namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es el tipo de barco mas grande. Opción numero 3
    /// Lo que se modifica es el tamaño del barco esté predeterminado según el tipo. 
    /// Es subclase de Ship, lo que significa que heredará todos los métodos y se puede agregar otros.
    /// SRP: único motivo de cambio es si se desea agrgarle otro parámetro o cambiar el tamaño.
    /// </summary>
    public class Submarine : Ship
    {
        /// <summary>
        /// Tiene tamaño 4
        /// </summary>
        /// <param name="coord">Cadena donde ubicar la primer coordenada del barco</param>
        /// <param name="direction">Direccion que desea si vertical u horizontal</param>
        /// <returns></returns>
        public Submarine(string coord, string direction) : base(4, coord, direction)
        {
        }

    }
}

