using System.Collections.Generic;

namespace ChatBot_Logic.src.Handlers
{
    public class Message
    {

        public static List<Message> message_List = new List<Message>();

        private long idUser;

        private string message;

        public Message(long idUser, string message)
        {
            this.IdUser = idUser;
            this.MessageApp = message;
        }

        public long IdUser
        {
            get
            {
                return this.idUser;
            }
            set
            {
                idUser = value;
            }
        }
        public string MessageApp
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }
    }
}
