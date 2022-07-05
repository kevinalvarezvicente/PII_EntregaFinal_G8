using System.Linq;
using System.Threading.Tasks;
using ChatBot_Logic.src;
using ChatBot_Logic.src.Handlers;
using ChatBot_Logic.src.HandlersConfiguration;
using NUnit.Framework;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace LibraryTests
{

    /// <summary>
    ///   testea el hola handler
    /// </summary>
    public class HelloHandlerTests
    {
        HelloHandler handler;
        Telegram.Bot.Types.Message message;

        public static async Task magic(ITelegramBotClient bot, Message msg){
            await ChatBot.HandleMessageReceived(bot,msg);
        } 

        [SetUp]
        public void Setup()
        {
            ChatBot bot = ChatBot.Instance;
            Message msg = new Message();
            msg.Text = "Hola"
            ;
            ITelegramBotClient client;
            magic(bot.Client,msg);
            handler = new HelloHandler(null);
            message = new Telegram.Bot.Types.Message();
            
        }

        [Test]
        public void TestHandle()
        {
            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);

        }

        [Test]
        public void TestDoesNotHandle()
        {
            message.Text = "adios";
            string response;

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Null);
            Assert.That(response, Is.Empty);
        }
    }
}