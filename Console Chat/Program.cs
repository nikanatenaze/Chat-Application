// See https://aka.ms/new-console-template for more information
using Console_Chat.Data;
using Console_Chat.Menu;
using Console_Chat.Models.ChatModels;
using Natenadze.EntityFrameWork.Tools;

DataContext data = new DataContext();
data.Chats.AddToBase(data, new Chat() { CreationDate = DateTime.Now });
