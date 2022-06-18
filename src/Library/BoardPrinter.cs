using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class BoardPrinter
    {
      
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
