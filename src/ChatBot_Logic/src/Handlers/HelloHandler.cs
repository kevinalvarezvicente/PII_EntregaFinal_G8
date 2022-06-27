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
            string from = message.From.ToString();
            try
            {
                chainData.userPostionHandler.Add(message.From.ToString(), new Collection<string>());
            }
            catch
            {

            }
            if (this.CanHandle(message) || chainData.userPostionHandler.ContainsKey(from))
            {
                chainData.userPostionHandler[from].Add("/hola");
                if (chainData.userPostionHandler[from].Count == 1)
                {
                    response = "¡Hola! Mi nombre es Paco, soy uno de los ultimos soldados vivos 😨. Necesitamos de tu ayuda para batallar contra nuestros enemigos 🤕. ¿Aceptas el reto? ( /Si /No )";
                    this.Keywords.Add(message.From.Id.ToString());
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 2 && message.Text == "/Si" || message.Text == "/si")
                {
                    chainData.userPostionHandler[from].Add(message.Text);
                    response = "Muchas gracias por tu ayuda, te inscribiremos para ser uno de nuestros combatientes 🪖🔫. Presiona Aqui /SerSoldado";
                    this.Keywords.Remove(message.From.Id.ToString()); //Removemos el id asi sigue el handler
                    return true;
                }
                if (chainData.userPostionHandler[from].Count == 2 && message.Text == "/No" || message.Text == "/no")
                {
                    chainData.userPostionHandler[from].Add(message.Text);
                    response = "Lamento que no puedas ayudarnos, es nuestro fin ☣️.";
                    this.Keywords.Remove(message.From.Id.ToString()); //Removemos el id asi sigue el handler
                    return true;
                } //SOLUCIONAR MENSAJE DE REPETICION

            }
            response = string.Empty;
            return false;
        }
    }
}

