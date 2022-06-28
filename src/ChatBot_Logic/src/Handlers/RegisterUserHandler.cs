using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    public class RegisterUserHandler : BaseHandler
    {
        public RegisterUserHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new List<string>();
            Keywords.Add("/SerSoldado");
        }

        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {
            ChainData chainData = ChainData.Instance;
            string from = message.From.Id.ToString();

            if (this.CanHandle(message))
            {
                if (!chainData.userPostionHandler[from][0].Equals("/SerSoldado"))
                {
                    chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                }

                if (chainData.userPostionHandler[from].Count == 0)
                {
                    chainData.userPostionHandler[from].Add("/SerSoldado"); //Añadimos el nuevo handler que se esta ejecutando.
                    response = "Nuestros aliados de inteligencia 🔍 te han ahorrado el escribir tu nombre. Te hemos " +
                        "registrado en nuestro sistema de batallas 💻 con el nombre de : 🛑 "
                        + message.From.FirstName + " " + message.From.LastName + " 🛑\n" +
                        "¡Tenemos un centenar de battallas ⚔️ necesitamos de tu ayuda! Unete a un escuadrón y " +
                        "lucha contra un enemigo 💣 /batallar";
                    UsersContainer.usersContainer.Add(new User(message.From.Id, message.From.FirstName, message.From.LastName));
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
    }
}
