namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Es el tablero de barcos. Es subclase de Board. 
    /// Cumple SRP pues el único motivo de cambio sería si se quiere permitir que el usuario elija un tablero mayor que 12
    /// </summary>
    public class ShotBoard : Board
    {

        /// <summary>
        /// El tablero de tiros se inicializa
        /// </summary>
        /// <param name="x">Es el tamaño del tablero</param>
        /// <returns></returns>    
        public ShotBoard(int x):base(x) 
        {
            this.InitializeBoard(x);
            this.what="ShotBoard";
        }



    }
}
