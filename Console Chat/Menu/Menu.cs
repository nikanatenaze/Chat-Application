using Console_Chat.Data;
using Console_Chat.Design;
using Console_Chat.Menu.MenuBranches;
using Console_Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Chat.Menu
{
    class Menu
    {
        private static User InSystemUser { get; set; } = null;
        private static MenuResponse LastResponse { get; set; } = null;
        public static void Inject()
        {
            while(true)
            {
                DataContext data = new DataContext();
                try
                {
                    if(InSystemUser == null)
                    {
                        ResponseCatcher(() => GuestMenu.Inject(data));
                    }
                    else if(InSystemUser != null)
                    {
                        ResponseCatcher(() => MemberMenu.Inject(InSystemUser));
                    }
                    else
                    {
                        Console.WriteLine(" Menu isn't done yet! try again later");
                    }
                }
                catch (Exception ex)
                {
                    Say.Red("Error", $"Message: {ex.Message}");
                }
            }
        }

        private static void ResponseCatcher(Func<MenuResponse> func)
        {
            LastResponse = func.Invoke();
            if(LastResponse.ExitCode == 0)
            {
                Environment.Exit(0);
            }
            else if(LastResponse.ExitCode == 202)
            {
                InSystemUser = (User)LastResponse.Content;
            }
            else if(LastResponse.ExitCode == 203)
            {
                InSystemUser = null;
            }
        }
    }
}
