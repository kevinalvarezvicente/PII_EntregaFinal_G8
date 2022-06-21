using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase base de barcos pues es la clase a partir de la cual heredan los 3 tipos de barcos.
    /// Permite que si el día de mañana se desea agregar otro tamaño de barco se pueda sin problema, sin necesidad de modificar tanto el código.
    /// Cumple LSP (Liskov Substitution Principle): 
    /// - Al tener 3 objetos de tipos diferentes que derivan de la clase base Ship en las operaciones que requiera tipo Ship
    /// se puede reemplazar por cada uno de los objetos de sus subclases (Submarine, LightCruiser, Frigate) sin interrumpir la aplicación.
    /// - No se romperá ya que los objetos de las subclases se comportan de la misma manera que los objetos de la superclase Ship.
    /// Cumple (LCHC) Low Coupling and High Cohesion
    /// - Hace lo mínimo necesario como almacenar la información del barco y delega todo lo demás 
    /// - Es altamente cohesiva porque lo poco que hace está sumamente relacionado, pero tiene muchas relaciones con otras clases, con lo cual va a estar muy acoplada.
    /// Cumple patron Expert
    /// - La responsabilidades mencionadas e implementaciones de métodos recaen sobre ella ya que ésta conoce toda la situacion del barco.
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Cada barco tiene su coordenada de vulnerabilidad.
        /// </summary>
        private (int x,int y) vulnerableCoord;
        /// <summary>
        /// 
        /// </summary>
        private List <Spot> coordsList;
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
            this.coordsList = new List<Spot>();
            this.shipSize=shipSize;
            (int x, int y)=Utils.SplitCoordIntoRowAndColumn(coord);
            this.vulnerableCoord=(x,y);
            for (int i=0; i<shipSize; i++)
            {
                if (direction.ToUpper()=="H")
                {
                    CoordsList.Add(new Spot (x,y+i));
                    
                }
                else if (direction.ToUpper()=="V")
                {
                    CoordsList.Add(new Spot (x+i,y));
                }
            }
        }
        /// <summary>
        /// Permite obtener las coordenadas para el barco
        /// </summary>
        public List <Spot> CoordsList
        {
            get
            {
                return this.coordsList;
            }
            private set
            {
                this.coordsList = value;
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
        /// Este método se fija en los atributos washIT de las coordenadas del barco.
        /// Si estan todos con true entonces el barco esta hundido.
        /// Método que será heredado las subclases de Ship, o sea a las clases que heredan de ship.
        /// </summary>
        /// <returns></returns>
        public bool IsShipSinked()
        {
            foreach (Spot spot in CoordsList)
            {
                if (spot.wasHit is false)
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
                foreach (Spot spot in CoordsList)
                {
                    spot.wasHit=true;
                }
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


