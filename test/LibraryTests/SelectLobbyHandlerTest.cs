using System.Collections.ObjectModel;
using ChatBot_Logic.src.Handlers;
using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using NUnit.Framework;
using PII_ENTREGAFINAL_G8.src.Library;
using Telegram.Bot.Types;

namespace LibraryTests
{
    /// <summary>
    ///   testea el SelectLobbyHandler handler
    /// </summary>
    public class SelectLobbyHandlerTest
    {
        SelectLobbyHandler handler;
        Message message;

        ChainData chainData = ChainData.Instance;

        /// <summary>
        ///     Inicializa datos del handler.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            handler = new SelectLobbyHandler(null);
            message = new Message();
            Telegram.Bot.Types.User usu = new Telegram.Bot.Types.User();
            usu.Id = 2046982637;
            message.From = usu;
            long id = 2046982637;
            message.From.Id = id;
        }

        /// <summary>
        ///     se testea el hello handler
        /// </summary>
        [Test]
        public void RegisterUserHandler()
        {
            chainData.userPostionHandler.Add("2046982637", new Collection<string>());
            chainData.userPostionHandler["2046982637"].Add("/Prueba1");
            message.Text = handler.Keywords[0];
            string response;
            PII_ENTREGAFINAL_G8.src.Library.User matias = new PII_ENTREGAFINAL_G8.src.Library.User(2046982637, "Olave", "Matias");
            UsersContainer.AddUser(matias);
            PII_ENTREGAFINAL_G8.src.Library.User ActiveUser = UsersContainer.GetUSerByID(2046982637);
            Player player = new Player(ActiveUser);
            
            IHandler result = handler.Handle(message, out response);

            Assert.That(response, Is.EqualTo("¡Has seleccionado las 🇦🇷 Malvinas 🇦🇷 de 7 hectareas!. "
                            + "Para ser el dueño 🔑 de esta zona debes defenderla ⚔️... \n Espero poder volver a verte luego de la batalla 🤞🏽. ¡Suerte 🍀! \n Según informes 📜 de nuestra inteligencia están atacando tu zona, defiendela o la perderás /defender"));
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