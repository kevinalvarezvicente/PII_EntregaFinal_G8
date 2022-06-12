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
            //inicializo el board
            
            Player player = new Player();
            Board board1  = new Board(4);
            board1.PlaceShip(3,1,1,"v");


            board1.imprimirTablero(board1);
            
            
            board1.ReceiveShot(1, 1);
            board1.ReceiveShot(0, 1);
            board1.ReceiveShot(2, 1);
            board1.imprimirTablero(board1);



            //boardPlayer.imprimirTablero(player1.gameBoard);
            

        }
    }
}