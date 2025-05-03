using Azure;
using Console_Chat.Design;
using Console_Chat.Functionality.UserFunc;
using Console_Chat.Models;
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

            }
            else if(option == 2)
            {

            }
            else if(option == 3)
            {
                response = UserFunc.UserOptionsMenu(user);
            }
            else
            {
                
            }
            return response;
        }
    }
}
