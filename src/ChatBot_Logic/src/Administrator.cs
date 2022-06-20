using PII_ENTREGAFINAL_G8.src.ChatBot_Logic.SecretToken;
using Telegram.Bot;

namespace ChatBot_Logic.src
{
    public class Administrator
    {
        public void BotConfigurations()
        {
            TokenConfiguration.StartTokenConfig();

            ChatBot Bot = ChatBot.GetInstance;

            var cts = new CancellationTokenSource();
            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en background). El primer método
            // HandleUpdateAsync es invocado por el bot cuando se recibe un mensaje. El segundo método HandleErrorAsync
            // es invocado cuando ocurre un error.
            Bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                new ReceiverOptions()
                {
                    AllowedUpdates = Array.Empty<UpdateType>()
                },
                cts.Token
            );

            Console.WriteLine($"Bot is up!");

            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();

            // Terminamos el bot.
            cts.Cancel();
        }
    }
}
