using Telegram.Bot;

namespace ChatBot_Logic.src
{
    public class ChatBot
    {

        private static ChatBot instance;
        private ITelegramBotClient bot;

        private ChatBot()
        {
            this.bot = new TelegramBotClient(token);
        }

        public ITelegramBotClient Client
        {
            get
            {
                return this.bot;
            }
        }

        private UserTelgram BotInfo
        {
            get
            {
                return this.Client.GetMeAsync().Result;
            }
        }

        public int BotId
        {
            get
            {
                return (int)this.BotInfo.Id;
            }
        }

        public string BotName
        {
            get
            {
                return this.BotInfo.FirstName;
            }
        }

        public static ChatBot Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChatBot();
                }
                return instance;
            }
        }
    }
}