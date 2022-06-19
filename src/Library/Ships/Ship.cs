using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase base de barcos pues es la clase a partir de la cual se hereda
    /// Permite que si el día de mañana se desea agregar otro tamaño de barco se pueda sin problema, sin necesidad de modificar tanto el código.
    /// </summary>
    public class Ship
    {
        private (int x,int y) vulnerableCoord;
        /// <summary>
        /// Cada barco tendrá su diccionario cuyas claves son las coordenadas donde se ubica cada parte del mismo
        /// </summary>
        private Dictionary<(int, int), bool> coordsDic;
        /// <summary>
        /// Cada barco tiene un tamaño especifico de cada uno que es la cantidad de clave-valor que tiene dicho barco
        /// </summary>
        private int shipSize;
        /// <summary>
        /// Constructor que recibe por parámetro el tamaño
        /// </summary>
        /// <param name="shipSize">Es un entero que da el tamaño del barco</param>
        public Ship(int shipSize)
        {
            this.coordsDic = new Dictionary<(int, int), bool>();
            this.shipSize=shipSize;
            this.vulnerableCoord=(0,0);

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
        /// Permite obtener el largo del diccionario
        /// </summary>
        /// <value></value>
        public int ShipSize
        {
            get
            {
                return this.shipSize;
            }
        }
        /// <summary>
        /// Este método recorre todos los valores de las claves del barco.
        /// Si estan todos los valores en true entonces el barco esta hundido.
        /// Método que será heredado las subclases de Ship, o sea a las clases que heredan de ship.
        /// </summary>
        /// <returns></returns>
        public bool IsShipSinked()
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
        /// <summary>
        /// Se crea una coordenada vulnerable, si se dispara ahí, el barco se hundirá completamente
        /// </summary>
        /// <value></value>
        public (int x, int y) VulnerableCoord
        {
            get
            {
                return this.vulnerableCoord;
            }
            set
            {
                this.vulnerableCoord=value;
            }
        }
        /// <summary>
        /// Método que chequea si la coordenada donde se disparo fue la vulnerable
        /// </summary>
        /// <param name="coord">Es de tipo string que liuego se dividira en (x,y) </param>
        public void ShotInVulnerableCoord(string coord)
        {
            (int x,int y)=Utils.SplitCoordIntoRowAndColumn(coord);
            if (this.vulnerableCoord==(x,y))
            {
                foreach ((int x, int y) key in CoordsDict.Keys)
                {
                    CoordsDict[(x,y)]=true;
                }
            }
        }
    }
}


