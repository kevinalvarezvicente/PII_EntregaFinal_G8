using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System.Collections.Generic;

/*namespace ChatBot_Logic.src.Handlers
{
    public class MakeBoardHandler : BaseHandler
    {
        public MakeBoardHandler(BaseHandler next) : base(next)
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
                    // Player player = new Player(ActiveUser, 10);
                    //User ActiveUser = new User(message.From.Id, message.From.FirstName, message.From.FirstName);
                    Player player = new Player(ActiveUser, 10);
                    response = "¡Has seleccionado las 🇦🇷 /Maldivas de 10 hectareas!. Estoy buscandote una battalla ⚔️... \n Sal vivo por favor 🤞🏽. ¡Suerte 🍀!";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 0 && message.Text.Equals("/Donbas"))
                {
                    chainData.userPostionHandler[from].Add("/MakeBoard"); //Añadimos el nuevo handler que se esta ejecutando
                    User ActiveUser = UsersContainer.GetUSerByID(message.From.Id);
                    Player player = new Player(ActiveUser, 15);
                    response = "¡Has seleccionado el 🇺🇦 /Donbas de 15 hectareas!. "
                            + "Estoy buscandote una battalla ⚔️... \n Sal vivo por favor 🤞🏽. ¡Suerte 🍀!";

                }
                else if (chainData.userPostionHandler[from].Count == 0 && message.Text.Equals("/Laos"))
                {
                    chainData.userPostionHandler[from].Add("/MakeBoard"); //Añadimos el nuevo handler que se esta ejecutando
                    User ActiveUser = UsersContainer.GetUSerByID(message.From.Id);
                    Player player = new Player(ActiveUser, 25);
                    response = "¡Has seleccionado 🇱🇦 /Laos de 25 hectareas!. " +
                            "Estoy buscandote una battalla ⚔️... \n Sal vivo por favor 🤞🏽. ¡Suerte 🍀!";
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
}*/