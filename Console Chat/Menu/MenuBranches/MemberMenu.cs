using Azure;
using Console_Chat.Data;
using Console_Chat.Design;
using Console_Chat.Functionality.ChatFunc;
using Console_Chat.Functionality.UserFunc;
using Console_Chat.Models;
using Console_Chat.Models.ChatModels;
using Natenadze.EntityFrameWork.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Chat.Menu.MenuBranches
{
    class MemberMenu
    {
        public static MenuResponse Inject(User user)
        {
            DataContext data = new DataContext();
            var response = new MenuResponse() { ExitCode = 200 };
            Custom.Line();
            Say.Green("1", "Chats");
            Say.Green("2", "Create new chat");
            Say.Green("3", "User options");
            Say.Red("Any", "Exit");
            Console.Write(" Option: ");
            int option = int.Parse(Console.ReadLine());
            if(option == 1)
            {
                var result = ChatFunc.GetUserChats(data, user);
                if (result == null)
                {
                    Say.Red("Error", "User doesn't have chats yet!");
                }
            }
            else if(option == 2)
            {
                var result = ChatInterfaces.CreateInterface(data, user);
                if(result.ExitCode == 201)
                {
                    var members = (List<User>)result.Content;
                    members.Add(user);
                    var NewChat = new Chat() { CreationDate = DateTime.Now, Users = members };
                    data.Chats.AddToBase(data, NewChat);
                    Say.Green("Notification", "Successfully created new chat!");
                }
            }
            else if(option == 3)
            {
                response = UserFunc.UserOptionsMenu(user);
            }
            else
            {
                response.ExitCode = 0;
                response.Name = "Exited";
            }
            return response;
        }
    }
}
