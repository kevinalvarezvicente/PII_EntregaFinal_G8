using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase servira para imprimir los tableros. 
    /// Cumple con SRP ya que su única responsabilidad es imprimir el tablero de tiros.
    /// Sus métodos son estáticos por lo que se pueden usuar los métodos de clase sin instanciar el objeto BoardPrinter.
    /// </summary>
    public class BoardPrinter
    {
      /// <summary>
      /// Permite imprimir el tablero de tiros del jugador pasado por parámetro
      /// Es estático porque permite ser implementado sin crear el objeto BoardPrinter
      /// No es una operación polimórfica ya que solo sirve para imprimir el tablero de tiros
      /// </summary>
      /// <param name="player">Jugador dueño del tablero que se desea imprimir por pantalla</param>
        public static void PrintPlayerShotBoard(Player player)
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
        /// <summary>
        /// Permite imprimir el tablero de barcos del jugador pasado por parámetro
        /// Es estático porque permite ser implementado sin crear el objeto BoardPrinter
        /// No es una operación polimórfica ya que solo sirve para imprimir el tablero de barcos. 
        /// Para que sea polomórifca se podría pasar por parámetro el tablero.
        /// </summary>
        /// <param name="player">Jugador dueño del tablero que deseo imprimir por pantalla</param>
        public static void PrintPlayerShipBoard(Player player)
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
