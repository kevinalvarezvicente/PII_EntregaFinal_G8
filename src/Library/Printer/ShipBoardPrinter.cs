using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Clase que implementa la interfaz IPrinter. 
    /// El único método que necesita también debe poder ser utilizado para imprimir un tablero de disparos.
    /// Tiene la responsabilidad de imprimir el tablero del jugador con barcos
    /// Se cumple SRP (Single Responsibility Principle)
    /// </summary>
    public class ShipBoardPrinter: IPrinter
    {
        /// <summary>
      /// Permite imprimir el tablero de tiros del jugador pasado por parámetro.
      /// Es una operación polimórfica ya que  cada clase de tipo IPrinter tiene la responsabilidad de imprimir el tablero con una forma diferente
      /// </summary>
      /// <param name="player">Jugador dueño del tablero que se desea imprimir por pantalla</param>
        public void PrintPlayerBoard(Player player)
        {
            Console.WriteLine($"Se imprime el tablero de barcos de {player.PlayerName}");
            for (int i = 0; i < player.PlayerShipBoard.GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < player.PlayerShipBoard.GameBoard.GetLength(1); j++)
                {
                Console.Write(player.PlayerShipBoard.GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }
        }
    }
}








