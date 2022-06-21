using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    ///  Clase que implementa la interfaz IPrinter. 
    /// El único método que utili también debe poder ser utilizado para imprimir un tablero de disparos
    /// Tiene la responsabilidad de imprimir el tablero del jugador con los disparos realizados
    /// Se cumple SRP (Single Responsibility Principle)
    /// </summary>
    public class ShotBoardPrinter: IPrinter
    {
        /// <summary>
      /// Permite imprimir el tablero de tiros del jugador pasado por parámetro.
      /// No es una operación polimórfica ya que solo sirve para imprimir el tablero de tiros.
      /// </summary>
      /// <param name="player">Jugador dueño del tablero que se desea imprimir por pantalla</param>
        public void PrintPlayerBoard(Player player)
        {

            Console.WriteLine($"Se imprime el tablero de tiros de {player.PlayerName}");
            
            for (int i = 0; i < player.PlayerShotBoard.GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < player.PlayerShotBoard.GameBoard.GetLength(1); j++)
                    {
                    Console.Write(player.PlayerShotBoard.GameBoard[i,j]+" ");
                    }
                Console.WriteLine();
            }
        }
    }
}