using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    public class SelectLobbyHandler : BaseHandler
    {
        public SelectLobbyHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new List<string>();
            Keywords.Add("/Maldivas");
            Keywords.Add("/Donbas");
            Keywords.Add("/Laos");

        }

        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {
            ChainData chainData = ChainData.Instance;
            string from = message.From.Id.ToString();

            if (this.CanHandle(message))
            {
                if (!chainData.userPostionHandler[from][0].Equals("/MakeBoard"))
                {
                    chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                }

                if (chainData.userPostionHandler[from].Count == 0 && message.Text.Equals("/Maldivas"))
                {
                    chainData.userPostionHandler[from].Add("/MakeBoard"); //Añadimos el nuevo handler que se esta ejecutando
                    User ActiveUser = UsersContainer.GetUSerByID(message.From.Id);
                    Player player = new Player(ActiveUser);
                    player.AddPlayerShipBoard(new ShipBoard(10));
                    player.AddPlayerShotBoard(new ShotBoard(10));
                    LobbyContainer.AddPlayer(player);
                    response = "¡Has seleccionado las 🇦🇷 Maldivas 🇦🇷 de 10 hectareas!. "
                            + "Para ser el dueño 🔑 de esta zona debes defenderla ⚔️... \n Espero poder volver a verte luego de la batalla 🤞🏽. ¡Suerte 🍀! \n Según informes 📜 de nuestra inteligencia están atacando tu zona, defiendela o la perderás /defender";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 0 && message.Text.Equals("/Donbas"))
                {
                    chainData.userPostionHandler[from].Add("/MakeBoard"); //Añadimos el nuevo handler que se esta ejecutando
                    User ActiveUser = UsersContainer.GetUSerByID(message.From.Id);
                    Player player = new Player(ActiveUser);
                    player.AddPlayerShipBoard(new ShipBoard(15));
                    player.AddPlayerShotBoard(new ShotBoard(15));
                    LobbyContainer.AddPlayer(player);
                    response = "¡Has seleccionado el 🇺🇦 Donbas 🇺🇦 de 15 hectareas!. "
                            + "Para ser el dueño 🔑 de esta zona debes defenderla ⚔️... \n Espero poder volver a verte luego de la batalla 🤞🏽. ¡Suerte 🍀! \n Según informes 📜 de nuestra inteligencia están atacando tu zona, defiendela o la perderás /defender";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 0 && message.Text.Equals("/Laos"))
                {
                    chainData.userPostionHandler[from].Add("/MakeBoard"); //Añadimos el nuevo handler que se esta ejecutando
                    User ActiveUser = UsersContainer.GetUSerByID(message.From.Id);
                    Player player = new Player(ActiveUser);
                    player.AddPlayerShipBoard(new ShipBoard(20));
                    player.AddPlayerShotBoard(new ShotBoard(20));
                    LobbyContainer.AddPlayer(player);
                    response = "¡Has seleccionado 🇱🇦 Laos 🇱🇦 de 25 hectareas!. "
                    + "Para ser el dueño 🔑 de esta zona debes defenderla ⚔️... \n Espero poder volver a verte luego de la batalla 🤞🏽. ¡Suerte 🍀! \n Según informes 📜 de nuestra inteligencia están atacando tu zona, defiendela o la perderás /defender";
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