namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Interfaz que depende de Board. 
    /// Para poder imprimir un tablero cualquiera por pantalla tiene que conocer los detalles del Board. 
    /// Cada clase de tipo IPrinter tiene la responsabilidad de imprimir el tablero con un diseño diferente.
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// En este método se refleja que la interfaz depende de Board
        /// La declaración de la operación recibe una instancia de Board como parámetro 
        /// Es operación polimórifca ya que va a poder ser utilizada en el program de la misma 
        /// </summary>
        /// <param name="board"> Es un supertipo </param>
        string PrintPlayerBoard(Board board);
    }
}
