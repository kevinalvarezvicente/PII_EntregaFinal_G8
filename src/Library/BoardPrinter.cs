using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase servira para imprimir los tableros
    /// </summary>
    public class BoardPrinter
    {
      /// <summary>
      /// Permite imprimir el tablero de tiros del jugador pasado por parámetro
      /// Es estático porque permite ser implementado sin crear el objeto BoardPrinter
      /// </summary>
      /// <param name="player">Jugador dueño del tablero que se desea imprimir por pantalla</param>
        public static void PrintPlayerShotBoard(Player player)
        {

            Console.WriteLine($"Se imprime el tablero de tiros de {player.GetPlayerName()}");
            
            for (int i = 0; i < player.GetPlayerShotBoard().GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < player.GetPlayerShotBoard().GameBoard.GetLength(1); j++)
                    {
                    Console.Write(player.GetPlayerShotBoard().GameBoard[i,j]+" ");
                    }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Permite imprimir el tablero de barcos del jugador pasado por parámetro
        /// Es estático porque permite ser implementado sin crear el objeto BoardPrinter
        /// </summary>
        /// <param name="player">Jugador dueño del tablero que deseo imprimir por pantalla</param>
        public static void PrintPlayerShipBoard(Player player)
        {
            Console.WriteLine($"Se imprime el tablero de barcos de {player.GetPlayerName()}");
            for (int i = 0; i < player.GetPlayerShipBoard().GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < player.GetPlayerShipBoard().GameBoard.GetLength(1); j++)
                {
                Console.Write(player.GetPlayerShipBoard().GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }
        }

    }
}
