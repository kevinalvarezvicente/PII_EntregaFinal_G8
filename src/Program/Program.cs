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
            //hatBot bot = ChatBot.Instance;

            User user = new User(12, "Carol", "Glass");
            Board Shipboard1 = new ShipBoard(4);
            Board Shotboard1 = new ShotBoard(4);
            Player player = new Player(user);
            player.AddPlayerBoard(Shipboard1);
            player.AddPlayerBoard(Shotboard1);

            BoardPrinter printer = new BoardPrinter();
            Board board = player.GetPlayerShipBoard();
            printer.PrintPlayerBoard(board);
        }
    }
}