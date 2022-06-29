//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
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
            ChatBot bot = ChatBot.Instance;


            //No borrar esto, sirve para correr y que se guarde GameContainer en el JSON 
            /*User c = new User(10,"c","g");
            User x = new User(11,"x","Y");
            Game game1 = new Game(new Player(c,10),new Player(x,10));
            GamesContainer.AddGame(game1);
            User r = new User(12,"r","t");
            User t = new User(13, "t","r");
            Game game2= new Game(new Player(r,15),new Player(t,15));
            GamesContainer.AddGame(game2);
            GamesContainer.saveContainer();*/

        }
    }
}