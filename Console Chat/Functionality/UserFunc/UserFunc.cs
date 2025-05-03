using Console_Chat.Data;
using Console_Chat.Design;
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
        public static void DeleteUser(DataContext data, string userName)
        {
            var result = data.Users.RemoveFromBaseByProperty(data, "Name", userName);
            if (result) Say.Green("Notification", "Successfully deleted user!");
        }
        public static void ChangePassword(DataContext data, User user, string newPassword)
        {
            var newUser = user;
            newUser.Password = newPassword;
            data.Users.Update(newUser);
            Say.Green("Notification", "Password changed successfully!");
        }
    }
}
