using Microsoft.EntityFrameworkCore;
using OnlineChat.PersistantMain.Chats;
using OnlineChat.PersistantMain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineChat.PersistantMain
{
    public partial class ApplicationDbContext : DbContext
    {
        string connection = "Data Source=192.168.10.63;initial catalog=Alborz;User ID=sa;Password=pilot@123";

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(string connectionString) : base(GetOptions(connectionString))
        {
            connection = connectionString;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvoiceEntities.Configuration.DetailBasketReturnedMap());

            modelBuilder.ApplyConfiguration(new InvoiceEntities.Configuration.DetailBasketReturnedMap());

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }


    }
}
