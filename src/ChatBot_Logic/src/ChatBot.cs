using ChatBot_Logic.src.Handlers_Configuration;
using PII_ENTREGAFINAL_G8.src.ChatBot_Logic.SecretToken;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


namespace ChatBot_Logic.src
{
    public class ChatBot : ISecretService
    {
        public string Token => TokenConfiguration.Token;
        private static ChatBot _instance;
        private static TelegramBotClient Bot;
        CancellationTokenSource cts = new CancellationTokenSource();
        private ChatBot()
        {
            TokenConfiguration.StartTokenConfig();
            HandlersConcadenation.InitializeHandlers();
            Bot = new TelegramBotClient(Token);
            listen();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("------------------- Hola programador soy " + this.BotName + ", ahora estoy en servicio para todos tus clientes -------------------");
            Console.WriteLine("------------------------------- No te olvides que mi identificador es " + this.BotId + " ----------------------------------");
            Console.WriteLine("--------------- y mi token dado por mi padre es " + Token + " :) ----------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();
            // Terminamos el bot.
            cts.Cancel();
        }
        private User BotInfo
        {
            get
            {
                return this.Client.GetMeAsync().Result;
            }
        }
        public int BotId
        {
            get
            {
                return (int)this.BotInfo.Id;
            }
        }

        public string BotName
        {
            get
            {
                return this.BotInfo.FirstName;
            }
        }
        public ITelegramBotClient Client
        {
            get
            {
                return Bot;
            }
        }
        public void listen()
        {
            Bot.StartReceiving(
                    HandleUpdateAsync,
                    HandleErrorAsync,
                    new ReceiverOptions()
                    {
                        AllowedUpdates = Array.Empty<UpdateType>()
                    },
                    cts.Token
           );


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
                else
                {
                    await HandleCallbackQueryReceived(botClient, update.CallbackQuery);
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
            Console.WriteLine($"Received a message from {message.From} saying: {message.Text}");

            string response = string.Empty;

            HandlersConcadenation.FirstHandler.Handle(message, out response);

            if (!string.IsNullOrEmpty(response))
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, ".", replyMarkup: GetMenu());
            }
        }

        private static async Task HandleCallbackQueryReceived(ITelegramBotClient botClient, CallbackQuery callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs;

            Console.WriteLine($"Received a message from {callbackQuery.From} saying: {callbackQuery.Data}");

            string response = callbackQuery.Data;

            if (!string.IsNullOrEmpty(response))
            {
                await botClient.SendTextMessageAsync(
                chatId: callbackQuery.Message.Chat.Id,
                text: $"Received send {callbackQuery.Data}"
            );
            }
        }

        public static InlineKeyboardMarkup GetMenu()
        {
            //Creamos los botones
            List<InlineKeyboardButton> buttons = new List<InlineKeyboardButton>();
            buttons.Add(new InlineKeyboardButton("No") { Text = "No", CallbackData = $"No" });
            buttons.Add(new InlineKeyboardButton("Si") { Text = "Si", CallbackData = $"Si" });

            //Creamos una fila con dos columnas
            var menuDosColumnas = new List<InlineKeyboardButton[]>();
            menuDosColumnas.Add(new[] { buttons[0], buttons[1] });

            //Creamos el KeyBoard y agregamos la fila de butones
            var menu = new InlineKeyboardMarkup(menuDosColumnas.ToArray());
            return menu;
        }
        /// <summary>
        /// Manejo de excepciones. Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }

        public static ChatBot Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ChatBot();
                }
                return _instance;
            }
        }
    }
}