//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Linq;
using PII_ENTREGAFINAL_G8.src.Library;

namespace PII_ENTREGAFINAL_G8.src.Program
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            /*Board board= new Board(10);
            int cant = board.MaxShipsQuantity;
            Console.WriteLine(cant);*/

            User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
            Game game1   = new Game(player1, player2, 10);
            game1.PlaceShip(1, "11", "V");
            

            //Singleton<Administrator>.Instance.AddUserToList(player1);
            //Singleton<Administrator>.Instance.AddUserToList(player2);
            //Console.WriteLine(Singleton<Lobby>.Instance.GetUsersSearchingGame().Count());

            //Console.WriteLine($"{player1.Name} indique el tamaño del tablero: ");
            //int boardLength = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("El tamaño de su tablero será " + boardLength);
            //Game game1 = new Game(player1, player2, 8);
            //game1.PlaceShip(1,"11","v");
            //player1.AddGameToGameHistory(game1);
            //int cant1=player1.GameHistory.Count;
            //Console.WriteLine(cant1);

            //Singleton<Administrator>.Instance.RegisterUser(5,"Carolina");

            //game1.PlaceShip(1,"00","h");
            //player1.WantToPlay();
            //int cant = Lobby.Instance.GetUsersSearchingGame().Count;
            //Console.WriteLine(cant);

            //game1.AskPlayerToPlaceShips();
            //game1.AskPlayerToPlaceShips();
            //Console.WriteLine("Debe indicar la coordenada a atacar");
            //string ShotCoord = Console.ReadLine();
            //game1.ShotMade(ShotCoord);
            /*int counter = 1;
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char [] lettersArray = letters.ToCharArray(); 

            string [,] gameBoard = new string [3+1,3+1];
            Console.WriteLine(lettersArray.Length);
        
            for (int i = 0; i < (Math.Sqrt(gameBoard.Length))+1; i++)
            {
                for (int j = 0; j < (Math.Sqrt(gameBoard.Length)+1); j++)
                {
                    if (i==0 && j==0)
                    {
                        gameBoard[0,0]=" ";
                    }
                    else if (i==0 && j!=0)
                    {
                        gameBoard[0,j]=lettersArray[j].ToString();
                    }
                    else if (j==0 && i!=0)
                    {
                        gameBoard[i,0]=counter.ToString();
                        counter ++;
                    }
                    else
                    {
                        gameBoard[i, j] = "-";
                    }
                }
            }

            for (int i = 0; i < Math.Sqrt(gameBoard.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(gameBoard.Length); j++)
                    {
                    Console.WriteLine(gameBoard[i,j]+" ");
                    }
               
            }*/



            /*Player player1 = new Player(6);

            player1.PlaceShip(3,1,1,"h");

            //Se prueba ubicar un barco

            for (int i = 0; i < player1.GetPlayerShipBoard().GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < player1.GetPlayerShipBoard().GameBoard.GetLength(1); j++)
                {
                Console.Write(player1.GetPlayerShipBoard().GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }

            //Se prueba hacer un disparo

            player1.ReceiveShot(1,1);

            for (int i = 0; i < player1.GetPlayerShotBoard().GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < player1.GetPlayerShotBoard().GameBoard.GetLength(1); j++)
                {
                Console.Write(player1.GetPlayerShotBoard().GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }*/


        }
    }
}
