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

                if (chainData.userPostionHandler[from].Count == 0)
                //Si estas en la primera iteración
                {
                    chainData.userPostionHandler[from].Add("/defender");
                    //Añadimos el nuevo handler que se esta ejecutando

                    Player player1 = LobbyContainer.GetPlayerByID(message.From.Id);
                    Player player2 = LobbyContainer.JoinPlayersWithSameBoardSize(player1);
                    if (player2 == null)
                    {
                        response = "Al parecer tu oponente se ha asustado 😂 y ha decidido retirarse de la batalla, es hora de atacar 🔥 y no de defender tu terreno ⚔️. Te estamos buscando un rival digno.";
                    }
                    else
                    {
                        Game game = new Game(player1, player2);
                        GamesContainer.AddGame(game);
                        LobbyContainer.RemoveUser(player1);
                        LobbyContainer.RemoveUser(player2);

                        ChatBot.sendMessage(player2.UserId, $"Te infiltrarás 🕵 en el terreno de {player1.PlayerName} es hora de derrotarlo 😈. Es hora de posicionar tus barcos 🛥 /NavesBatalla");
                        response = $"El enemigo conocido como {player2.PlayerName} se ha inflitrado 🕵 en tu terreno, es hora de derrotarlo 😈. Es hora de posicionar tus barcos 🛥 /NavesBatalla";
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