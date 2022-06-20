namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase para las coordenadas que ocupan los barcos en el tablero
    /// Es experta en información sobre el estado de las coordenadas de los barcos
    /// Cumple SRP ya que tiene una única responsabilidad de crear las coordenadas de los barcos
    /// </summary>
    public class Spot
    {
        /// <summary>
        /// X Es la coordenada en la fila del tablero
        /// </summary>
        /// <value>Es un entero</value>
        public int X {get;}
        /// <summary>
        /// Y es la coordenada en la columna del tablero
        /// </summary>
        /// <value>Retorna un entero</value>
        public int Y {get;}
        /// <summary>
        /// Es una propiedad del Spot (coordenada) para decir si ya dispararon a esa coordenada del barco o no
        /// </summary>
        /// <value>Retorna un booleano siendo true si le dispararon y siendo false sino</value>
        public bool wasHit{get; set;}
        /// <summary>
        /// Método constructor de la posición
        /// </summary>
        /// <param name="x">Posicion en la fila en el tablero</param>
        /// <param name="y">Posicion según la columna del tablero</param>
        public Spot(int x, int y)
        {
            this.X=x;
            this.Y=y;
            this.wasHit=false;
        }
    }
}