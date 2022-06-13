//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using PII_ENTREGAFINAL_G8.src.Library;
using System;

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

            Player player1 = new Player(2);

            player1.PlaceShip(2,1,1,"h");


            for (int i = 0; i < player1.PlayerShipBoard.GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < player1.PlayerShipBoard.GameBoard.GetLength(1); j++)
                {
                Console.Write(player1.PlayerShipBoard.GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }

            /*player1.ReceiveShot(1,1);

            for (int i = 0; i < player1.PlayerShipBoard.GameBoard.GetLength(0); i++)
            {
            for (int j = 0; j < player1.PlayerShipBoard.GameBoard.GetLength(1); j++)
                {
                Console.Write(player1.PlayerShipBoard.GameBoard[i,j]+" ");
                }
            Console.WriteLine();
            }*/

            
            
            

    }
}
}
