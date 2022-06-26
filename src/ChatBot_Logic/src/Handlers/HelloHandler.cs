namespace ChatBot_Logic.src.Handlers
{
    using ChatBot_Logic.src.HandlersConfiguration;
    using ClassLibrary;
    using System.Collections.ObjectModel;
    using Telegram.Bot.Types;
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
            this.Keywords = new string[] { "hola", "Hola" };
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            ChainData chainData = ChainData.Instance;
            chainData.userPostionHandler.Add(message.From.ToString(), new Collection<string>());
            response = "¡Hola! ¿Cómo estás?";
            return false;
        }
    }
}

