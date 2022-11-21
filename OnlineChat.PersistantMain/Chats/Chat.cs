using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineChat.PersistantMain.Chats
{
    public class Chat
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int Reciver { get; set; }
        public int Sender { get; set; }
    }
}
