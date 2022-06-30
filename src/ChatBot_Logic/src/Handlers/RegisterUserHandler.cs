using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    /// <summary>
    /// Handler que registra al usuario
    /// Es subclase de BaseHandler
    /// Forma parte de Chain of fResponsibility
    /// </summary>
    public class RegisterUserHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegisterUserHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegisterUserHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new List<string>();
            Keywords.Add("/SerSoldado");
        }
        /// <summary>
        /// Es el método donde se trabaja todo lo del handler.
        /// Procesa el mensaje "/SerSoldado"
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
