using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    /// <summary>
    /// Handler que devuelve la cantidad de tiros
    /// Es subclase de BaseHandler
    /// Forma parte de Chain of fResponsibility
    /// </summary>
    public class CountShotsHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegisterUserHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CountShotsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new List<string>();
            Keywords.Add("/tiros");
        }
        /// <summary>
        /// Es el método donde se trabaja todo lo del handler.
        /// Procesa el mensaje "/SerSoldado"
        /// </summary>
        /// <param name="message">Mensaje que recibe</param>
        /// <param name="response">Respuesta del bot</param>
        /// <returns>retorna un booleano de que será true si trabaja como corresponde</returns>
        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {
            ChainData chainData = ChainData.Instance;
            string from = message.From.Id.ToString();
            Game game = GamesContainer.VerifyUserOnGame(message.From.Id);
            Player player1 = game.Active_Player;
            Player enemy = game.Inactive_Player;
            CountShot shots = new CountShot();
            int tiros;
            int aguita;

            if (this.CanHandle(message))
            {
                if (!chainData.userPostionHandler[from][0].Equals("/tiros"))
                {
                    chainData.userPostionHandler[from].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo Handler
                }

                if (chainData.userPostionHandler[from].Count == 0)
                {
                    chainData.userPostionHandler[from].Add("/tiros"); //Añadimos el nuevo handler que se esta ejecutando.
                    
                    tiros = shots.TotalShotships();
                    aguita = shots.TotalShotWater();
                
                    response = "Los tiros que hiciste en total al agua son: "+ aguita +"y los tiros que hiciste a los barcos son:"+ tiros ;
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
    }
}
