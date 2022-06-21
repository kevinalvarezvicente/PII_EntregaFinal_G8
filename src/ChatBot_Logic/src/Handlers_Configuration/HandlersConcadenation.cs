using ChatBot_Logic.src.Handlers;
using ChatBot_Logic.src.HandlersConfiguration;

namespace ChatBot_Logic.src.Handlers_Configuration
{
    /// <summary>
    /// Clase titular de informacion, facilita la informacion de los handlers.
    /// </summary>
    public static class HandlersConcadenation
    {
        private static IHandler firstHandler;

        /// <summary>
        /// Inicializa cada Handler.
        /// </summary>
        public static void InitializeHandlers()
        {
            firstHandler = new HelloHandler(new RegisterUserHandler(new GoodByeHandler(null)));
        }

        /// <summary>
        /// Obtiene el primer Handler.
        /// </summary>
        public static IHandler FirstHandler
        {
            get
            {
                return firstHandler;
            }
        }

    }
}
