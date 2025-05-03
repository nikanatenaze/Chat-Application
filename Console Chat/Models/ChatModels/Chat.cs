using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Chat.Models.ChatModels
{
    class Chat
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
