using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineChat.PersistantMain.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineChat.PersistantMain.General;

namespace OnlineChat.PersistantMain.General
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }
    }
}



namespace OnlineChat.PersistantMain.Configuration
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(Chat), "Chat");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.UserName).HasMaxLength(200);

            builder.Property(e => e.Password).HasMaxLength(200);

            builder.Property(e => e.FirstName).HasMaxLength(200);

            builder.Property(e => e.LastName).HasMaxLength(200);

            builder.Property(e => e.Email).HasMaxLength(200);

        }
    }
}

