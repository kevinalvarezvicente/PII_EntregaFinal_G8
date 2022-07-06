using System.Collections.ObjectModel;
using ChatBot_Logic.src.Handlers;
using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using NUnit.Framework;
using Telegram.Bot.Types;

namespace LibraryTests
{
    /// <summary>
    ///   testea el hola handler
    /// </summary>
    public class BattlePlacerHandlerTest
    {
        BattlePlacerHandler handler;
        Message message;

        ChainData chainData = ChainData.Instance;

        [SetUp]
        public void Setup()
        {
            handler = new BattlePlacerHandler(null);
            message = new Message();
            Telegram.Bot.Types.User usu = new Telegram.Bot.Types.User();
            usu.Id = 2046982637;
            message.From = usu;
            long id = 465798;
            message.From.Id = id;
        }

        /// <summary>
        ///     se testea el hello handler
        /// </summary>
        [Test]
        public void RegisterUserHandler()
        {
            message.Text = handler.Keywords[0];
            string response;
            chainData.userPostionHandler.Add("465798", new Collection<string>());
            chainData.userPostionHandler["465798"].Add("/Prueba");
            IHandler result = handler.Handle(message, out response);

            Assert.That(response, Is.EqualTo("Antes de luchar debes de seleccionar la region 🌎 de campo en la que batallarás a muerte.🪦" +
                    "\n🇦🇷 /Malvinas: 7 hectareas \n🇺🇦 /Donbas: 9 hectareas \n🇱🇦 /Laos: 11 hectareas"));
            Assert.That(result, Is.Not.Null);
        }
        /// <summary>
        ///     Se teste que no hay un handler
        /// </summary>
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