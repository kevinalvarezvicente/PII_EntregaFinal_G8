using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    /// <summary>
    /// El handler que trabaja cuando el usuario quiere comenzar a jugar y le pide que seleccione el tamaño del tablero para despues encontrarle un oponente
    ///  Un "handler" del patrón Chain of Responsibility que implementa el comando "/batallar".
    /// </summary>
    public class BattlePlacerHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public BattlePlacerHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new List<string>();
            Keywords.Add("/batallar");
        }

        /// <summary>
        /// Es el método donde se trabaja todo lo del handler.
        /// Procesa el mensaje "/batallar"
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

                if (!chainData.userPostionHandler[from][0].Equals("/batallar"))
                {
                    chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                }

                if (chainData.userPostionHandler[from].Count == 0)
                {
                    chainData.userPostionHandler[from].Add("/batallar"); //Añadimos el nuevo handler que se esta ejecutando

                    response = "Antes de luchar debes de seleccionar la region 🌎 de campo en la que batallarás a muerte.🪦" +
                    "\n🇦🇷 /Maldivas: 10 hectareas \n🇺🇦 /Donbas: 15 hectareas \n🇱🇦 /Laos: 25 hectareas";
                    return true;
                }

            }
            response = string.Empty;
            return false;
        }
    }

}