//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using ChatBot_Logic.src;
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
            //ChatBot bot = ChatBot.Instance;

            User matias = new User("Matias","Olave");
            Player player = new Player(matias,10);
            Submarine submarine = new Submarine("11","v");
            player.PlaceShipOnBoard(submarine);
            //Se agrega el submarino en las coordenadas 
            player.ReceiveShot("11");
            player.ReceiveShot("21");
            player.ReceiveShot("31");
            player.ReceiveShot("41");
            bool expected = submarine.IsShipSinked();
            Console.WriteLine(expected);
        }
    }
}
