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
    ///   testea el count tiros
    /// </summary>
    public class HelloCountShotsTests
    {

        CountShotsHandler handler;
        Message message;

        ChainData chainData = ChainData.Instance;
        /// <summary>
        /// Se inicializa datos del handler.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            handler = new CountShotsHandler(null);
            message = new Message();
            Telegram.Bot.Types.User usu = new Telegram.Bot.Types.User();
            usu.Id = 2046982637;
            message.From = usu;
            long id = 465798;
            message.From.Id = id;
        }

        /// <summary>
        ///     se testea el count handler
        /// </summary>
        [Test]
        public void HelloHandler()
        {


            chainData.userPostionHandler.Add("465798", new Collection<string>());
            chainData.userPostionHandler["465798"].Add("/Prueba");
            string response;
            message.Text = handler.Keywords[0];
            IHandler result = handler.Handle(message, out response);
            PII_ENTREGAFINAL_G8.src.Library.User matias = new PII_ENTREGAFINAL_G8.src.Library.User(2046982637, "Olave", "Matias");
            UsersContainer.AddUser(matias);
            PII_ENTREGAFINAL_G8.src.Library.User ActiveUser = UsersContainer.GetUSerByID(2046982637);
            Player player = new Player(ActiveUser);



            Assert.That(result, Is.Not.Null); ;
            Assert.That(response, Is.EqualTo("Realizaste el tiro"));
        }


    }
}