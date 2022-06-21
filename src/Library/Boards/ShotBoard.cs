namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es el tablero de barcos. Es subclase de Board. Hereda los métodos de Board menos el constructor
    /// </summary>
    public class ShotBoard : Board
    {
        /// <summary>
        /// El tablero de tiros se inicializa
        /// </summary>
        /// <param name="x">Es el tamaño del tablero</param>
        /// <returns></returns>    
        public ShotBoard(int x) : base(x)
        {
            this.InitializeBoard(x);
        }
    }
}
