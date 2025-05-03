using Console_Chat.Models.ChatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Chat.Models
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SystemRoles Role { get; set; }
        public ICollection<Chat> Chats { get; set; }
    }
}
