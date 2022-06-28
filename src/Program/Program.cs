//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using ChatBot_Logic.src;
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
            //ChatBot bot = ChatBot.Instance;

            User matias = new User(3,"Olave", "Matias");
            Player player = new Player(matias);
            Board board1 = new ShipBoard(10);
            Board board2 = new ShotBoard(10);
            
            BoardPrinter printer = new BoardPrinter();
            printer.PrintPlayerBoard(player.GetPlayerShipBoard());


        }
    }
}