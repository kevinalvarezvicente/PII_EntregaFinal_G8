using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using Telegram.Bot.Types;

namespace ChatBot_Logic.src.Handlers
{
    public class RegisterUserHandler : BaseHandler
    {
        public RegisterUserHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/registrarme" };
        }

        protected override bool InternalHandle(Message message, out string response)
        {
            ChainData chainData = ChainData.Instance;
            string from = message.From.ToString();
            string resp = "";

            if (!chainData.userPostionHandler.ContainsKey(from) && message.Text == "/registrarme")
            {
                response = "Ingrese nombre usuario:";
                chainData.userPostionHandler[from] = "regis1";
                return true;
            }
            else if (chainData.userPostionHandler.ContainsKey(from) && chainData.userPostionHandler[from] == "regis1")
            {
                response = "Ingrese apellido usuario:";
                return true;
            }
            response = "Paso todo";
            return false;


        }
    }
}
