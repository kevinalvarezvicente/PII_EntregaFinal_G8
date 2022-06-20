using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase cumple el rol de administrador.
    /// Es un singleton ya que solo existirá un administrador y se lo puede llamar desde distintas clases
    /// </summary>
    public class Administrator
    {
        /// <summary>
        /// Crea un diccionario cuya clave es el id y el valor es el nombre
        /// </summary>
        
        private Dictionary<int,string> allUsers = new Dictionary<int, string>();

        /// <summary>
        /// El método JoinUsersToPlay permite unir a dos Usuarios que esten esperando para jugar e inicia una partida Game
        /// Como ya ambos usuarios comenzaron a jugar y se transformaron en jugadores los quita del lobby de espera
        /// </summary>
        /// <param name="user1">Usuario que comenzará el juego</param>
        /// <param name="user2">Uusario contrario</param>
        public void JoinUsersToPlay(User user1, User user2)
        {
            Console.WriteLine($"Jugarán {user1.Name} contra {user2.Name}");
            Console.WriteLine($"{user1.Name} indique el tamaño del tablero");
            int boardLength = Console.Read();
            Game game = new Game(user1, user2, boardLength);
            Singleton<LobbyContainer>.Instance.RemoveItem(user1);
            Singleton<LobbyContainer>.Instance.RemoveItem(user2);
        }
        /// <summary>
        /// Este método une a los usuarios usando JoinUsersToPlay
        /// toma los dos primeros usuarios en el lobby una vez que se comprueba que hay mas de un usuario esperando por una partida
        /// </summary>
        public void StartGame()
        {
            if (Singleton<LobbyContainer>.Instance.AreUsersToStartGame())
            {
                JoinUsersToPlay(Singleton<LobbyContainer>.Instance.ContainerList[0], Singleton<LobbyContainer>.Instance.ContainerList[1]);
            }
        }

        public void EndGame(Game game)
        {
            if (game.GameFinished())
            {
                Console.Write("La partida ha finalizado");
            }
        }

        public void RegisterUser(int id, string name)
        {
            User user = new User(id,name);
            Singleton<UserContainer>.Instance.AddItem(user);
        }


    }
}