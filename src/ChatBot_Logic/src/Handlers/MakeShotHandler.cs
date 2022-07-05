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
                Player player1 = LobbyContainer.GetPlayerByID(message.From.Id);
                Game game = GamesContainer.VerifyUserOnGame(message.From.Id);
                Player enemy = LobbyContainer.GetPlayerByID(GamesContainer.ObtainEnemyId(message.From.Id));

                if (!chainData.userPostionHandler[from][0].Equals("/atacar"))
                {
                    chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                }
                if (game.Active_Player == player1)
                {
                    if (chainData.userPostionHandler[from].Count == 0)
                    {
                        if (game.Active_Player == null)
                        {
                            game.Active_Player = player1;
                            game.Inactive_Player = enemy;
                        }

                        chainData.userPostionHandler[from].Add("/atacar"); //Añadimos el nuevo handler que se esta ejecutando.
                        response = "Es hora de que realizes tu ataque, escribe la coordenada y direccion a enviar el ataque.";
                        this.Keywords.Add(from); // Captamos el segundo mensaje que sea enviado luego de esta response, añadiendo el id del Usuario a las Keywords
                        return true;
                    }
                    if (chainData.userPostionHandler[from].Count == 1)
                    {
                        chainData.userPostionHandler[from].Add("/tiro");
                        player1.MakeShot(message.Text);
                        response = enemy.ReceiveShot(message.Text);
                        return true;
                    }
                }
                else
                {
                    response = "Tu enemigo esta realizando su ataque, debes esperar 🪖 ";
                }
            }
            response = string.Empty;
            return false;
        }
    }
}