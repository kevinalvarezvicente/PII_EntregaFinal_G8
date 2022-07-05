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

namespace ChatBot_Logic.src
{
    /// <summary>
    /// Clase encargada de la gestion del ChatBot
    /// </summary>
    public class ChatBot : ISecretService
    {
        /// <summary>
        /// Diccionario donde se guarda lo que hay en la ultima posición del trabajo del handler
        /// </summary>
        public static Dictionary<string, string> lastPosition = new Dictionary<string, string>();

        /// <summary>
        /// Obtenemos el Token de la clase TokenConfiguration
        /// </summary>
        public string Token => TokenConfiguration.Token;

        /// <summary>
        //  Instancia privada y unica de la clase ChatBot
        /// </summary>
        private static ChatBot _instance;
        /// <summary>
        /// Variable que almacenara el cliente Telegram, en este caso el Bot.
        /// </summary>
        private static TelegramBotClient Bot;
        /// <summary>
        /// Variable para cerrar la escucha del bot.
        /// </summary>
        CancellationTokenSource cts = new CancellationTokenSource();
        /// <summary>
        /// Constructor de ChatBot
        /// </summary>
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
        /// <summary>
        /// Obtiene la informacion del Bot.
        /// </summary>
        private User BotInfo
        {
            get
            {
                return this.Client.GetMeAsync().Result;
            }
        }
        /// <summary>
        /// Obtiene el id del Bot.
        /// </summary>
        public int BotId
        {
            get
            {
                return (int)this.BotInfo.Id;
            }
        }

        /// <summary>
        /// Obtiene el nombre del Bot.
        /// </summary>
        public string BotName
        {
            get
            {
                return this.BotInfo.FirstName;
            }
        }


        /// <summary>
        /// Obtiene al cliente.
        /// </summary>
        public ITelegramBotClient Client
        {
            get
            {
                return Bot;
            }
        }
        /// <summary>
        /// Iniciar la escucha del Bot, para asi poder recibir y procesar los mensajes.
        /// </summary>
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
        /// <param name="botClient">El bot que realiza</param>
        /// <returns></returns>
        private static async Task HandleMessageReceived(ITelegramBotClient botClient, Message message)
        {
            Console.WriteLine($"Received a message from {message.From.FirstName} --> {message.From.Id} saying: {message.Text}");

            string response = string.Empty;

            HandlersConcadenation.FirstHandler.Handle(message, out response);

            if (!string.IsNullOrEmpty(response))
            {
                await Bot.SendTextMessageAsync(message.Chat.Id, response);
            }
        }
        /// <summary>
        /// Método que envía mensaje
        /// </summary>
        /// <param name="id">Recibe como parámetro el identificador</param>
        /// <param name="text">recibe un texto de tipo string</param>
        /// <returns></returns>
        public static async void sendMessage(long id, String text)
        {
            await Bot.SendTextMessageAsync(id, text);
        }
        /// <summary>
        /// Método donde el bot imprime por pantalla el tablero indicado
        /// </summary>
        /// <param name="id">Persona que está hablando con el bot</param>
        /// <param name="text">Es el tablero pasado a string</param>
        /// <returns></returns>
        public static async void sendMessageBoard(long id, String text)
        {
            await Bot.SendTextMessageAsync(id, text, ParseMode.MarkdownV2);
        }

        /// <summary>
        /// Se fija del errores al comunicarse con el bot
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Obtiene la instancia del ChatBot, si no existe la crea.
        /// Desarollo con el patrón Singleton.
        /// </summary>
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