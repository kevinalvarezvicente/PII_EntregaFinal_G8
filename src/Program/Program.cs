//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using ChatBot_Logic.src;
using PII_ENTREGAFINAL_G8.src.Library;
using System;
using System.Collections.Generic;

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
            User carol = new User("Carol","Glass");
            Player player = new Player(carol,10);
            User maria = new User("Maria","P");
            carol.WantToPlay();
            maria.WantToPlay();
            Console.WriteLine(LobbyContainer.lobbyContainer.Count);
            
           
            //ShipBoardPrinter printer = new ShipBoardPrinter();
            //printer.PrintPlayerBoard(player.PlayerShipBoard);

        }
    }
}
