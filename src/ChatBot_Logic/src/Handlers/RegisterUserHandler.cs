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
            string from = message.From.ToString();

            chainData.userPostionHandler[message.From.ToString()].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo

            if (this.CanHandle(message) || chainData.userPostionHandler.ContainsKey(from))
            {
                chainData.userPostionHandler[from].Add(message.Text);

                response = "Nuestros aliados de inteligencia 🔍 te han ahorrado el escribir tu nombre. Te hemos " +
                    "registrado en nuestro sistema de batallas 💻 con el nombre de : 🛑 "
                    + message.From.FirstName + " " + message.From.LastName + " 🛑\n" +
                    "¡Tenemos un centenar de battallas ⚔️ necesitamos de tu ayuda! Unete a un escuadrón y " +
                    "lucha contra un enemigo 💣 /batallar";
                UsersContainer.usersContainer.Add(new User(message.From.Id, message.From.FirstName, message.From.LastName));
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}
