using System.Linq;
using ChatBot_Logic.src;
using ChatBot_Logic.src.Handlers;
using ChatBot_Logic.src.HandlersConfiguration;
using NUnit.Framework;
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

        [SetUp]
        public void Setup()
        {
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
            Assert.That(response, Is.EqualTo("¡Hola! ¿Cómo estás?"));
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