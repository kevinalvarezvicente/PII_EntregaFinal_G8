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
            string from = message.From.Id.ToString();

            if (this.CanHandle(message))
            {
                chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo
                chainData.userPostionHandler[from].Add("/batallar"); //Añadimos el nuevo handler que se esta ejecutando

                if (chainData.userPostionHandler[from].Count == 1)
                {
                    chainData.userPostionHandler[from].Add(message.Text); // Persistimos que el Usuario esta en la primera iteración.
                    response = "Antes de luchar debes de seleccionar la region 🌎 de campo en la que batallarás a muerte.🪦" +
                    "\n🇦🇷 /Maldivas: 10 hectareas \n🇺🇦 /Donbas: 15 hectareas \n🇱🇦 /Laos: 25 hectareas";
                    this.Keywords.Add(message.From.Id.ToString()); //// Captamos el segundo mensaje que sea enviado luego de esta response, añadiendo el id del Usuario a las Keywords 
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 2)
                {
                    chainData.userPostionHandler[from].Add(message.Text); // Persistimos que el Usuario esta en la segunda iteración.
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
                    else if (message.Text.Equals("/Laos"))
                    {
                        response = "¡Has seleccionado 🇱🇦 /Laos de 25 hectareas!. " +
                            "Estoy buscandote una battalla ⚔️... \n Sal vivo por favor 🤞🏽. ¡Suerte 🍀!";
                    }
                    else
                    {
                        response = "No has seleccionado una opcion valida 🥺";
                    }
                    this.Keywords.Remove(from);
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
    }

}