using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    public class MakeShotHandler : BaseHandler
    {
        public MakeShotHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new List<string>();
            Keywords.Add("/atacarEnemigo");
        }

        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {

            ChainData chainData = ChainData.Instance;
            string from = message.From.Id.ToString();

            if (this.CanHandle(message))
            {
                chainData.userPostionHandler[from].Add("/atacarEnemigo"); //Añadimos el nuevo handler que se esta ejecutando.
                if (!chainData.userPostionHandler[from][0].Equals("/atacarEnemigo"))
                {
                    chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                    chainData.userPostionHandler[from].Add("/atacarEnemigo"); //Añadimos el nuevo handler que se esta ejecutando.
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

                    if (chainData.userPostionHandler[from].Count == 2)
                    {
                        response = $"Es hora de que realizes tu ataque a tu enemigo {enemy.PlayerName}, escribe la coordenada.";
                        this.Keywords.Add(from); // Captamos el segundo mensaje que sea enviado luego de esta response, añadiendo el id del Usuario a las Keywords
                        return true;
                    }
                    if (chainData.userPostionHandler[from].Count == 3)
                    {
                        chainData.userPostionHandler[from].Add("/tiro");
                        string letter = message.Text.Substring(0, 1);
                        string number1 = Utils.LetterToNumber(letter);
                        string number2 = message.Text.Substring(1, message.Text.Length - 1);
                        string build = number1 + number2;
                        string res = game.ShotMade(build);
                        TelegramBoardPrinter classTelegramBoardPrinter = new TelegramBoardPrinter();
                        ChatBot.sendMessageBoard(message.From.Id, $"```SHIPBOARD: { classTelegramBoardPrinter.PrintPlayerBoard(player1.GetPlayerShipBoard())}```");
                        ChatBot.sendMessageBoard(message.From.Id, $"```SHOTBOARD: { classTelegramBoardPrinter.PrintPlayerBoard(player1.GetPlayerShotBoard())}```");
                        ChatBot.sendMessage(enemy.UserId, $"Es tu turno /atacarEnemigo. ");
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