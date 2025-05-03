using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Chat.Models.ChatModels
{
    class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
