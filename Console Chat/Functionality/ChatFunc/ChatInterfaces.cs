using Console_Chat.Data;
using Console_Chat.Design;
using Console_Chat.Menu;
using Console_Chat.Models;
using Natenadze.EntityFrameWork.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Chat.Functionality.ChatFunc
{
    class ChatInterfaces
    {
        public static MenuResponse CreateInterface(DataContext data, User usera)
        {
            MenuResponse response = new MenuResponse() { ExitCode = 200 };
            List<User> Members = new List<User>(); 
            while(true)
            {
                try
                {
                    Custom.Line();
                    Say.Green("1", "Members");
                    Say.Green("2", "Add member");
                    Say.Green("3", "Remove memeber");
                    Say.Green("4", "Create");
                    Say.Red("Any", "Back");
                    Console.Write(" Option: ");
                    int option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        if(Members.Count != null)
                        {
                            Say.Blue("Member List: ", "", true);
                            foreach(var i in Members)
                            {
                                Console.WriteLine(i);
                            }
                        }
                        else
                        {
                            Say.Red("Error", "Member list is empty yet!");
                        }
                    }
                    else if (option == 2)
                    {
                        Console.Write(" Username: ");
                        string name = Console.ReadLine();
                        var user = data.Users.FindInBaseByProperty("Name", name);
                        if(user == null)
                        {
                            Say.Red("Error", "Can't find user by this username!");
                        }
                        else if(user.Name == usera.Name)
                        {
                            Say.Red("Error", "Can't add your self in your own chat!");
                        }
                        else if(Members.Contains(user))
                        {
                            Say.Red("Error", "Chat already includes that member!");
                        }
                        else
                        {
                            Members.Add(user);
                            Say.Green("Notification", "Successfully added user in chat!");
                        }
                    }
                    else if(option == 3)
                    {
                        Console.Write(" Username: ");
                        string name = Console.ReadLine();
                        var user = Members.FirstOrDefault(x => x.Name == name);
                        if(user != null)
                        {
                            Members.Remove(user);
                            Say.Green("Notification", "Removed user from chat!");
                        }
                        else
                        {
                            Say.Red("Error", "Can't find user in members of the chat!");
                        }
                    }
                    else if(option == 4)
                    {
                        if(Members.Count > 0)
                        {
                            response.ExitCode = 201;
                            response.Content = Members;
                            response.Name = "Create chat";
                            return response;
                        }
                        else
                        {
                            Say.Red("Error", "Can't create chat with 0 members!");
                        }
                    }
                    else
                    {
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    Say.Red("Error", $"Message: {ex.Message}");
                }
            }
        }
    }
}
