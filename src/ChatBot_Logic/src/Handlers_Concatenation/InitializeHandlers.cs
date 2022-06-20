using ChatBot_Logic.src.HandlersConfiguration;

namespace ChatBot_Logic.src.Handlers_Concatenation
{
    public static class InitializeHandlers
    {
        private static IHandler firstHandler;

        firstHandler =
                new HelloHandler(
                new GoodByeHandler(
                new PhotoHandler(Bot, null)
            ));
    }
}
