using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase agregada por OCP
    /// </summary>
    public abstract class AbstractShip
    {
        /// <summary>
        /// Cada barco tendrá su diccionario cuyas claves son las coordenadas donde se ubica cada parte del mismo
        /// </summary>
        private Dictionary<(int, int), bool> coordsDic;
        /// <summary>
        /// Constructor que recibe por parámetro el tamaño
        /// </summary>
        /// <param name="shipSize">Es un entero que da el tamaño del barco</param>
        protected AbstractShip(int shipSize)
        {
            this.coordsDic = new Dictionary<(int, int), bool>();

        }
        /// <summary>
        /// Permite obtener el diccionario para el barco
        /// </summary>
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
        /// Método de clase abstracta
        /// </summary>
        /// <returns></returns>
        public abstract bool IsShipSinked();
        /// <summary>
        /// Método de clase
        /// </summary>
        /// <returns></returns>
        public abstract int GetLength();
    }
}


