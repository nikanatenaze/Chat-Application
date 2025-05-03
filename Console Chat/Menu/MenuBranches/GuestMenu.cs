using Azure;
using Console_Chat.Data;
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
    class GuestMenu
    {
        public static MenuResponse Inject(DataContext data)
        {
            MenuResponse response = new MenuResponse();
            Custom.Line();
            Say.Green("1", "Log In");
            Say.Green("2", "Register");
            Say.Green("3", "Credits");
            Say.Red("Any", "Exit");
            Console.Write(" Option: ");
            int option = int.Parse(Console.ReadLine());
            if(option == 1)
            {
                Custom.Line();
                Console.Write(" Name: ");
                string name = Console.ReadLine();
                Console.Write(" Password: ");
                string password = Console.ReadLine();
                var result = UserFunc.Login(data, name, password);
                if (result != null) Say.Green("Notification", "Loged in successfully!");
                response.ExitCode = 202;
                response.Content = result;
                response.Name = "Loged In";
            }
            else if(option == 2)
            {
                Custom.Line();
                Console.Write(" Name: ");
                string name = Console.ReadLine();
                Console.Write(" Password: ");
                string password = Console.ReadLine();
                User user = new User() { Name = name, Password = password, Role = 0};
                UserFunc.Register(data, user);
                response.ExitCode = 201;
                response.Content = user;
                response.Name = "Registred user";
            }
            else if(option == 3)
            {
                Custom.Line();
                Say.Magenta(" Discord:", "nikanatenaze", true);
                Say.Blue(" GitHub:", "nikanatenaze", true);
                response.ExitCode = 200;
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
