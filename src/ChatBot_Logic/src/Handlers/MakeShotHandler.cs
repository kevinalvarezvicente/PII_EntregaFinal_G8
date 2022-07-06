using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class MakeShotHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MakeShotHandler"/>. Esta clase procesa el mensaje "/atacarEnemigo".
        /// </summary>
        /// <param name="next">Es el siguiente Handler</param>
        public MakeShotHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new List<string>();
            Keywords.Add("/atacarEnemigo");
        }
        /// <summary>
        /// Procesa el mensaje "/atacarEnemigo"
        /// El primer jugador en indicar /atacarEnemigo es quien comenzará atacando
        /// </summary>
        /// <param name="message">Mensaje que recibe</param>
        /// <param name="response">Respuesta del bot</param>
        /// <returns>retorna un booleano de que será true si trabaja como corresponde</returns>

        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {

            ChainData chainData = ChainData.Instance;
            string from = message.From.Id.ToString();

            if (this.CanHandle(message))
            {
                if (chainData.userPostionHandler[from].Count > 0)
                {
                    if (!chainData.userPostionHandler[from][0].Equals("/atacarEnemigo"))
                    {
                        chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                    }
                }

                Game game = GamesContainer.VerifyUserOnGame(message.From.Id);
                if (game.Active_Player == null)
                {
                    for (int i = 0; i < game.PlayersList.Count; i++)
                    {
                        if (game.PlayersList[i].UserId == message.From.Id)
                        {
                            game.Active_Player = game.PlayersList[i];
                        }
                        if (game.PlayersList[i].UserId != message.From.Id)
                        {
                            game.Inactive_Player = game.PlayersList[i];
                        }
                    }
                }
                if (message.From.Id == game.Active_Player.UserId)
                {

                    Player player1 = game.Active_Player;
                    Player enemy = game.Inactive_Player;

                    if (chainData.userPostionHandler[from].Count == 0)
                    {
                        chainData.userPostionHandler[from].Add("/atacarEnemigo"); //Añadimos el nuevo handler que se esta ejecutando.
                        response = $"Es hora de que realizes tu ataque a tu enemigo {enemy.PlayerName}, escribe la coordenada.";
                        this.Keywords.Add(from); // Captamos el segundo mensaje que sea enviado luego de esta response, añadiendo el id del Usuario a las Keywords
                        return true;
                    }
                    if (chainData.userPostionHandler[from].Count == 1)
                    {
                        chainData.userPostionHandler[from].Add("/tiro");
                        string letter = message.Text.Substring(0, 1).ToUpper();
                        string number1 = Utils.LetterToNumber(letter);
                        string number2 = message.Text.Substring(1, message.Text.Length - 1);
                        string build = number1 + number2;
                        bool win = false;

                        string res = game.ShotMade(build);
                        if (res == "Nuestros satelites 🛰 nos indican que tu misil ha dado en el blanco, el enemigo esta en apuros.\n Es el turno de tu enemigo 😨.")
                        {
                            ChatBot.sendMessage(enemy.UserId, $"El enemigo te ha atacado.");
                        }
                        else if (res == "Capitán, se le informa que ha hundido el barco enemigo 😎. Felicitaciones 👌, vamos por buen camino.")
                        {
                            ChatBot.sendMessage(enemy.UserId, "Han hundido uno de tus barcos :( .");
                        }
                        else if (res == "¡Hemos ganado la batalla capitán! 👏🏻. El mundo es un lugar más seguro gracias a tu valentia 🌎.")
                        {
                            GamesContainer.RemoveGame(game);
                            this.Keywords.Remove(from); //Removemos el id asi sigue el handler
                            this.Keywords.Remove(enemy.UserId.ToString()); //Removemos el id asi sigue el handler
                            ChatBot.sendMessage(enemy.UserId, "Has perdido la batalla.");
                            win = true;
                        }
                        TelegramBoardPrinter classTelegramBoardPrinter = new TelegramBoardPrinter();
                        ChatBot.sendMessageBoard(message.From.Id, $"```SHIPBOARD: { classTelegramBoardPrinter.PrintPlayerBoard(player1.GetPlayerShipBoard())}```");
                        ChatBot.sendMessageBoard(message.From.Id, $"```SHOTBOARD: { classTelegramBoardPrinter.PrintPlayerBoard(player1.GetPlayerShotBoard())}```");
                        if (!win)
                        {
                            ChatBot.sendMessage(enemy.UserId, $"Es tu turno /atacarEnemigo. ");
                            chainData.userPostionHandler[enemy.UserId.ToString()].Clear();
                        }
                        else
                        {
                            ChatBot.sendMessage(enemy.UserId, $"Desea jugar nuevamente ? /hola");
                            ChatBot.sendMessage(message.From.Id, $"Desea jugar nuevamente ? /hola");
                        }
                        chainData.userPostionHandler[from].Clear();

                        response = res;
                        return true;
                    }

                }
                else if (message.From.Id != game.Active_Player.UserId)
                {
                    response = "Espera a que sea tu turno 🤡.";
                    return true;
                }

                response = string.Empty;
                return false;
            }
            response = string.Empty;
            return false;
        }
    }
}