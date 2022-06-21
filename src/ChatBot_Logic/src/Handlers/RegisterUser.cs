using ChatBot_Logic.src.HandlersConfiguration;
using Telegram.Bot.Types;


namespace ChatBot_Logic.src.Handlers
{
 
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class RegisterUserHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegisterUserHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegisterUserHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "registrar", "registrarme" };
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            response = "que andas pariente no te registro porque no lo programaron pa";
        }
    }
}

