using ChatBot_Logic.src.HandlersConfiguration;
using ClassLibrary;
using PII_ENTREGAFINAL_G8.src.Library;
using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    public class MakeBoardHandler : BaseHandler
    {
        public MakeBoardHandler(BaseHandler next) : base(next)
        {

            this.Keywords = new List<string>();
            Keywords.Add("/Maldivas");

        }

        protected override bool InternalHandle(Telegram.Bot.Types.Message message, out string response)
        {
            ChainData chainData = ChainData.Instance;
            string from = message.From.ToString();
            
            if(message.Text.Equals("/Maldivas")){
              // User ActiveUser = UsersContainer.GetUSerByID(message.From.Id);
              // Player player = new Player(ActiveUser, 10);
              
               User ActiveUser = new User(message.From.Id,message.From.FirstName, message.From.FirstName);
               Player player = new Player(ActiveUser, 10);
               response = "se creo un board de 10";
               return true;
            }
            else if(message.Text.Equals("/Maldivas")){
               User ActiveUser = UsersContainer.GetUSerByID(message.From.Id);
               Player player = new Player(ActiveUser, 15);
               response = "se creo un board de 15";
               
            }
            else{
               User ActiveUser = UsersContainer.GetUSerByID(message.From.Id);
               Player player = new Player(ActiveUser, 25);
               response = "se creo un board de 25";
               return true;
               
            }

            response = string.Empty;
            return false;
        }
    }
}