using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase cumple el rol de administrador al unir dos usuarios esperando para jugar
    /// </summary>
    public class Administrator
    {
        /// <summary>
        /// Se crea una instancia de clase
        /// </summary>
        private Administrator _administrator;
        /// <summary>
        /// Se crea Lobby donde los usuarios aguardan para comenzar a jugar, el cual será Singleton
        /// </summary>
        /// <returns></returns>
        Lobby lobby = new Lobby();
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
            lobby.RemoveUserFromList(user1);
            lobby.RemoveUserFromList(user2);
        }
        /// <summary>
        /// Este método une a los usuarios usando JoinUsersToPlay
        /// toma los dos primeros usuarios en el lobby una vez que se comprueba que hay mas de un usuario esperando por una partida
        /// </summary>
        public void ReceiveUsersSearchingGameList()
        {
            if (lobby.AreUsersToStartGame())
            {
                JoinUsersToPlay(lobby.GetUsersSearchingForGameList()[0], lobby.GetUsersSearchingForGameList()[1]);
            }
        }

    }
}