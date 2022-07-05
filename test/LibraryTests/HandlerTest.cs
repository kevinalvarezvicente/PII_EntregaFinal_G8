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
        Message message;

        [SetUp]
        public void Setup()
        {
            handler = new HelloHandler(null);
            message = new Message();
            Telegram.Bot.Types.User usu = new Telegram.Bot.Types.User();
            usu.Id = 2046982637;
            message.From = usu;
            long id = 465798;
            message.From.Id = id;
        }

        [Test]
        public void TestHandle()
        {
            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null); ;
            Assert.That(response, Is.EqualTo("¡Hola! Mi nombre es Paco, soy uno de los ultimos soldados vivos 😨. Necesitamos de tu ayuda para batallar contra nuestros enemigos 🤕. ¿Aceptas el reto? ( /Si /No )"));
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