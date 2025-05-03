using Console_Chat.Data;
using Console_Chat.Design;
using Console_Chat.Menu;
using Console_Chat.Models;
using Microsoft.EntityFrameworkCore;
using Natenadze.EntityFrameWork.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Chat.Functionality.UserFunc
{
    class UserFunc
    {
        public static User Login(DataContext data,string name, string password)
        {
            var found = data.Users.FindInBaseByProperty("Name", name);
            if(found == null)
            {
                Say.Red("Error", "Incorrect name!");
            }
            else if (found != null && password != found.Password) {
                Say.Red("Error", "Wrong password!");
            }
            else
            {
                return found;
            }
            return null;
        }
        public static void Register(DataContext data, User user)
        {
            data.Users.AddToBase(data, user);
            Say.Green("Notification", "Successfully registred user!");
        }
        public static void DeleteUser(DataContext data, User user)
        {
            data.Users.RemoveByObject(data, user);
        }
        public static void ChangePassword(DataContext data, User user, string newPassword)
        {
            var newUser = user;
            newUser.Password = newPassword;
            data.Users.Update(newUser);
            Say.Green("Notification", "Password changed successfully!");
        }
        public static void ShowUserInfo(User user)
        {
            Custom.Line();
            Say.Blue("Username:", $"{user.Name}", true);
            Console.WriteLine($" User chats: {user.Chats.Count} - User role: {user.Role}");
        }
        public static MenuResponse UserOptionsMenu(User user)
        {
            MenuResponse response = new MenuResponse() { ExitCode = 200 };
            while(true)
            {
                DataContext data = new DataContext();
                try
                {
                    Custom.Line();
                    Say.Green("1", "User information");
                    Say.Green("2", "Change password");
                    Say.Green("3", "Log out");
                    Say.Green("4", "Delete user");
                    Say.Red("Any", "Back");
                    Console.Write(" Option: ");
                    int option = int.Parse(Console.ReadLine());
                    if(option == 1)
                    {
                        ShowUserInfo(user);
                    }
                    else if(option == 2)
                    {
                        Console.Write(" New password: ");
                        string newPassword = Console.ReadLine();
                        ChangePassword(data, user, newPassword);
                    }
                    else if(option == 3)
                    {
                        response.ExitCode = 203;
                        response.Name = "Log out";
                        return response;
                    }
                    else if(option == 4)
                    {
                        DeleteUser(data, user);
                        Say.Green("Notification", "Successfully deleted user!");
                        response.ExitCode = 203;
                        response.Name = "Deleted user";
                        return response;
                    }
                    else
                    {
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response.ExitCode = 400;
                    response.Name = ex.Message;
                    return response;
                }
            }
        }
    }
}
