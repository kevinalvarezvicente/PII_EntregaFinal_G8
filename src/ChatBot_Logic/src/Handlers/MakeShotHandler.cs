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
            Keywords.Add("/atacar");
        }

        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {

            ChainData chainData = ChainData.Instance;
            string from = message.From.Id.ToString();

            if (this.CanHandle(message))
            {
                Game game = GamesContainer.VerifyUserOnGame(message.From.Id);
                if (message.From.Id == game.Active_Player.UserId)
                {
                    Player player1 = game.Active_Player;
                    Player enemy = game.Inactive_Player;

                    if (!chainData.userPostionHandler[from][0].Equals("/atacar"))
                    {
                        chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                    }
                    if (game.Active_Player == player1)
                    {
                        if (chainData.userPostionHandler[from].Count == 0)
                        {
                            chainData.userPostionHandler[from].Add("/atacar"); //Añadimos el nuevo handler que se esta ejecutando.
                            response = $"Es hora de que realizes tu ataque a tu enemigo {enemy.PlayerName}, escribe la coordenada y direccion a enviar el ataque.";
                            this.Keywords.Add(from); // Captamos el segundo mensaje que sea enviado luego de esta response, añadiendo el id del Usuario a las Keywords
                            return true;
                        }
                        if (chainData.userPostionHandler[from].Count == 1)
                        {
                            chainData.userPostionHandler[from].Add("/tiro");

                            string letter = message.Text.Substring(0, 1);
                            string number1 = Utils.LetterToNumber(letter);
                            string number2 = message.Text.Substring(1, message.Text.Length - 1);
                            string build = number1 + number2;
                            game.ShotMade(build);
                            response = enemy.ReceiveShot(message.Text);
                            return true;
                        }
                        else
                        {
                            response = "Tu enemigo esta realizando su ataque, debes esperar 🪖 ";
                        }
                    }
                    else if (message.From.Id != game.Active_Player.UserId)
                    {
                        response = "Espera a que sea tu turno 🤡.";
                    }
                }
                response = string.Empty;
                return false;
            }
        }
    }