using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    public class UserToPlayerHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public UserToPlayerHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new List<string>();
            Keywords.Add("/batallar");
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {
            ChainData chainData = ChainData.Instance;
            string from = message.From.ToString();

            chainData.userPostionHandler[message.From.ToString()].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo

            if (this.CanHandle(message) || chainData.userPostionHandler.ContainsKey(from))
            {
                chainData.userPostionHandler[from].Add(message.Text);

                if (chainData.userPostionHandler[from].Count == 1)
                {
                    response = "Antes de luchar debes de seleccionar la region 🌎 de campo en la que batallarás a muerte.🪦" +
                    "\n🇦🇷 /Maldivas: 10 hectareas \n🇺🇦 /Donbas: 15 hectareas \n🇱🇦 /Laos: 25 hectareas";

                    chainData.userPostionHandler[from].Add(message.Text);
                    this.Keywords.Add(message.From.Id.ToString()); //Añadimos el user id a las Keywords. Important!
                }
                if (chainData.userPostionHandler[from].Count == 2)
                {
                    if (message.Text.Equals("/Maldivas"))
                    {
                        response = "¡Has seleccionado las 🇦🇷 /Maldivas de 10 hectareas!. "
                            + "Estoy buscandote una battalla ⚔️... \n Sal vivo por favor 🤞🏽. ¡Suerte 🍀!";
                    }
                    else if (message.Text.Equals("/Donbas"))
                    {
                        response = "¡Has seleccionado el 🇺🇦 /Donbas de 15 hectareas!. "
                            + "Estoy buscandote una battalla ⚔️... \n Sal vivo por favor 🤞🏽. ¡Suerte 🍀!";
                    }
                    else
                    {
                        response = "¡Has seleccionado 🇱🇦 /Laos de 25 hectareas!. " +
                            "Estoy buscandote una battalla ⚔️... \n Sal vivo por favor 🤞🏽. ¡Suerte 🍀!";

                    }
                    this.Keywords.Remove(message.From.Id.ToString());
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
    }

}