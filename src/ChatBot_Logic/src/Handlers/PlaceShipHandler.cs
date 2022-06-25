using PII_ENTREGAFINAL_G8.src.Library;
using ChatBot_Logic.src.HandlersConfiguration;
using Telegram.Bot.Types;

namespace ChatBot_Logic.src.Handlers
{

    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class PlaceShipHandler : BaseHandler
    {
        private long SenderID;
        bool verification = false;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PlaceShipHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/placeShip" };
        }

        public void VerifyHandlersConclude()
        {
            /*bool verification = UsersContainer.VerifyUserByID(this.SenderID);
            if (verification)
            {/*/
            long gameID = GamesContainer.VerifyUserOnGame(this.SenderID);

            PII_ENTREGAFINAL_G8.src.Library.Game game = GamesContainer.ObtainGame(gameID);

            if (game.Active_Player.UserId == this.SenderID){
                verification = true;
            }
        }
        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            if (this.verification)
            {
                response = "Es hora de comenzar a posicionar tus naves";
            }else
            {
                response = "No ha iniciado un juego";
            }
            this.SenderID=message.From.Id;
        }
    }
}

