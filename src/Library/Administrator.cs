using System;
using System.Collections.Generic;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    /// <summary>
    /// Esta clase cumple el rol de administrador.
    /// Es Expert.
    /// Es un singleton ya que solo existirá un administrador y se lo puede llamar desde distintas clases.
    /// Cumple Creator ya que tiene responsabilidad de crear instancias de:
    /// - Game: cuando une a dos jugadores que quieren jugar.
    /// - User: Para registrar el usuario y agregalo al UserContainer
    /// Cumple (LCHC) Low Coupling and High Cohesion
    /// Hace lo mínimo necesario como para realizar tareas de administrador
    /// Es altamente cohesiva porque lo poco que hace está sumamente relacionado, pero tiene muchas relaciones con otras clases, con lo cual va a estar muy acoplada.
    /// </summary>
    public class Administrator
    {
        Singleton<Administrator> _administrator;
        /// <summary>
        /// El método JoinUsersToPlay permite unir a dos Usuarios que esten esperando para jugar e inicia una partida Game
        /// Como ya ambos usuarios comenzaron a jugar y se transformaron en jugadores los quita del lobby de espera
        /// Recibe como argumento todos los datos necesarios para crear instancia de Game
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
            lobby.RemoveUserFromList(user1);
            lobby.RemoveUserFromList(user2);
        }

        public void ReceiveUsersSearchingGameList()
        {
            if (Singleton<LobbyContainer>.Instance.AreUsersToStartGame())
            {
                JoinUsersToPlay(Singleton<LobbyContainer>.Instance.ContainerList[0], Singleton<LobbyContainer>.Instance.ContainerList[1]);
            }
        }
        /// <summary>
        /// Finaliza la partida si es indicado
        /// Hace que la clase use Game
        /// </summary>
        /// <param name="game">Recibe como parámetro la partida</param>

        public void EndGame(Game game)
        {
            if (game.GameFinished())
            {
                Console.Write("La partida ha finalizado");
            }
            else
            {
                throw new GameNotFinishedException("El juego aún no finaliza");
            }
        }
        /// <summary>
        /// Registra el usuario
        /// Hace que la clase use User
        /// Recibe como argumento todos los datos necesarios para crear instancias de User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void RegisterUser(int id, string name)
        {
            User user = new User(id,name);
            Singleton<UserContainer>.Instance.AddItem(user);
        }
        /// <summary>
        /// Método que guarda la partida del usuario en el Container
        /// </summary>
        /// <param name="game">Recibe como argumento un Game</param>
        /// <param name="user">Recibe como argumento un User</param>
        public void AddGameToUserGamesContainer(Game game, User user)
        {
            user.Container.AddItem(game);
        }
    }
}