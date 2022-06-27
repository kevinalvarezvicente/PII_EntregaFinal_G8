using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    public class MakeShotHandler : BaseHandler
    {
        public MakeShotHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new List<string>();
            Keywords.Add("/Disparar");

        }

        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {
            ChainData chainData = ChainData.Instance;
            string from = message.From.ToString();


            if (this.CanHandle(message) || chainData.userPostionHandler.ContainsKey(from))
            {
                chainData.userPostionHandler[from].Add(message.Text);

                if (chainData.userPostionHandler[from].Count == 1)
                {
                    response = "";
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
    }
}