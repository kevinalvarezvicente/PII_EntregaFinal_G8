namespace ChatBot_Logic.src.Handlers
{
    using ChatBot_Logic.src.HandlersConfiguration;
    using ClassLibrary;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class HelloHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public HelloHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new List<string>();
            Keywords.Add("hola");
            Keywords.Add("Hola");
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
            if (!chainData.userPostionHandler.ContainsKey(from))
            {
                chainData.userPostionHandler.Add(from, new Collection<string>()); //Creamos el espacio del Usuario en el diccionario para almacenar el handler en el que se encuentra.
            }

            if (this.CanHandle(message)) //Si la Keyword o el Id del Usuario entra se procesa este handler.
            {

                if (chainData.userPostionHandler[from].Count == 0) //La primera iteracion del handler 
                {
                    chainData.userPostionHandler[from].Add("/hola"); //Persistimos en handler que esta ejecutando el usuario.
                    response = "¡Hola! Mi nombre es Paco, soy uno de los ultimos soldados vivos 😨. Necesitamos de tu ayuda para batallar contra nuestros enemigos 🤕. ¿Aceptas el reto? ( /Si /No )";
                    this.Keywords.Add(from); // Captamos el segundo mensaje que sea enviado luego de esta response, añadiendo el id del Usuario a las Keywords 
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 1 && message.Text == "/Si" || message.Text == "/si") //La segunda iteración, caso mensaje "Si"
                {
                    chainData.userPostionHandler[from].Add(message.Text); // Persistimos que el Usuario esta en la segunda iteración.
                    response = "Muchas gracias por tu ayuda, te inscribiremos para ser uno de nuestros combatientes 🪖🔫. Presiona Aqui /SerSoldado";
                    this.Keywords.Remove(from); //Removemos el id asi el siguiente mensaje enviado sera evalaudo por
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 1 && message.Text == "/No" || message.Text == "/no") //La segunda iteración, caso mensaje "No"
                {
                    chainData.userPostionHandler[from].Add(message.Text); // Persistimos que el Usuario esta en la segunda iteración.
                    response = "Lamento que no puedas ayudarnos, es nuestro fin ☣️.";
                    this.Keywords.Remove(from); //Removemos el id asi sigue el handler
                    return true;
                }

            }
            response = string.Empty;
            return false;
        }
    }
}

