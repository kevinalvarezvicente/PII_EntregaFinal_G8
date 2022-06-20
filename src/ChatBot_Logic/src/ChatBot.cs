using PII_ENTREGAFINAL_G8.src.ChatBot_Logic.SecretToken;
using Telegram.Bot;

namespace ChatBot_Logic.src
{
    public class ChatBot
    {

        private static ChatBot instance;
        private ITelegramBotClient bot;

        private ChatBot()
        {
            var cts = new CancellationTokenSource();
            TokenConfiguration.StartTokenConfig();
            this.bot = new TelegramBotClient(TokenConfiguration.Token);
            Console.WriteLine($"Bot is up!");
            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();
            // Terminamos el bot.
            cts.Cancel();
        }

        public ITelegramBotClient Client
        {
            get
            {
                return this.bot;
            }
        }
        public void listen()
        {
            bot.StartReceiving(
                    HandleUpdateAsync,
                    HandleErrorAsync,
                    new ReceiverOptions()
                    {
                        AllowedUpdates = Array.Empty<UpdateType>()
                    },
                    cts.Token
           );
        }


        public static ChatBot Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChatBot();
                }
                return instance;
            }
        }
        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo mensajes, ediciones de mensajes,
        /// respuestas a botones, etc. En este ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                // Sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived(botClient, update.Message);
                }
            }
            catch (Exception e)
            {
                await HandleErrorAsync(botClient, e, cancellationToken);
            }
        }

        /// <summary>
        /// Maneja los mensajes que se envían al bot a través de handlers de una chain of responsibility.
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        private static async Task HandleMessageReceived(ITelegramBotClient botClient, Message message)
        {
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");

            string response = string.Empty;

            firstHandler.Handle(message, out response);

            if (!string.IsNullOrEmpty(response))
            {
                await Bot.SendTextMessageAsync(message.Chat.Id, response);
            }
        }

        /// <summary>
        /// Manejo de excepciones. Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }
    }
}