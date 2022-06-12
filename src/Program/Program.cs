//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
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
            //inicializo el board
            Board board1  = new Board(4);

            //PRINT
            board1.imprimirTablero(board1);

            Player player1 = new Player();
             

            player1.ReceiveShot(2, 1);

            board1.imprimirTablero(board1);
            

        }
    }
}