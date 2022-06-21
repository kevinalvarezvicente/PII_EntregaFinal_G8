using ChatBot_Logic.src.Handlers;
using ChatBot_Logic.src.HandlersConfiguration;

namespace ChatBot_Logic.src.Handlers_Configuration
{
    public class HandlersConcadenation
    {
        private static IHandler firstHandler;

        public static void InitializeHandlers()
        {
            firstHandler = new HelloHandler(new GoodByeHandler(null));
        }

        public static IHandler FirstHandler
        {
            get
            {
                return firstHandler;
            }
        }

    }
}
