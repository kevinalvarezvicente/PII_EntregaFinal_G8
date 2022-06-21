namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// CLASE SIN FUNCIONAR AUN
    /// Interfaz que depende de la clase Player. 
    /// Para poder imprimir un tablero cualquiera por pantalla tiene que conocer los detalles del jugador. 
    /// Cada clase de tipo IPrinter tiene la responsabilidad de imprimir el tablero con un diseño diferente.
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// En este método se refleja que la interfaz depende de Player 
        /// La declaración de la operación recibe una instancia de Player como parámetro y para que cumpla patrones se pondrá también el tablero como parámetro.
        /// Es operación polimórifca ya que va a poder ser utilizada en el program de la misma forma pero habiendo 
        /// </summary>
        /// <param name="player"></param>
       void PrintPlayerBoard(Player player);
    }
}
