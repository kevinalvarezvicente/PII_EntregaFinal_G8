using System;

namespace PII_ENTREGAFINAL_G8.src.Library
{
    public class Administrator
    {
        private Administrator _administrator;
        Lobby lobby = new Lobby();

        public void JoinUsersToPlay(User user1, User user2)
        {
            Console.WriteLine($"Jugarán {user1.Name} contra {user2.Name}");
            Console.WriteLine($"{user1.Name} indique el tamaño del tablero");
            int boardLength = Console.Read();
            Game game = new Game(user1, user2, boardLength);
            lobby.RemoveUserFromList(user1);
            lobby.RemoveUserFromList(user2);
        }

        public void ReceiveUsersSearchingGameList()
        {
            if (lobby.AreUsersToStartGame())
            {
                JoinUsersToPlay(lobby.GetUsersSearchingForGameList()[0], lobby.GetUsersSearchingForGameList()[1]);
            }
        }

    }
}