namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase para el tablero de tiros del jugador
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
