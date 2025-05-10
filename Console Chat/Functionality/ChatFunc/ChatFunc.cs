using Console_Chat.Data;
using Console_Chat.Models;
using Console_Chat.Models.ChatModels;
using Natenadze.EntityFrameWork.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Chat.Functionality.ChatFunc
{
    class ChatFunc
    {
        public static void Create(DataContext data, User Creator, List<User> UsersInChat)
        {
            var users = UsersInChat;
            users.Add(Creator);
            var chat = new Chat() { CreationDate = DateTime.Now, Users = users };
            data.Chats.AddToBase(data, chat);
        }
        public static bool QuitChat(DataContext data, User user, Chat chat)
        {
            if(chat.Users.Contains(user))
            {
                chat.Users.Remove(user);
                return true;
            }
            return false;
        }
        public static void Information(Chat chat)
        {
            Console.WriteLine(chat.Users.Count);
        }
        public static List<Chat> GetUserChats(DataContext data,User user)
        {
            var result = new List<Chat>();
            foreach(var i in data.Chats)
            {
                if (i.Users.Contains(user))
                {
                    result.Add(i);
                }
            }
            return result.Count == 0 ? null : result;
        }
    }
}
