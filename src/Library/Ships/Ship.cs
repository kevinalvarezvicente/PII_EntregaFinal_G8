using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase base de barcos pues es la clase a partir de la cual se hereda
    /// Permite que si el día de mañana se desea agregar otro tamaño de barco se pueda sin problema, sin necesidad de modificar tanto el código.
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Cada barco tiene su coordenada de vulnerabilidad.
        /// </summary>
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
        /// <param name="coord">Es una cadena donde comienza la primer posición del barco</param>
        /// <param name="direction">Es una cadena la dirección del barco, vertical u horizontal</param>
        protected Ship(int shipSize, string coord, string direction)
        {
            if (direction.ToUpper()!="V" && direction.ToUpper()!="H")
            {
                throw new OptionException("Las opciones para la direccion del barco son V(vertical) o H(Horizontal");
            }
            this.coordsDic = new Dictionary<(int, int), bool>();
            this.shipSize=shipSize;
            (int x, int y)=Utils.SplitCoordIntoRowAndColumn(coord);
            this.vulnerableCoord=(x,y);
            for (int i=0; i<shipSize; i++)
            {
                if (direction.ToUpper()=="H")
                {
                    CoordsDict.Add((x,y+i),false);
                    
                }
                else if (direction.ToUpper()=="V")
                {
                    CoordsDict.Add((x+i,y),false);
                }
            }
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
        protected bool IsShipSinked()
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
        /// <summary>
        /// Método booleano que instancia al método.
        /// </summary>
        /// <value></value>
        public bool IsSinked
        {
            get
            {
                return IsShipSinked();
            }
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

    }
}


