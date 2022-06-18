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
            User player1 = new User(1, "Carol");
            User player2 = new User(2, "Tony");
            Console.WriteLine($"{player1.Name} indique el tamaño del tablero: ");
            int boardLength = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("El tamaño de su tablero será " + boardLength);
            Game game1 = new Game(player1, player2, boardLength+1);
            
            //game1.AskPlayerToPlaceShips();
            //game1.AskPlayerToPlaceShips();
            /*Console.WriteLine("Debe indicar la coordenada a atacar");
            string ShotCoord = Console.ReadLine();
            game1.ShotMade(ShotCoord);*/


    }
}
}
