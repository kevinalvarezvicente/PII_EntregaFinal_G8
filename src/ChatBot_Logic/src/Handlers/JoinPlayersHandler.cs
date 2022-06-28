using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    public class JoinPlayerHandler : BaseHandler
    {
        public JoinPlayerHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new List<string>();
            Keywords.Add("/defender");


        }

        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {
            ChainData chainData = ChainData.Instance;
            string from = message.From.Id.ToString();

            if (this.CanHandle(message))
            {
                if (!chainData.userPostionHandler[from][0].Equals("/defender"))
                {
                    chainData.userPostionHandler[from].Clear(); 
                    //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                }

                if (chainData.userPostionHandler[from].Count == 0 )
                //Si estas en la primera iteración
                {
                    chainData.userPostionHandler[from].Add("/defender"); 
                    //Añadimos el nuevo handler que se esta ejecutando

                    Player player1 = LobbyContainer.GetPlayerByID(message.From.Id);
                    Player player2 = LobbyContainer.JoinPlayersWithSameBoardSize(player1);
                    if(player2 == null)
                    {
                        response = "Estamos buscando tu oponente";
                    }
                    else
                    {
                        Game game = new Game(player1, player2);

                        response = $"Te hemos encontrado un digno oponente {player2.PlayerName}";
                    }

                    return true;
                }
                else
                {
                    response = "No has seleccionado una opcion valida 🥺";
                    return true;
                }
            }
            response = string.Empty;
            return false;

        }
    }
}