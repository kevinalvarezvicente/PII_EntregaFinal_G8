using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System.Collections.Generic;

/*namespace ChatBot_Logic.src.Handlers
{
    public class MakeBoardHandler : BaseHandler
    {
        public MakeBoardHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new List<string>();
            Keywords.Add("/Maldivas");
            Keywords.Add("/Donbas");
            Keywords.Add("/Laos");

        }

        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {
            ChainData chainData = ChainData.Instance;
            string from = message.From.ToString();
            chainData.userPostionHandler[message.From.ToString()].Clear(); //Vaciamos el userPositionHandler para asi registrar el nuevo

            if (this.CanHandle(message) || chainData.userPostionHandler.ContainsKey(from))
            {
                chainData.userPostionHandler[from].Add(message.Text);   //Le dice en que handler esta

                if (chainData.userPostionHandler[from].Count == 2 && message.Text.Equals("/Maldivas"))
                {
                    User ActiveUser = UsersContainer.GetUSerByID(message.From.Id);
                    // Player player = new Player(ActiveUser, 10);

                    //User ActiveUser = new User(message.From.Id, message.From.FirstName, message.From.FirstName);
                    Player player = new Player(ActiveUser, 10);
                    response = "se creo un board de 10";
                    return true;
                }
                else if (chainData.userPostionHandler[from].Count == 2 && message.Text.Equals("/Donbas"))
                {
                    User ActiveUser = UsersContainer.GetUSerByID(message.From.Id);
                    Player player = new Player(ActiveUser, 15);
                    response = "se creo un board de 15";

                }
                else if (chainData.userPostionHandler[from].Count == 2 && message.Text.Equals("/Laos"))
                {
                    User ActiveUser = UsersContainer.GetUSerByID(message.From.Id);
                    Player player = new Player(ActiveUser, 20);
                    response = "se creo un board de 20";
                    return true;

                }
            }

            response = string.Empty;
            return false;
        }
    }
}*/