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

            if (this.CanHandle(message) || chainData.userPostionHandler.ContainsKey(from))
            {
                chainData.userPostionHandler[from].Add(message.Text);
                if (chainData.userPostionHandler[from][0].Equals("/registrarme") && chainData.userPostionHandler[from].Count == 1)
                {
                    response = "Ingrese nombre usuario:";
                    return true;
                }

                if (chainData.userPostionHandler[from][0].Equals("/registrarme") && chainData.userPostionHandler[from].Count == 2)
                {
                    chainData.userPostionHandler[from].Add(message.Text);
                    response = "Ingrese apellido usuario:";
                    return true;
                }
                if (chainData.userPostionHandler[from][0].Equals("/registrarme") && chainData.userPostionHandler[from].Count == 3)
                {
                    chainData.userPostionHandler[from].Add(message.Text);
                    response = $"{message.Text}{chainData.userPostionHandler[from][1]}FUNCA";
                    return true;
                }
            }
            response = string.Empty;
            return false;

        }
    }
}
