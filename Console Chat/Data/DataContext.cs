using Console_Chat.Data.Config;
using Console_Chat.Models;
using Console_Chat.Models.ChatModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Chat.Data
{
    class DataContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O7HERMN;Database=ChatDb;Trusted_Connection=True;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChatConfig());
            modelBuilder.ApplyConfiguration(new MessageConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
